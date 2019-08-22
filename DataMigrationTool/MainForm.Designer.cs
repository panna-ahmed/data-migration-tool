namespace DataMigrationTool
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.comboBoxCompanies = new System.Windows.Forms.ComboBox();
            this.companyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.NavDataset = new DataMigrationTool.NavDataset();
            this.label1 = new System.Windows.Forms.Label();
            this.companyTableAdapter = new DataMigrationTool.NavDatasetTableAdapters.CompanyTableAdapter();
            this.comboBoxTables = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tablesTableAdapter = new DataMigrationTool.NavDatasetTableAdapters.tablesTableAdapter();
            this.tableAdapterManager = new DataMigrationTool.NavDatasetTableAdapters.TableAdapterManager();
            this.textBoxTableFilter = new System.Windows.Forms.TextBox();
            this.buttonTableFilter = new System.Windows.Forms.Button();
            this.dataGridViewColumnSelection = new System.Windows.Forms.DataGridView();
            this.cOLUMNSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.navDataset1 = new DataMigrationTool.NavDataset();
            this.cOLUMNSTableAdapter = new DataMigrationTool.NavDatasetTableAdapters.COLUMNSTableAdapter();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonImport = new System.Windows.Forms.Button();
            this.labelErrors = new System.Windows.Forms.Label();
            this.checkBoxInsert = new System.Windows.Forms.CheckBox();
            this.RowSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Primary = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TABLE_SCHEMA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOLUMNNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iSNULLABLEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dATATYPEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cHARACTERMAXIMUMLENGTHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COLLATION_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NavDataset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewColumnSelection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOLUMNSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navDataset1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxCompanies
            // 
            this.comboBoxCompanies.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxCompanies.DataSource = this.companyBindingSource;
            this.comboBoxCompanies.DisplayMember = "Name";
            this.comboBoxCompanies.FormattingEnabled = true;
            this.comboBoxCompanies.Location = new System.Drawing.Point(133, 15);
            this.comboBoxCompanies.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxCompanies.Name = "comboBoxCompanies";
            this.comboBoxCompanies.Size = new System.Drawing.Size(160, 24);
            this.comboBoxCompanies.TabIndex = 0;
            this.comboBoxCompanies.ValueMember = "Name";
            this.comboBoxCompanies.SelectedIndexChanged += new System.EventHandler(this.comboBoxCompanies_SelectedIndexChanged);
            // 
            // companyBindingSource
            // 
            this.companyBindingSource.DataMember = "Company";
            this.companyBindingSource.DataSource = this.NavDataset;
            // 
            // NavDataset
            // 
            this.NavDataset.DataSetName = "_Demo_Database_NAV__11_0_DataSet";
            this.NavDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Companies";
            // 
            // companyTableAdapter
            // 
            this.companyTableAdapter.ClearBeforeFill = true;
            // 
            // comboBoxTables
            // 
            this.comboBoxTables.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxTables.DataSource = this.NavDataset;
            this.comboBoxTables.DisplayMember = "tables.name";
            this.comboBoxTables.FormattingEnabled = true;
            this.comboBoxTables.Location = new System.Drawing.Point(133, 49);
            this.comboBoxTables.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxTables.Name = "comboBoxTables";
            this.comboBoxTables.Size = new System.Drawing.Size(518, 24);
            this.comboBoxTables.TabIndex = 2;
            this.comboBoxTables.ValueMember = "tables.name";
            this.comboBoxTables.SelectedIndexChanged += new System.EventHandler(this.comboBoxTables_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tables";
            // 
            // tablesTableAdapter
            // 
            this.tablesTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CompanyTableAdapter = null;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = DataMigrationTool.NavDatasetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // textBoxTableFilter
            // 
            this.textBoxTableFilter.Location = new System.Drawing.Point(301, 16);
            this.textBoxTableFilter.Name = "textBoxTableFilter";
            this.textBoxTableFilter.Size = new System.Drawing.Size(197, 22);
            this.textBoxTableFilter.TabIndex = 4;
            this.textBoxTableFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxTableFilter_KeyDown);
            // 
            // buttonTableFilter
            // 
            this.buttonTableFilter.Location = new System.Drawing.Point(504, 13);
            this.buttonTableFilter.Name = "buttonTableFilter";
            this.buttonTableFilter.Size = new System.Drawing.Size(147, 27);
            this.buttonTableFilter.TabIndex = 5;
            this.buttonTableFilter.Text = "Filter";
            this.buttonTableFilter.UseVisualStyleBackColor = true;
            this.buttonTableFilter.Click += new System.EventHandler(this.buttonTableFilter_Click);
            // 
            // dataGridViewColumnSelection
            // 
            this.dataGridViewColumnSelection.AllowUserToAddRows = false;
            this.dataGridViewColumnSelection.AllowUserToDeleteRows = false;
            this.dataGridViewColumnSelection.AutoGenerateColumns = false;
            this.dataGridViewColumnSelection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewColumnSelection.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowSelect,
            this.Primary,
            this.TABLE_SCHEMA,
            this.cOLUMNNAMEDataGridViewTextBoxColumn,
            this.iSNULLABLEDataGridViewTextBoxColumn,
            this.dATATYPEDataGridViewTextBoxColumn,
            this.cHARACTERMAXIMUMLENGTHDataGridViewTextBoxColumn,
            this.COLLATION_NAME});
            this.dataGridViewColumnSelection.DataSource = this.cOLUMNSBindingSource;
            this.dataGridViewColumnSelection.Location = new System.Drawing.Point(19, 80);
            this.dataGridViewColumnSelection.Name = "dataGridViewColumnSelection";
            this.dataGridViewColumnSelection.RowTemplate.Height = 24;
            this.dataGridViewColumnSelection.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewColumnSelection.Size = new System.Drawing.Size(1236, 575);
            this.dataGridViewColumnSelection.TabIndex = 6;
            this.dataGridViewColumnSelection.SelectionChanged += new System.EventHandler(this.dataGridViewColumnSelection_SelectionChanged);
            // 
            // cOLUMNSBindingSource
            // 
            this.cOLUMNSBindingSource.DataMember = "COLUMNS";
            this.cOLUMNSBindingSource.DataSource = this.navDataset1;
            // 
            // navDataset1
            // 
            this.navDataset1.DataSetName = "NavDataset";
            this.navDataset1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cOLUMNSTableAdapter
            // 
            this.cOLUMNSTableAdapter.ClearBeforeFill = true;
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(856, 13);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(130, 27);
            this.buttonExport.TabIndex = 7;
            this.buttonExport.Text = "Export";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // buttonImport
            // 
            this.buttonImport.Location = new System.Drawing.Point(720, 13);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(130, 27);
            this.buttonImport.TabIndex = 8;
            this.buttonImport.Text = "Import";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // labelErrors
            // 
            this.labelErrors.ForeColor = System.Drawing.Color.Red;
            this.labelErrors.Location = new System.Drawing.Point(16, 667);
            this.labelErrors.Name = "labelErrors";
            this.labelErrors.Size = new System.Drawing.Size(970, 49);
            this.labelErrors.TabIndex = 9;
            // 
            // checkBoxInsert
            // 
            this.checkBoxInsert.AutoSize = true;
            this.checkBoxInsert.Location = new System.Drawing.Point(720, 49);
            this.checkBoxInsert.Name = "checkBoxInsert";
            this.checkBoxInsert.Size = new System.Drawing.Size(142, 21);
            this.checkBoxInsert.TabIndex = 10;
            this.checkBoxInsert.Text = "Insert if not match";
            this.checkBoxInsert.UseVisualStyleBackColor = true;
            // 
            // RowSelect
            // 
            this.RowSelect.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.RowSelect.HeaderText = "Select";
            this.RowSelect.Name = "RowSelect";
            this.RowSelect.Width = 53;
            // 
            // Primary
            // 
            this.Primary.HeaderText = "Primary";
            this.Primary.Name = "Primary";
            // 
            // TABLE_SCHEMA
            // 
            this.TABLE_SCHEMA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TABLE_SCHEMA.DataPropertyName = "TABLE_SCHEMA";
            this.TABLE_SCHEMA.HeaderText = "TABLE_SCHEMA";
            this.TABLE_SCHEMA.Name = "TABLE_SCHEMA";
            this.TABLE_SCHEMA.ReadOnly = true;
            this.TABLE_SCHEMA.Width = 146;
            // 
            // cOLUMNNAMEDataGridViewTextBoxColumn
            // 
            this.cOLUMNNAMEDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cOLUMNNAMEDataGridViewTextBoxColumn.DataPropertyName = "COLUMN_NAME";
            this.cOLUMNNAMEDataGridViewTextBoxColumn.HeaderText = "COLUMN_NAME";
            this.cOLUMNNAMEDataGridViewTextBoxColumn.Name = "cOLUMNNAMEDataGridViewTextBoxColumn";
            this.cOLUMNNAMEDataGridViewTextBoxColumn.ReadOnly = true;
            this.cOLUMNNAMEDataGridViewTextBoxColumn.Width = 143;
            // 
            // iSNULLABLEDataGridViewTextBoxColumn
            // 
            this.iSNULLABLEDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.iSNULLABLEDataGridViewTextBoxColumn.DataPropertyName = "IS_NULLABLE";
            this.iSNULLABLEDataGridViewTextBoxColumn.HeaderText = "IS_NULLABLE";
            this.iSNULLABLEDataGridViewTextBoxColumn.Name = "iSNULLABLEDataGridViewTextBoxColumn";
            this.iSNULLABLEDataGridViewTextBoxColumn.ReadOnly = true;
            this.iSNULLABLEDataGridViewTextBoxColumn.Width = 128;
            // 
            // dATATYPEDataGridViewTextBoxColumn
            // 
            this.dATATYPEDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dATATYPEDataGridViewTextBoxColumn.DataPropertyName = "DATA_TYPE";
            this.dATATYPEDataGridViewTextBoxColumn.HeaderText = "DATA_TYPE";
            this.dATATYPEDataGridViewTextBoxColumn.Name = "dATATYPEDataGridViewTextBoxColumn";
            this.dATATYPEDataGridViewTextBoxColumn.ReadOnly = true;
            this.dATATYPEDataGridViewTextBoxColumn.Width = 118;
            // 
            // cHARACTERMAXIMUMLENGTHDataGridViewTextBoxColumn
            // 
            this.cHARACTERMAXIMUMLENGTHDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cHARACTERMAXIMUMLENGTHDataGridViewTextBoxColumn.DataPropertyName = "CHARACTER_MAXIMUM_LENGTH";
            this.cHARACTERMAXIMUMLENGTHDataGridViewTextBoxColumn.HeaderText = "CHARACTER_MAXIMUM_LENGTH";
            this.cHARACTERMAXIMUMLENGTHDataGridViewTextBoxColumn.Name = "cHARACTERMAXIMUMLENGTHDataGridViewTextBoxColumn";
            this.cHARACTERMAXIMUMLENGTHDataGridViewTextBoxColumn.ReadOnly = true;
            this.cHARACTERMAXIMUMLENGTHDataGridViewTextBoxColumn.Width = 258;
            // 
            // COLLATION_NAME
            // 
            this.COLLATION_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.COLLATION_NAME.DataPropertyName = "COLLATION_NAME";
            this.COLLATION_NAME.HeaderText = "COLLATION_NAME";
            this.COLLATION_NAME.Name = "COLLATION_NAME";
            this.COLLATION_NAME.ReadOnly = true;
            this.COLLATION_NAME.Width = 162;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1267, 725);
            this.Controls.Add(this.checkBoxInsert);
            this.Controls.Add(this.labelErrors);
            this.Controls.Add(this.buttonImport);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.dataGridViewColumnSelection);
            this.Controls.Add(this.buttonTableFilter);
            this.Controls.Add(this.textBoxTableFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxTables);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxCompanies);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Data Migration Tool";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NavDataset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewColumnSelection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOLUMNSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navDataset1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCompanies;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource companyBindingSource;
        private DataMigrationTool.NavDatasetTableAdapters.CompanyTableAdapter companyTableAdapter;
        private System.Windows.Forms.ComboBox comboBoxTables;
        private System.Windows.Forms.Label label2;
        private NavDatasetTableAdapters.tablesTableAdapter tablesTableAdapter;
        private NavDatasetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.TextBox textBoxTableFilter;
        private System.Windows.Forms.Button buttonTableFilter;
        private System.Windows.Forms.DataGridView dataGridViewColumnSelection;
        private NavDataset NavDataset;
        private System.Windows.Forms.BindingSource cOLUMNSBindingSource;
        private NavDataset navDataset1;
        private NavDatasetTableAdapters.COLUMNSTableAdapter cOLUMNSTableAdapter;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.Label labelErrors;
        private System.Windows.Forms.CheckBox checkBoxInsert;
        private System.Windows.Forms.DataGridViewCheckBoxColumn RowSelect;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Primary;
        private System.Windows.Forms.DataGridViewTextBoxColumn TABLE_SCHEMA;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOLUMNNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iSNULLABLEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dATATYPEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cHARACTERMAXIMUMLENGTHDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn COLLATION_NAME;
    }
}

