namespace WindowsFormsApplication1
{
    partial class OracleEntry
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
            this.txtCopy = new System.Windows.Forms.TextBox();
            this.btnMove = new System.Windows.Forms.Button();
            this.chkFinal = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // txtCopy
            // 
            this.txtCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCopy.BackColor = System.Drawing.Color.DarkGray;
            this.txtCopy.Enabled = false;
            this.txtCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCopy.Location = new System.Drawing.Point(16, 172);
            this.txtCopy.Margin = new System.Windows.Forms.Padding(4);
            this.txtCopy.Multiline = true;
            this.txtCopy.Name = "txtCopy";
            this.txtCopy.Size = new System.Drawing.Size(904, 271);
            this.txtCopy.TabIndex = 0;
            // 
            // btnMove
            // 
            this.btnMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMove.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnMove.Enabled = false;
            this.btnMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMove.Location = new System.Drawing.Point(711, 450);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(206, 33);
            this.btnMove.TabIndex = 1;
            this.btnMove.Text = "Move on Kanban";
            this.btnMove.UseVisualStyleBackColor = false;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // chkFinal
            // 
            this.chkFinal.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkFinal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkFinal.CheckOnClick = true;
            this.chkFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFinal.FormattingEnabled = true;
            this.chkFinal.Location = new System.Drawing.Point(170, 12);
            this.chkFinal.Name = "chkFinal";
            this.chkFinal.Size = new System.Drawing.Size(646, 153);
            this.chkFinal.TabIndex = 2;
            this.chkFinal.SelectedIndexChanged += new System.EventHandler(this.chkFinal_SelectedIndexChanged);
            // 
            // OracleEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(929, 495);
            this.Controls.Add(this.chkFinal);
            this.Controls.Add(this.btnMove);
            this.Controls.Add(this.txtCopy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OracleEntry";
            this.Text = "OracleEntry";
            this.Load += new System.EventHandler(this.OracleEntry_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCopy;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.CheckedListBox chkFinal;
    }
}