using CsvHelper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DataMigrationTool
{
    public partial class MainForm : Form
    {
        List<Column> selectedColumns = new List<Column>();
        string connStr = string.Empty;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            connStr = ConfigurationManager.ConnectionStrings["DataMigrationTool.Properties.Settings.DBMigrateConnectionString"].ConnectionString;

            this.companyTableAdapter.Fill(this.NavDataset.Company);
        }

        private void comboBoxCompanies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCompanies.SelectedValue != null)
                this.tablesTableAdapter.FillBy(this.NavDataset.tables, comboBoxCompanies.SelectedValue.ToString(), string.Empty);
        }

        private void buttonTableFilter_Click(object sender, EventArgs e)
        {
            if (comboBoxCompanies.SelectedValue != null && !string.IsNullOrEmpty(textBoxTableFilter.Text))
            {
                this.tablesTableAdapter.FillBy(this.NavDataset.tables, comboBoxCompanies.SelectedValue.ToString(), textBoxTableFilter.Text + '%');
                comboBoxTables_SelectedIndexChanged(null, null);
            }
        }

        private void comboBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxTables.SelectedValue != null)
                this.cOLUMNSTableAdapter.FillBy(this.navDataset1.COLUMNS, comboBoxTables.SelectedValue.ToString());
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            try
            {
                GetSelectColumns();

                var selectstatement = string.Join(",", selectedColumns.Select(c => c.SQLName).ToArray());

                SqlConnection con = new SqlConnection(connStr);
                con.Open();

                string sqlstring = "SELECT " + selectstatement + " FROM [" + comboBoxTables.SelectedValue + "]";
                SqlCommand cmd = new SqlCommand(sqlstring, con);
                SqlDataReader dr = cmd.ExecuteReader();

                using (var csv = new CsvWriter(new StreamWriter(@"C:\dev\" + comboBoxTables.SelectedValue + ".csv")))
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        csv.WriteField(dr.GetName(i));
                    }
                    csv.NextRecord();

                    while (dr.Read())
                    {
                        for (var i = 0; i < dr.FieldCount; i++)
                        {
                            csv.WriteField(dr[i]);
                        }
                        csv.NextRecord();
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                labelErrors.Text = ex.Message;
            }
        }

        private void GetSelectColumns()
        {
            selectedColumns.Clear();
            foreach (DataGridViewRow row in dataGridViewColumnSelection.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = (chk.Value == null ? false : (bool)chk.Value);

                if ((bool)chk.Value)
                {
                    var colname = ((DataGridViewTextBoxCell)row.Cells[2]).Value.ToString();
                    var coltype = ((DataGridViewTextBoxCell)row.Cells[4]).Value.ToString();
                    var collength = ((DataGridViewTextBoxCell)row.Cells[5]).Value.ToString();
                    var colcollate = ((DataGridViewTextBoxCell)row.Cells[6]).Value.ToString();

                    selectedColumns.Add(new Column { Name = colname, SQLType = coltype, Length = collength, Collate = colcollate });
                }
            }
        }

        private void dataGridViewColumnSelection_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewColumnSelection.SelectedRows.Count > 0)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dataGridViewColumnSelection.SelectedRows[0].Cells[0];
                chk.Value = !(chk.Value == null ? false : (bool)chk.Value);
            }
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            try
            {
                var fileContent = string.Empty;
                var filePath = string.Empty;

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filePath = openFileDialog.FileName;

                        var fileStream = openFileDialog.OpenFile();

                        GetSelectColumns();
                        var sourceTable = "dbo.[#" + comboBoxTables.SelectedValue.ToString() + "]";
                        var targetTable = "dbo.[" + comboBoxTables.SelectedValue.ToString() + "]";

                        var tempTableStatement = "CREATE TABLE "+ sourceTable + "(" + Helper.GetCreateStatement(selectedColumns) + ");";
                        using (SqlConnection con = new SqlConnection(connStr))
                        {
                            con.Open();
                            using (SqlCommand command = new SqlCommand(tempTableStatement, con))
                                command.ExecuteNonQuery();

                            var sqlBulk = new SqlBulkCopy(con);
                            List<dynamic> rows;
                            List<string> columns;
                            using (var reader = new StreamReader(fileStream))
                            using (var csv = new CsvReader(reader))
                            {
                                rows = csv.GetRecords<dynamic>().ToList();
                                columns = csv.Context.HeaderRecord.ToList();
                            }

                            if (rows.Count == 0)
                                return;

                            var table = new DataTable();
                            sqlBulk.ColumnMappings.Clear();

                            foreach (var c in columns)
                            {
                                table.Columns.Add(c);
                                sqlBulk.ColumnMappings.Add(c, c);
                            }

                            foreach (IDictionary<string, object> row in rows)
                            {
                                var rowValues = row.Values
                                    .Select(a => string.IsNullOrEmpty(a.ToString()) ? null : a)
                                    .ToArray();
                                table.Rows.Add(rowValues);
                            }

                            sqlBulk.DestinationTableName = sourceTable;
                            sqlBulk.WriteToServer(table);

                            var mergeStatement = "MERGE " + targetTable + @" as t 
                                    USING " + sourceTable + @" as s
                                ON(s." + selectedColumns[0].SQLName +" = t."+ selectedColumns[0].SQLName +@")
                                WHEN MATCHED
                                    THEN UPDATE SET
                                        " + Helper.GetUpdateStatement("s","t",selectedColumns) + @"
                                WHEN NOT MATCHED BY TARGET
                                    THEN INSERT("+ Helper.GetSelectStatement(selectedColumns) + ")" +
                                         "VALUES(" + Helper.GetInsertStatement("s",selectedColumns) +");";

                            using (SqlCommand command = new SqlCommand(mergeStatement, con))
                                command.ExecuteNonQuery();
                        }
                    }
                }

                labelErrors.Text = string.Empty;
            }
            catch (Exception ex)
            {
                labelErrors.Text = ex.Message;
            }
        }
    }
}
