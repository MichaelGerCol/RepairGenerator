namespace WindowsFormsApplication1
{
    partial class PossibleRepairs
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
            this.txtProblem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbModel = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvPossibleRepair = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkPartNames = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPossibleRepair)).BeginInit();
            this.SuspendLayout();
            // 
            // txtProblem
            // 
            this.txtProblem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtProblem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtProblem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProblem.Location = new System.Drawing.Point(172, 65);
            this.txtProblem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtProblem.Name = "txtProblem";
            this.txtProblem.Size = new System.Drawing.Size(624, 22);
            this.txtProblem.TabIndex = 0;
            this.txtProblem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProblem_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 69);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Problem Description";
            // 
            // cmbModel
            // 
            this.cmbModel.FormattingEnabled = true;
            this.cmbModel.Items.AddRange(new object[] {
            "E-SERIES",
            "M-SERIES",
            "CCT",
            "R-SERIES",
            "X-SERIES",
            "PROPAQ",
            "AED-PLUS",
            "AED-PRO",
            "AUTOPULSE"});
            this.cmbModel.Location = new System.Drawing.Point(172, 32);
            this.cmbModel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbModel.Name = "cmbModel";
            this.cmbModel.Size = new System.Drawing.Size(223, 24);
            this.cmbModel.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(116, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Model";
            // 
            // dgvPossibleRepair
            // 
            this.dgvPossibleRepair.AllowUserToAddRows = false;
            this.dgvPossibleRepair.AllowUserToDeleteRows = false;
            this.dgvPossibleRepair.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPossibleRepair.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPossibleRepair.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dgvPossibleRepair.Location = new System.Drawing.Point(33, 127);
            this.dgvPossibleRepair.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvPossibleRepair.Name = "dgvPossibleRepair";
            this.dgvPossibleRepair.ReadOnly = true;
            this.dgvPossibleRepair.Size = new System.Drawing.Size(777, 427);
            this.dgvPossibleRepair.TabIndex = 4;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Possible Repairs";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // chkPartNames
            // 
            this.chkPartNames.AutoSize = true;
            this.chkPartNames.Checked = true;
            this.chkPartNames.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPartNames.Location = new System.Drawing.Point(172, 98);
            this.chkPartNames.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkPartNames.Name = "chkPartNames";
            this.chkPartNames.Size = new System.Drawing.Size(130, 21);
            this.chkPartNames.TabIndex = 5;
            this.chkPartNames.Text = "Use part names";
            this.chkPartNames.UseVisualStyleBackColor = true;
            this.chkPartNames.CheckedChanged += new System.EventHandler(this.chkPartNames_CheckedChanged);
            // 
            // PossibleRepairs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 586);
            this.Controls.Add(this.chkPartNames);
            this.Controls.Add(this.dgvPossibleRepair);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbModel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtProblem);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PossibleRepairs";
            this.Text = "Repair Possibilities";
            this.Load += new System.EventHandler(this.PossibleRepairs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPossibleRepair)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtProblem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbModel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvPossibleRepair;
        private System.Windows.Forms.CheckBox chkPartNames;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}