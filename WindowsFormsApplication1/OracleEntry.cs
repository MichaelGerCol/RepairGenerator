using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class OracleEntry : Form
    {
        string SR;

        public OracleEntry()
        {
            InitializeComponent();
        }

        public OracleEntry(string input_copy,string model, string input_SR)
        {
            InitializeComponent();

            txtCopy.Text = input_copy;
            this.SR = input_SR;

            bool found = false;
            string[] filenames = Directory.GetFileSystemEntries(@"T:\! SR FOLDERS\" + SR + "\\");

            foreach (string S in filenames)
            {
                if (S.ToUpper().Contains(".PCC") || S.ToUpper().Contains("ZOLLCONFIG") || S.ToUpper().Contains("CFG"))
                {
                    found = true;
                    break;
                }
            }

            if (found != true)
            {
                txtCopy.Text = txtCopy.Text + Environment.NewLine + Environment.NewLine + "The customer's config was recorded after the repair process.";
            }
            
            try
            {
                var reader = new StreamReader("accommodation.txt");

                List<string> parts = new List<string>();

                while (!reader.EndOfStream)
                {
                    parts.Add(reader.ReadLine());
                }

                reader.Close();

                foreach(string S in parts)
                {
                    if (input_copy.Contains(S))
                    {
                        MessageBox.Show("Detected an accommodation part!\nPlease remember to add \"..as a customer accommodation..\" to the resolution.");
                        break;
                    }
                }

                PopulateFinalChecks(model);
            }
            catch
            {
                MessageBox.Show("Could not check for accommodations. Please check the parts manually.");
            }
        }

        private void PopulateFinalChecks(string model)
        {
            bool found = false;
            string[] filenames = Directory.GetFileSystemEntries(@"T:\! SR FOLDERS\" + SR + "\\");

            foreach (string S in filenames)
            {
                if (S.ToUpper().Contains(".PCC") || S.ToUpper().Contains("ZOLLCONFIG") || S.ToUpper().Contains("CFG"))
                {
                    found = true;
                    break;
                }
            }

            if (found != true)
            {
                chkFinal.Items.Add("Save incoming config! (No incoming configuration was found)");
            }

            try
            {
                var reader = new StreamReader(model.ToUpper() + "_FinalChecks.txt");
                while (!reader.EndOfStream)
                {
                    chkFinal.Items.Add(reader.ReadLine());
                }
                reader.Close();
            }
            catch
            {
                MessageBox.Show("Could not get Final Checks for this product.");
                btnMove.Enabled = true;
                txtCopy.Enabled = true;
            }

            
        }

        private void OracleEntry_Load(object sender, EventArgs e)
        {

        }

        private void chkFinal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkFinal.CheckedItems.Count == chkFinal.Items.Count)
            {
                btnMove.Enabled = true;
                txtCopy.Enabled = true;
            }
            else
            {
                btnMove.Enabled = false;
                txtCopy.Enabled = false;
            }
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.Form1 myform = Application.OpenForms.Cast<WindowsFormsApplication1.Form1>().First();
            myform.MoveOnKanban();

            this.Close();
        }
    }
}
