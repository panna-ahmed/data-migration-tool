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
        List<Column> primaryColumns = new List<Column>();

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
            primaryColumns.Clear();
            foreach (DataGridViewRow row in dataGridViewColumnSelection.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = (chk.Value == null ? false : (bool)chk.Value);

                if ((bool)chk.Value)
                {
                    var colname = ((DataGridViewTextBoxCell)row.Cells[3]).Value.ToString();
                    var coltype = ((DataGridViewTextBoxCell)row.Cells[5]).Value.ToString();
                    var collength = ((DataGridViewTextBoxCell)row.Cells[6]).Value.ToString();
                    var colcollate = ((DataGridViewTextBoxCell)row.Cells[7]).Value.ToString();

                    selectedColumns.Add(new Column { Name = colname, SQLType = coltype, Length = collength, Collate = colcollate });
                }

                DataGridViewCheckBoxCell chkP = (DataGridViewCheckBoxCell)row.Cells[1];
                chkP.Value = (chkP.Value == null ? false : (bool)chkP.Value);

                if ((bool)chkP.Value)
                {
                    var colname = ((DataGridViewTextBoxCell)row.Cells[3]).Value.ToString();
                    var coltype = ((DataGridViewTextBoxCell)row.Cells[5]).Value.ToString();
                    var collength = ((DataGridViewTextBoxCell)row.Cells[6]).Value.ToString();
                    var colcollate = ((DataGridViewTextBoxCell)row.Cells[7]).Value.ToString();

                    primaryColumns.Add(new Column { Name = colname, SQLType = coltype, Length = collength, Collate = colcollate });
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

                        if (selectedColumns.Count == 0)
                        {
                            MessageBox.Show("No Columns selected.");
                            return;
                        }

                        if (primaryColumns.Count == 0)
                        {
                            MessageBox.Show("No Primary Columns selected.");
                            return;
                        }

                        var sourceTable = new Table { Name = comboBoxTables.SelectedValue.ToString() };
                        var targetTable = new Table { Name = comboBoxTables.SelectedValue.ToString(), Target = true};

                        var tempTableStatement = "CREATE TABLE "+ sourceTable.FullName + "(" + Helper.GetCreateStatement(selectedColumns) + ");";
                        using (SqlConnection con = new SqlConnection(connStr))
                        {
                            con.Open();
                            using (SqlCommand command = new SqlCommand(tempTableStatement, con))
                                command.ExecuteNonQuery();

                            var sqlBulk = new SqlBulkCopy(con);
                            List<dynamic> rows;
                            var bad = new List<string>();
                            List<string> columns;
                            using (var reader = new StreamReader(fileStream))
                            using (var csv = new CsvReader(reader))
                            {
                                csv.Configuration.BadDataFound = context =>
                                {
                                    bad.Add(context.RawRecord);
                                };

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

                            sqlBulk.DestinationTableName = sourceTable.FullName;
                            sqlBulk.WriteToServer(table);

                            var mergeStatement = 
                                "CREATE TABLE dbo.[#output" + sourceTable.Name + @"](
                                "+ Helper.GetCreateStatement(primaryColumns) +@",
                                CONSTRAINT[PK_"+ sourceTable.Name + @"] PRIMARY KEY CLUSTERED
                                (
                                   " + primaryColumns[0].SQLName + @" ASC
                                ));

                                INSERT INTO dbo.[#output" + sourceTable.Name + @"] (" + primaryColumns[0].SQLName + @")
                                SELECT TableChanges." + primaryColumns[0].SQLName + @"
                                FROM
                                    (MERGE " + targetTable.FullName + @" as t 
                                    USING " + sourceTable.FullName + @" as s
                                ON(" + Helper.GetWhereStatement("s", "t", primaryColumns ) + @")
                                WHEN MATCHED
                                    THEN UPDATE SET
                                        " + Helper.GetUpdateStatement("s", "t", selectedColumns);
                            if(!checkBoxInsert.Checked)
                                mergeStatement = mergeStatement + @" WHEN NOT MATCHED BY TARGET
                                    THEN INSERT(" + Helper.GetSelectStatement(selectedColumns) + ")" +
                                         "VALUES(" + Helper.GetInsertStatement("s",selectedColumns) +")";

                            mergeStatement = mergeStatement + @"OUTPUT $action, s." + primaryColumns[0].SQLName + @"
                                    ) AS TableChanges(MergeAction, "+ primaryColumns[0].SQLName + @")
                                WHERE TableChanges.MergeAction = 'UPDATE'
                                ;";

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

        private void textBoxTableFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonTableFilter_Click(null, null);
            }
        }
    }
}
