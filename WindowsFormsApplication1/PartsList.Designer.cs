namespace WindowsFormsApplication1
{
    partial class PartsList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPartsList = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.chkSignedOut = new System.Windows.Forms.CheckBox();
            this.PartNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Serial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoveTo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.OldSerial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OldRev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Print = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartsList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPartsList
            // 
            this.dgvPartsList.AllowUserToAddRows = false;
            this.dgvPartsList.AllowUserToDeleteRows = false;
            this.dgvPartsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPartsList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PartNum,
            this.Quantity,
            this.Serial,
            this.PartName,
            this.MoveTo,
            this.OldSerial,
            this.OldRev,
            this.Print});
            this.dgvPartsList.Location = new System.Drawing.Point(16, 73);
            this.dgvPartsList.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPartsList.MultiSelect = false;
            this.dgvPartsList.Name = "dgvPartsList";
            this.dgvPartsList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvPartsList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvPartsList.Size = new System.Drawing.Size(789, 368);
            this.dgvPartsList.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(169, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(450, 54);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sign out these parts!";
            // 
            // btnFinish
            // 
            this.btnFinish.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnFinish.Enabled = false;
            this.btnFinish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinish.Location = new System.Drawing.Point(649, 501);
            this.btnFinish.Margin = new System.Windows.Forms.Padding(4);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(156, 34);
            this.btnFinish.TabIndex = 2;
            this.btnFinish.Text = "Finish";
            this.btnFinish.UseVisualStyleBackColor = false;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Orange;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Location = new System.Drawing.Point(485, 501);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(156, 34);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "Print Labels";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // chkSignedOut
            // 
            this.chkSignedOut.AutoSize = true;
            this.chkSignedOut.Location = new System.Drawing.Point(592, 461);
            this.chkSignedOut.Name = "chkSignedOut";
            this.chkSignedOut.Size = new System.Drawing.Size(213, 21);
            this.chkSignedOut.TabIndex = 4;
            this.chkSignedOut.Text = "All parts signed out of Oracle";
            this.chkSignedOut.UseVisualStyleBackColor = true;
            this.chkSignedOut.CheckedChanged += new System.EventHandler(this.chkSignedOut_CheckedChanged);
            // 
            // PartNum
            // 
            this.PartNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PartNum.HeaderText = "Part Num";
            this.PartNum.Name = "PartNum";
            this.PartNum.Width = 96;
            // 
            // Quantity
            // 
            this.Quantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Quantity.DefaultCellStyle = dataGridViewCellStyle2;
            this.Quantity.HeaderText = "Qty";
            this.Quantity.Name = "Quantity";
            this.Quantity.Width = 59;
            // 
            // Serial
            // 
            this.Serial.HeaderText = "New Serial";
            this.Serial.Name = "Serial";
            // 
            // PartName
            // 
            this.PartName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PartName.HeaderText = "Part Name";
            this.PartName.Name = "PartName";
            // 
            // MoveTo
            // 
            this.MoveTo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MoveTo.HeaderText = "Move To";
            this.MoveTo.Items.AddRange(new object[] {
            "SCRAP BIN",
            "NON-WARRANTY BIN",
            "CHELMSFORD BIN"});
            this.MoveTo.Name = "MoveTo";
            this.MoveTo.Width = 62;
            // 
            // OldSerial
            // 
            this.OldSerial.HeaderText = "OldSerial";
            this.OldSerial.Name = "OldSerial";
            this.OldSerial.Visible = false;
            // 
            // OldRev
            // 
            this.OldRev.HeaderText = "OldRev";
            this.OldRev.Name = "OldRev";
            this.OldRev.Visible = false;
            // 
            // Print
            // 
            this.Print.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Print.HeaderText = "Print?";
            this.Print.Name = "Print";
            this.Print.Width = 51;
            // 
            // PartsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 557);
            this.ControlBox = false;
            this.Controls.Add(this.chkSignedOut);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvPartsList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PartsList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sign out";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PartsList_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PartsList_FormClosed);
            this.Load += new System.EventHandler(this.PartsList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartsList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPartsList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serial;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartName;
        private System.Windows.Forms.DataGridViewComboBoxColumn MoveTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldSerial;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldRev;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Print;
        private System.Windows.Forms.CheckBox chkSignedOut;
    }
}