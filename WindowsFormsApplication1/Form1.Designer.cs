namespace WindowsFormsApplication1
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.grpGenerate = new System.Windows.Forms.GroupBox();
            this.btnEstimate = new System.Windows.Forms.Button();
            this.chkAccessoriesRequired = new System.Windows.Forms.CheckBox();
            this.radMoveCycler = new System.Windows.Forms.RadioButton();
            this.radMovePM = new System.Windows.Forms.RadioButton();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtTechName = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.grpProblems = new System.Windows.Forms.GroupBox();
            this.dgvProblems = new System.Windows.Forms.DataGridView();
            this.Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Remove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.PossibleRepairs = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtOne = new System.Windows.Forms.TextBox();
            this.cmbStatus1 = new System.Windows.Forms.ComboBox();
            this.txtProb1 = new System.Windows.Forms.TextBox();
            this.grpParts = new System.Windows.Forms.GroupBox();
            this.btnPreset4 = new System.Windows.Forms.Button();
            this.btnPreset3 = new System.Windows.Forms.Button();
            this.btnPreset2 = new System.Windows.Forms.Button();
            this.btnPreset1 = new System.Windows.Forms.Button();
            this.dgvParts = new System.Windows.Forms.DataGridView();
            this.PartNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OldSerial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OldRev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewSerial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewRev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SolutionNum = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Charge = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.RemovePart = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBillable1 = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.cmbCharge1 = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.cmbSol1 = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtPN1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblFound = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.txtSerialNum = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtSR = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.grpResults = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listPartsResults = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpPartsSearch = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPartNumClear = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.txtPartNum = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.lstNoChelmsford = new System.Windows.Forms.ListBox();
            this.btnEditNeverGoes = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lstCycler = new System.Windows.Forms.ListBox();
            this.btnEditCycler = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lstNoCharge = new System.Windows.Forms.ListBox();
            this.btnEditNoCharge = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.grpGenerate.SuspendLayout();
            this.grpProblems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProblems)).BeginInit();
            this.grpParts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParts)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.grpResults.SuspendLayout();
            this.grpPartsSearch.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1521, 918);
            this.tabControl1.TabIndex = 9;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage3.Controls.Add(this.grpGenerate);
            this.tabPage3.Controls.Add(this.grpProblems);
            this.tabPage3.Controls.Add(this.grpParts);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1513, 888);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Generator";
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // grpGenerate
            // 
            this.grpGenerate.Controls.Add(this.btnEstimate);
            this.grpGenerate.Controls.Add(this.chkAccessoriesRequired);
            this.grpGenerate.Controls.Add(this.radMoveCycler);
            this.grpGenerate.Controls.Add(this.radMovePM);
            this.grpGenerate.Controls.Add(this.btnGenerate);
            this.grpGenerate.Controls.Add(this.txtTechName);
            this.grpGenerate.Controls.Add(this.label39);
            this.grpGenerate.Location = new System.Drawing.Point(15, 755);
            this.grpGenerate.Margin = new System.Windows.Forms.Padding(4);
            this.grpGenerate.Name = "grpGenerate";
            this.grpGenerate.Padding = new System.Windows.Forms.Padding(4);
            this.grpGenerate.Size = new System.Drawing.Size(1478, 90);
            this.grpGenerate.TabIndex = 21;
            this.grpGenerate.TabStop = false;
            this.grpGenerate.Text = "4. Generate";
            // 
            // btnEstimate
            // 
            this.btnEstimate.BackColor = System.Drawing.Color.DarkOrange;
            this.btnEstimate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstimate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstimate.ForeColor = System.Drawing.Color.Black;
            this.btnEstimate.Location = new System.Drawing.Point(1296, 30);
            this.btnEstimate.Margin = new System.Windows.Forms.Padding(4);
            this.btnEstimate.Name = "btnEstimate";
            this.btnEstimate.Size = new System.Drawing.Size(160, 29);
            this.btnEstimate.TabIndex = 27;
            this.btnEstimate.Text = "Estimate";
            this.btnEstimate.UseVisualStyleBackColor = false;
            this.btnEstimate.Click += new System.EventHandler(this.btnEstimate_Click);
            // 
            // chkAccessoriesRequired
            // 
            this.chkAccessoriesRequired.AutoSize = true;
            this.chkAccessoriesRequired.Location = new System.Drawing.Point(941, 35);
            this.chkAccessoriesRequired.Margin = new System.Windows.Forms.Padding(4);
            this.chkAccessoriesRequired.Name = "chkAccessoriesRequired";
            this.chkAccessoriesRequired.Size = new System.Drawing.Size(168, 21);
            this.chkAccessoriesRequired.TabIndex = 26;
            this.chkAccessoriesRequired.Text = "Accessories Required";
            this.chkAccessoriesRequired.UseVisualStyleBackColor = true;
            // 
            // radMoveCycler
            // 
            this.radMoveCycler.AutoSize = true;
            this.radMoveCycler.Location = new System.Drawing.Point(725, 35);
            this.radMoveCycler.Margin = new System.Windows.Forms.Padding(4);
            this.radMoveCycler.Name = "radMoveCycler";
            this.radMoveCycler.Size = new System.Drawing.Size(132, 21);
            this.radMoveCycler.TabIndex = 22;
            this.radMoveCycler.Text = "Move to \"Cycler\"";
            this.radMoveCycler.UseVisualStyleBackColor = true;
            // 
            // radMovePM
            // 
            this.radMovePM.AutoSize = true;
            this.radMovePM.Checked = true;
            this.radMovePM.Location = new System.Drawing.Point(584, 35);
            this.radMovePM.Margin = new System.Windows.Forms.Padding(4);
            this.radMovePM.Name = "radMovePM";
            this.radMovePM.Size = new System.Drawing.Size(113, 21);
            this.radMovePM.TabIndex = 21;
            this.radMovePM.TabStop = true;
            this.radMovePM.Text = "Move to \"PM\"";
            this.radMovePM.UseVisualStyleBackColor = true;
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.ForeColor = System.Drawing.Color.Black;
            this.btnGenerate.Location = new System.Drawing.Point(1129, 30);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(160, 29);
            this.btnGenerate.TabIndex = 5;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtTechName
            // 
            this.txtTechName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTechName.Location = new System.Drawing.Point(131, 35);
            this.txtTechName.Margin = new System.Windows.Forms.Padding(4);
            this.txtTechName.Name = "txtTechName";
            this.txtTechName.Size = new System.Drawing.Size(142, 29);
            this.txtTechName.TabIndex = 18;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(30, 41);
            this.label39.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(99, 17);
            this.label39.TabIndex = 19;
            this.label39.Text = "Completed By:";
            // 
            // grpProblems
            // 
            this.grpProblems.Controls.Add(this.dgvProblems);
            this.grpProblems.Controls.Add(this.txtOne);
            this.grpProblems.Controls.Add(this.cmbStatus1);
            this.grpProblems.Controls.Add(this.txtProb1);
            this.grpProblems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpProblems.Location = new System.Drawing.Point(15, 105);
            this.grpProblems.Margin = new System.Windows.Forms.Padding(4);
            this.grpProblems.Name = "grpProblems";
            this.grpProblems.Padding = new System.Windows.Forms.Padding(4);
            this.grpProblems.Size = new System.Drawing.Size(1478, 231);
            this.grpProblems.TabIndex = 2;
            this.grpProblems.TabStop = false;
            this.grpProblems.Text = "2. Define Problems";
            // 
            // dgvProblems
            // 
            this.dgvProblems.AllowUserToAddRows = false;
            this.dgvProblems.AllowUserToDeleteRows = false;
            this.dgvProblems.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvProblems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProblems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Num,
            this.Description,
            this.Status,
            this.Remove,
            this.PossibleRepairs});
            this.dgvProblems.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvProblems.Location = new System.Drawing.Point(24, 59);
            this.dgvProblems.Margin = new System.Windows.Forms.Padding(4);
            this.dgvProblems.MultiSelect = false;
            this.dgvProblems.Name = "dgvProblems";
            this.dgvProblems.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvProblems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProblems.Size = new System.Drawing.Size(1432, 165);
            this.dgvProblems.TabIndex = 1057;
            this.dgvProblems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProblems_CellContentClick);
            // 
            // Num
            // 
            this.Num.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Num.DefaultCellStyle = dataGridViewCellStyle1;
            this.Num.HeaderText = "No.";
            this.Num.Name = "Num";
            this.Num.Width = 59;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Description.DefaultCellStyle = dataGridViewCellStyle2;
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Status.DefaultCellStyle = dataGridViewCellStyle3;
            this.Status.HeaderText = "Status";
            this.Status.Items.AddRange(new object[] {
            "verified",
            "observed but not verified",
            "observed in the error log but not verified",
            "not observed",
            "worn",
            "replaced as part of repair process",
            "Customer Accommodation",
            "ECO",
            "failed PM",
            "Upgrade"});
            this.Status.Name = "Status";
            this.Status.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Status.Width = 77;
            // 
            // Remove
            // 
            this.Remove.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.Remove.DefaultCellStyle = dataGridViewCellStyle4;
            this.Remove.HeaderText = "Remove";
            this.Remove.Name = "Remove";
            this.Remove.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Remove.Text = "Remove";
            this.Remove.UseColumnTextForButtonValue = true;
            this.Remove.Width = 66;
            // 
            // PossibleRepairs
            // 
            this.PossibleRepairs.HeaderText = "Possible Repairs";
            this.PossibleRepairs.Name = "PossibleRepairs";
            this.PossibleRepairs.Text = "Check";
            // 
            // txtOne
            // 
            this.txtOne.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtOne.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOne.Location = new System.Drawing.Point(-165, 28);
            this.txtOne.Margin = new System.Windows.Forms.Padding(4);
            this.txtOne.Name = "txtOne";
            this.txtOne.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtOne.Size = new System.Drawing.Size(336, 19);
            this.txtOne.TabIndex = 10;
            this.txtOne.TabStop = false;
            this.txtOne.Text = "..The problem of";
            // 
            // cmbStatus1
            // 
            this.cmbStatus1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus1.FormattingEnabled = true;
            this.cmbStatus1.Items.AddRange(new object[] {
            "verified",
            "observed but not verified",
            "observed in the error log but not verified",
            "not observed",
            "worn",
            "replaced as part of repair process",
            "ECO",
            "failed PM",
            "Upgrade"});
            this.cmbStatus1.Location = new System.Drawing.Point(1049, 24);
            this.cmbStatus1.Margin = new System.Windows.Forms.Padding(4);
            this.cmbStatus1.Name = "cmbStatus1";
            this.cmbStatus1.Size = new System.Drawing.Size(406, 26);
            this.cmbStatus1.TabIndex = 1;
            this.cmbStatus1.SelectedIndexChanged += new System.EventHandler(this.cmbStatus1_SelectedIndexChanged);
            this.cmbStatus1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbStatus1_KeyDown);
            this.cmbStatus1.Leave += new System.EventHandler(this.cmbStatus1_Leave);
            // 
            // txtProb1
            // 
            this.txtProb1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtProb1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtProb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProb1.Location = new System.Drawing.Point(179, 24);
            this.txtProb1.Margin = new System.Windows.Forms.Padding(4);
            this.txtProb1.Name = "txtProb1";
            this.txtProb1.Size = new System.Drawing.Size(862, 26);
            this.txtProb1.TabIndex = 0;
            this.txtProb1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProb1_KeyDown);
            // 
            // grpParts
            // 
            this.grpParts.Controls.Add(this.btnPreset4);
            this.grpParts.Controls.Add(this.btnPreset3);
            this.grpParts.Controls.Add(this.btnPreset2);
            this.grpParts.Controls.Add(this.btnPreset1);
            this.grpParts.Controls.Add(this.dgvParts);
            this.grpParts.Controls.Add(this.label2);
            this.grpParts.Controls.Add(this.cmbBillable1);
            this.grpParts.Controls.Add(this.label29);
            this.grpParts.Controls.Add(this.cmbCharge1);
            this.grpParts.Controls.Add(this.label32);
            this.grpParts.Controls.Add(this.cmbSol1);
            this.grpParts.Controls.Add(this.label22);
            this.grpParts.Controls.Add(this.txtPN1);
            this.grpParts.Location = new System.Drawing.Point(15, 344);
            this.grpParts.Margin = new System.Windows.Forms.Padding(4);
            this.grpParts.Name = "grpParts";
            this.grpParts.Padding = new System.Windows.Forms.Padding(4);
            this.grpParts.Size = new System.Drawing.Size(1478, 404);
            this.grpParts.TabIndex = 3;
            this.grpParts.TabStop = false;
            this.grpParts.Text = "3. Scan Parts";
            // 
            // btnPreset4
            // 
            this.btnPreset4.Location = new System.Drawing.Point(984, 49);
            this.btnPreset4.Margin = new System.Windows.Forms.Padding(4);
            this.btnPreset4.Name = "btnPreset4";
            this.btnPreset4.Size = new System.Drawing.Size(215, 29);
            this.btnPreset4.TabIndex = 1060;
            this.btnPreset4.Text = "Presets 4";
            this.btnPreset4.UseVisualStyleBackColor = true;
            this.btnPreset4.Click += new System.EventHandler(this.btnPreset4_Click);
            // 
            // btnPreset3
            // 
            this.btnPreset3.Location = new System.Drawing.Point(761, 49);
            this.btnPreset3.Margin = new System.Windows.Forms.Padding(4);
            this.btnPreset3.Name = "btnPreset3";
            this.btnPreset3.Size = new System.Drawing.Size(215, 29);
            this.btnPreset3.TabIndex = 1059;
            this.btnPreset3.Text = "Presets 3";
            this.btnPreset3.UseVisualStyleBackColor = true;
            this.btnPreset3.Click += new System.EventHandler(this.btnPreset3_Click);
            // 
            // btnPreset2
            // 
            this.btnPreset2.Location = new System.Drawing.Point(539, 49);
            this.btnPreset2.Margin = new System.Windows.Forms.Padding(4);
            this.btnPreset2.Name = "btnPreset2";
            this.btnPreset2.Size = new System.Drawing.Size(215, 29);
            this.btnPreset2.TabIndex = 1058;
            this.btnPreset2.Text = "Presets 2";
            this.btnPreset2.UseVisualStyleBackColor = true;
            this.btnPreset2.Click += new System.EventHandler(this.btnPreset2_Click);
            // 
            // btnPreset1
            // 
            this.btnPreset1.Location = new System.Drawing.Point(312, 49);
            this.btnPreset1.Margin = new System.Windows.Forms.Padding(4);
            this.btnPreset1.Name = "btnPreset1";
            this.btnPreset1.Size = new System.Drawing.Size(215, 29);
            this.btnPreset1.TabIndex = 1057;
            this.btnPreset1.Text = "Presets 1";
            this.btnPreset1.UseVisualStyleBackColor = true;
            this.btnPreset1.Click += new System.EventHandler(this.btnPreset1_Click);
            // 
            // dgvParts
            // 
            this.dgvParts.AllowUserToAddRows = false;
            this.dgvParts.AllowUserToDeleteRows = false;
            this.dgvParts.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PartNum,
            this.PartName,
            this.OldSerial,
            this.OldRev,
            this.NewSerial,
            this.NewRev,
            this.SolutionNum,
            this.Charge,
            this.RemovePart});
            this.dgvParts.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvParts.Location = new System.Drawing.Point(24, 86);
            this.dgvParts.Margin = new System.Windows.Forms.Padding(4);
            this.dgvParts.MultiSelect = false;
            this.dgvParts.Name = "dgvParts";
            this.dgvParts.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvParts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvParts.Size = new System.Drawing.Size(1432, 310);
            this.dgvParts.StandardTab = true;
            this.dgvParts.TabIndex = 1056;
            this.dgvParts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParts_CellContentClick);
            this.dgvParts.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParts_CellValueChanged);
            // 
            // PartNum
            // 
            this.PartNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PartNum.HeaderText = "Part Number";
            this.PartNum.Name = "PartNum";
            this.PartNum.ReadOnly = true;
            this.PartNum.Width = 117;
            // 
            // PartName
            // 
            this.PartName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PartName.FillWeight = 150F;
            this.PartName.HeaderText = "Part Name";
            this.PartName.Name = "PartName";
            // 
            // OldSerial
            // 
            this.OldSerial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.OldSerial.DefaultCellStyle = dataGridViewCellStyle5;
            this.OldSerial.HeaderText = "Old Serial";
            this.OldSerial.Name = "OldSerial";
            this.OldSerial.Width = 99;
            // 
            // OldRev
            // 
            this.OldRev.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.OldRev.DefaultCellStyle = dataGridViewCellStyle6;
            this.OldRev.HeaderText = "Old Rev";
            this.OldRev.Name = "OldRev";
            this.OldRev.Width = 88;
            // 
            // NewSerial
            // 
            this.NewSerial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.NewSerial.DefaultCellStyle = dataGridViewCellStyle7;
            this.NewSerial.HeaderText = "New Serial";
            this.NewSerial.Name = "NewSerial";
            this.NewSerial.Width = 104;
            // 
            // NewRev
            // 
            this.NewRev.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.NewRev.DefaultCellStyle = dataGridViewCellStyle8;
            this.NewRev.HeaderText = "New Rev";
            this.NewRev.Name = "NewRev";
            this.NewRev.Width = 93;
            // 
            // SolutionNum
            // 
            this.SolutionNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SolutionNum.DefaultCellStyle = dataGridViewCellStyle9;
            this.SolutionNum.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.SolutionNum.HeaderText = "Solution #";
            this.SolutionNum.Name = "SolutionNum";
            this.SolutionNum.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SolutionNum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Charge
            // 
            this.Charge.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Charge.DefaultCellStyle = dataGridViewCellStyle10;
            this.Charge.HeaderText = "Charge";
            this.Charge.Items.AddRange(new object[] {
            " ",
            "N/C",
            "ABUSE",
            "DOW",
            "CUSTOMER ACCOMODATION",
            "WORN",
            "BILLABLE PILOT",
            "N/C PILOT"});
            this.Charge.Name = "Charge";
            this.Charge.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Charge.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Charge.Width = 83;
            // 
            // RemovePart
            // 
            this.RemovePart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            this.RemovePart.DefaultCellStyle = dataGridViewCellStyle11;
            this.RemovePart.HeaderText = "Remove";
            this.RemovePart.Name = "RemovePart";
            this.RemovePart.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.RemovePart.Text = "Remove";
            this.RemovePart.UseColumnTextForButtonValue = true;
            this.RemovePart.Width = 66;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(1189, 122);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 1054;
            this.label2.Text = "Billable?";
            this.label2.Visible = false;
            // 
            // cmbBillable1
            // 
            this.cmbBillable1.Enabled = false;
            this.cmbBillable1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBillable1.FormattingEnabled = true;
            this.cmbBillable1.Items.AddRange(new object[] {
            "Y",
            "N"});
            this.cmbBillable1.Location = new System.Drawing.Point(1185, 141);
            this.cmbBillable1.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBillable1.Name = "cmbBillable1";
            this.cmbBillable1.Size = new System.Drawing.Size(74, 25);
            this.cmbBillable1.TabIndex = 1053;
            this.cmbBillable1.Visible = false;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Enabled = false;
            this.label29.Location = new System.Drawing.Point(1066, 122);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(54, 17);
            this.label29.TabIndex = 1025;
            this.label29.Text = "Charge";
            this.label29.Visible = false;
            // 
            // cmbCharge1
            // 
            this.cmbCharge1.Enabled = false;
            this.cmbCharge1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCharge1.FormattingEnabled = true;
            this.cmbCharge1.Items.AddRange(new object[] {
            "",
            "N/C",
            "ABUSE",
            "DOW"});
            this.cmbCharge1.Location = new System.Drawing.Point(1070, 141);
            this.cmbCharge1.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCharge1.Name = "cmbCharge1";
            this.cmbCharge1.Size = new System.Drawing.Size(106, 25);
            this.cmbCharge1.TabIndex = 20;
            this.cmbCharge1.Visible = false;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Enabled = false;
            this.label32.Location = new System.Drawing.Point(1002, 120);
            this.label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(59, 17);
            this.label32.TabIndex = 1012;
            this.label32.Text = "Solution";
            this.label32.Visible = false;
            // 
            // cmbSol1
            // 
            this.cmbSol1.Enabled = false;
            this.cmbSol1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSol1.FormattingEnabled = true;
            this.cmbSol1.Location = new System.Drawing.Point(1009, 141);
            this.cmbSol1.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSol1.Name = "cmbSol1";
            this.cmbSol1.Size = new System.Drawing.Size(49, 25);
            this.cmbSol1.TabIndex = 19;
            this.cmbSol1.Text = "#";
            this.cmbSol1.Visible = false;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(20, 30);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(124, 17);
            this.label22.TabIndex = 4;
            this.label22.Text = "Scan Part Number";
            // 
            // txtPN1
            // 
            this.txtPN1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPN1.Location = new System.Drawing.Point(24, 51);
            this.txtPN1.Margin = new System.Windows.Forms.Padding(4);
            this.txtPN1.Name = "txtPN1";
            this.txtPN1.Size = new System.Drawing.Size(246, 26);
            this.txtPN1.TabIndex = 3;
            this.txtPN1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPN1_KeyDown);
            this.txtPN1.Leave += new System.EventHandler(this.txtPN1_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblFound);
            this.groupBox1.Controls.Add(this.lblModel);
            this.groupBox1.Controls.Add(this.label38);
            this.groupBox1.Controls.Add(this.txtCustomerName);
            this.groupBox1.Controls.Add(this.label28);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.txtSerialNum);
            this.groupBox1.Controls.Add(this.txtModel);
            this.groupBox1.Controls.Add(this.txtSR);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(15, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1478, 81);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1. Service Request Information";
            // 
            // lblFound
            // 
            this.lblFound.AutoSize = true;
            this.lblFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFound.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblFound.Location = new System.Drawing.Point(135, 58);
            this.lblFound.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFound.Name = "lblFound";
            this.lblFound.Size = new System.Drawing.Size(109, 17);
            this.lblFound.TabIndex = 19;
            this.lblFound.Text = "Estimate Found!";
            this.lblFound.Visible = false;
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblModel.Location = new System.Drawing.Point(745, 58);
            this.lblModel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(0, 17);
            this.lblModel.TabIndex = 18;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(920, 30);
            this.label38.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(68, 17);
            this.label38.TabIndex = 17;
            this.label38.Text = "Customer";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.Location = new System.Drawing.Point(986, 24);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(469, 29);
            this.txtCustomerName.TabIndex = 16;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(612, 30);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(98, 17);
            this.label28.TabIndex = 15;
            this.label28.Text = "Serial Number";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(246, 29);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(60, 17);
            this.label27.TabIndex = 14;
            this.label27.Text = "Item No.";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(96, 29);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(27, 17);
            this.label26.TabIndex = 13;
            this.label26.Text = "SR";
            // 
            // txtSerialNum
            // 
            this.txtSerialNum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSerialNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerialNum.Location = new System.Drawing.Point(712, 24);
            this.txtSerialNum.Margin = new System.Windows.Forms.Padding(4);
            this.txtSerialNum.Name = "txtSerialNum";
            this.txtSerialNum.Size = new System.Drawing.Size(194, 29);
            this.txtSerialNum.TabIndex = 2;
            this.txtSerialNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSerialNum_KeyDown);
            this.txtSerialNum.Leave += new System.EventHandler(this.txtSerialNum_Leave);
            // 
            // txtModel
            // 
            this.txtModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModel.Location = new System.Drawing.Point(312, 24);
            this.txtModel.Margin = new System.Windows.Forms.Padding(4);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(293, 29);
            this.txtModel.TabIndex = 1;
            // 
            // txtSR
            // 
            this.txtSR.BackColor = System.Drawing.SystemColors.Window;
            this.txtSR.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSR.Location = new System.Drawing.Point(131, 24);
            this.txtSR.Margin = new System.Windows.Forms.Padding(4);
            this.txtSR.Name = "txtSR";
            this.txtSR.Size = new System.Drawing.Size(106, 29);
            this.txtSR.TabIndex = 0;
            this.txtSR.TextChanged += new System.EventHandler(this.txtSR_TextChanged);
            this.txtSR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSR_KeyDown);
            this.txtSR.Leave += new System.EventHandler(this.txtSR_Leave);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.grpResults);
            this.tabPage2.Controls.Add(this.grpPartsSearch);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1513, 888);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Quicksearch";
            // 
            // grpResults
            // 
            this.grpResults.Controls.Add(this.label3);
            this.grpResults.Controls.Add(this.listPartsResults);
            this.grpResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpResults.Location = new System.Drawing.Point(36, 156);
            this.grpResults.Margin = new System.Windows.Forms.Padding(4);
            this.grpResults.Name = "grpResults";
            this.grpResults.Padding = new System.Windows.Forms.Padding(4);
            this.grpResults.Size = new System.Drawing.Size(1244, 662);
            this.grpResults.TabIndex = 1;
            this.grpResults.TabStop = false;
            this.grpResults.Text = "2. Results";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(488, 359);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Double Click to add to Generator";
            // 
            // listPartsResults
            // 
            this.listPartsResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listPartsResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listPartsResults.FullRowSelect = true;
            this.listPartsResults.GridLines = true;
            this.listPartsResults.Location = new System.Drawing.Point(8, 24);
            this.listPartsResults.Margin = new System.Windows.Forms.Padding(4);
            this.listPartsResults.Name = "listPartsResults";
            this.listPartsResults.Size = new System.Drawing.Size(1228, 332);
            this.listPartsResults.TabIndex = 0;
            this.listPartsResults.UseCompatibleStateImageBehavior = false;
            this.listPartsResults.View = System.Windows.Forms.View.Details;
            this.listPartsResults.DoubleClick += new System.EventHandler(this.listPartsResults_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Part Number";
            this.columnHeader1.Width = 203;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Part Name";
            this.columnHeader2.Width = 614;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Price";
            this.columnHeader3.Width = 90;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "In Stock";
            // 
            // grpPartsSearch
            // 
            this.grpPartsSearch.Controls.Add(this.label1);
            this.grpPartsSearch.Controls.Add(this.btnPartNumClear);
            this.grpPartsSearch.Controls.Add(this.label18);
            this.grpPartsSearch.Controls.Add(this.txtPartNum);
            this.grpPartsSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPartsSearch.Location = new System.Drawing.Point(36, 36);
            this.grpPartsSearch.Margin = new System.Windows.Forms.Padding(4);
            this.grpPartsSearch.Name = "grpPartsSearch";
            this.grpPartsSearch.Padding = new System.Windows.Forms.Padding(4);
            this.grpPartsSearch.Size = new System.Drawing.Size(1244, 112);
            this.grpPartsSearch.TabIndex = 0;
            this.grpPartsSearch.TabStop = false;
            this.grpPartsSearch.Text = "1. Search";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(658, 86);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Press Enter to Search";
            // 
            // btnPartNumClear
            // 
            this.btnPartNumClear.FlatAppearance.BorderSize = 0;
            this.btnPartNumClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPartNumClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPartNumClear.Location = new System.Drawing.Point(805, 48);
            this.btnPartNumClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnPartNumClear.Name = "btnPartNumClear";
            this.btnPartNumClear.Size = new System.Drawing.Size(40, 29);
            this.btnPartNumClear.TabIndex = 2;
            this.btnPartNumClear.Text = "X";
            this.btnPartNumClear.UseVisualStyleBackColor = true;
            this.btnPartNumClear.Click += new System.EventHandler(this.btnPartNumClear_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(360, 24);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(150, 17);
            this.label18.TabIndex = 1;
            this.label18.Text = "Part Number or Name:";
            // 
            // txtPartNum
            // 
            this.txtPartNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPartNum.Location = new System.Drawing.Point(364, 44);
            this.txtPartNum.Margin = new System.Windows.Forms.Padding(4);
            this.txtPartNum.Name = "txtPartNum";
            this.txtPartNum.Size = new System.Drawing.Size(433, 37);
            this.txtPartNum.TabIndex = 0;
            this.txtPartNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPartNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartNum_KeyDown);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.lstNoChelmsford);
            this.tabPage1.Controls.Add(this.btnEditNeverGoes);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.lstCycler);
            this.tabPage1.Controls.Add(this.btnEditCycler);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.lstNoCharge);
            this.tabPage1.Controls.Add(this.btnEditNoCharge);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1513, 888);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(488, 48);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(207, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Items never goes to Chelmsford";
            // 
            // lstNoChelmsford
            // 
            this.lstNoChelmsford.FormattingEnabled = true;
            this.lstNoChelmsford.ItemHeight = 17;
            this.lstNoChelmsford.Location = new System.Drawing.Point(491, 68);
            this.lstNoChelmsford.Margin = new System.Windows.Forms.Padding(2);
            this.lstNoChelmsford.Name = "lstNoChelmsford";
            this.lstNoChelmsford.Size = new System.Drawing.Size(220, 259);
            this.lstNoChelmsford.TabIndex = 7;
            // 
            // btnEditNeverGoes
            // 
            this.btnEditNeverGoes.Location = new System.Drawing.Point(588, 349);
            this.btnEditNeverGoes.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditNeverGoes.Name = "btnEditNeverGoes";
            this.btnEditNeverGoes.Size = new System.Drawing.Size(124, 30);
            this.btnEditNeverGoes.TabIndex = 6;
            this.btnEditNeverGoes.Text = "Edit";
            this.btnEditNeverGoes.UseVisualStyleBackColor = true;
            this.btnEditNeverGoes.Click += new System.EventHandler(this.btnEditNeverGoes_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(262, 48);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Items trigger \"Cycler\"";
            // 
            // lstCycler
            // 
            this.lstCycler.FormattingEnabled = true;
            this.lstCycler.ItemHeight = 17;
            this.lstCycler.Location = new System.Drawing.Point(265, 68);
            this.lstCycler.Margin = new System.Windows.Forms.Padding(2);
            this.lstCycler.Name = "lstCycler";
            this.lstCycler.Size = new System.Drawing.Size(220, 259);
            this.lstCycler.TabIndex = 4;
            // 
            // btnEditCycler
            // 
            this.btnEditCycler.Location = new System.Drawing.Point(361, 349);
            this.btnEditCycler.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditCycler.Name = "btnEditCycler";
            this.btnEditCycler.Size = new System.Drawing.Size(124, 30);
            this.btnEditCycler.TabIndex = 3;
            this.btnEditCycler.Text = "Edit";
            this.btnEditCycler.UseVisualStyleBackColor = true;
            this.btnEditCycler.Click += new System.EventHandler(this.btnEditCycler_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 48);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Items always \"No Charge\"";
            // 
            // lstNoCharge
            // 
            this.lstNoCharge.FormattingEnabled = true;
            this.lstNoCharge.ItemHeight = 17;
            this.lstNoCharge.Location = new System.Drawing.Point(39, 68);
            this.lstNoCharge.Margin = new System.Windows.Forms.Padding(2);
            this.lstNoCharge.Name = "lstNoCharge";
            this.lstNoCharge.Size = new System.Drawing.Size(220, 259);
            this.lstNoCharge.TabIndex = 1;
            // 
            // btnEditNoCharge
            // 
            this.btnEditNoCharge.Location = new System.Drawing.Point(135, 349);
            this.btnEditNoCharge.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditNoCharge.Name = "btnEditNoCharge";
            this.btnEditNoCharge.Size = new System.Drawing.Size(124, 30);
            this.btnEditNoCharge.TabIndex = 0;
            this.btnEditNoCharge.Text = "Edit";
            this.btnEditNoCharge.UseVisualStyleBackColor = true;
            this.btnEditNoCharge.Click += new System.EventHandler(this.btnEditNoCharge_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1521, 918);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Repair Generator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.grpGenerate.ResumeLayout(false);
            this.grpGenerate.PerformLayout();
            this.grpProblems.ResumeLayout(false);
            this.grpProblems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProblems)).EndInit();
            this.grpParts.ResumeLayout(false);
            this.grpParts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParts)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.grpResults.ResumeLayout(false);
            this.grpResults.PerformLayout();
            this.grpPartsSearch.ResumeLayout(false);
            this.grpPartsSearch.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox grpPartsSearch;
        private System.Windows.Forms.Button btnPartNumClear;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtPartNum;
        private System.Windows.Forms.GroupBox grpResults;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtPN1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtSerialNum;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtSR;
        private System.Windows.Forms.GroupBox grpParts;
        private System.Windows.Forms.ComboBox cmbSol1;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.GroupBox grpProblems;
        private System.Windows.Forms.TextBox txtProb1;
        private System.Windows.Forms.ComboBox cmbStatus1;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ComboBox cmbCharge1;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox txtTechName;
        private System.Windows.Forms.GroupBox grpGenerate;
        private System.Windows.Forms.TextBox txtOne;
        private System.Windows.Forms.ListView listPartsResults;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBillable1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label lblFound;
        private System.Windows.Forms.DataGridView dgvParts;
        private System.Windows.Forms.RadioButton radMoveCycler;
        private System.Windows.Forms.RadioButton radMovePM;
        private System.Windows.Forms.DataGridView dgvProblems;
        private System.Windows.Forms.CheckBox chkAccessoriesRequired;
        private System.Windows.Forms.Button btnPreset1;
        private System.Windows.Forms.Button btnPreset2;
        private System.Windows.Forms.Button btnPreset4;
        private System.Windows.Forms.Button btnPreset3;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstNoCharge;
        private System.Windows.Forms.Button btnEditNoCharge;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lstNoChelmsford;
        private System.Windows.Forms.Button btnEditNeverGoes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lstCycler;
        private System.Windows.Forms.Button btnEditCycler;
        private System.Windows.Forms.Button btnEstimate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewComboBoxColumn Status;
        private System.Windows.Forms.DataGridViewButtonColumn Remove;
        private System.Windows.Forms.DataGridViewButtonColumn PossibleRepairs;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldSerial;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldRev;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewSerial;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewRev;
        private System.Windows.Forms.DataGridViewComboBoxColumn SolutionNum;
        private System.Windows.Forms.DataGridViewComboBoxColumn Charge;
        private System.Windows.Forms.DataGridViewButtonColumn RemovePart;
    }
}

