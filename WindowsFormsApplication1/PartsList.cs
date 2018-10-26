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
using System.Diagnostics;
using System.Globalization;
using System.Drawing.Printing;
using System.Drawing.Text;
using Novacode;

namespace WindowsFormsApplication1
{
    public partial class PartsList : Form
    {
        List<string> NeverGoesList = new List<string>();
        List<string> partslist = new List<string>();
        List<DataGridViewRow> partsused = new List<DataGridViewRow>();
        List<string> printable = new List<string>();

        string SR = "";
        string SN = "";
        string model = "";

        public PartsList()
        {
            InitializeComponent();
        }

        public PartsList(DataGridViewRowCollection rows, string inputSR, string inputSN,string inputModel)
        {
            InitializeComponent();

            this.SR = inputSR;
            this.SN = inputSN;
            this.model = inputModel;
            
            foreach(DataGridViewRow r in rows)
            {
                this.partsused.Add(r);
            }

            var partsreader = new StreamReader(@"T:\Databases\Parts_List.csv");
            while (!partsreader.EndOfStream)
            {
                partslist.Add(partsreader.ReadLine());
            }
            partsreader.Close();

            foreach (DataGridViewRow dgvr in rows)
            {
                int quantity = 1;

                if(((string)dgvr.Cells[1].Value).Contains(" x "))
                {
                    var values = ((string)dgvr.Cells[1].Value).Split(' ');
                    quantity = Int32.Parse(values[values.Length - 1]);
                }

                string destination = "";
                string pn = (string)dgvr.Cells[0].Value;
                
                    foreach (string s in partslist)
                    {
                        if (s.Contains(pn))
                        {
                            var values = s.Split(',');
                            if (values[8] == "N" && (string)dgvr.Cells[2].Value=="")
                            {
                                destination = "SCRAP BIN";
                            }
                            break;
                        }
                    }

                string[] t_row = { ((string)dgvr.Cells[0].Value).ToString(), quantity.ToString(), ((string)dgvr.Cells[4].Value).ToString(), ((string)dgvr.Cells[1].Value).ToString(), destination, ((string)dgvr.Cells[2].Value).ToString(), ((string)dgvr.Cells[3].Value).ToString() };
                
                dgvPartsList.Rows.Add(t_row);
            }

            WindowsFormsApplication1.Form1 myform = Application.OpenForms.Cast<WindowsFormsApplication1.Form1>().First();
            myform.Enabled = false;
        }

        public PartsList(List<DataGridViewRow> input)
        {

        }

        private void PartsList_Load(object sender, EventArgs e)
        {

            var reader = new StreamReader("never_goes.txt");
            while (!reader.EndOfStream)
            {
                NeverGoesList.Add(reader.ReadLine());
            }
            reader.Close();

            
        }

        private void PartsList_FormClosing(object sender, FormClosingEventArgs e)
        {
            WindowsFormsApplication1.Form1 myform = Application.OpenForms.Cast<WindowsFormsApplication1.Form1>().First();
            myform.Enabled = true;
        }

        private void PartsList_FormClosed(object sender, FormClosedEventArgs e)
        {
            WindowsFormsApplication1.Form1 myform = Application.OpenForms.Cast<WindowsFormsApplication1.Form1>().First();
            myform.Enabled = true;
        }

        private void PartsToChelmsford()
        {
            DateTime dt = DateTime.Today;
            while (dt.DayOfWeek != DayOfWeek.Sunday)
            {
                dt = dt.AddDays(-1);
            }
            string path = @"T:\Shipments\_FIR_Parts to Chelmsford\Weekly Returns to Chelmsford\Week of " + dt.AddDays(8).Date.ToString("yyyy-MM-dd") + " - Returns.csv";
            bool file_found = File.Exists(path);
            List<string> returning_parts = new List<string>();

            if (file_found)
            {
                var reader = new StreamReader(path);
                while (!reader.EndOfStream)
                {
                    returning_parts.Add(reader.ReadLine());
                }
                reader.Close();
            }

            var writer = new StreamWriter(path, file_found);
            if (!file_found)
            {
                writer.WriteLine("Date,SR Number,Part Description,Part Num and Serial Num,Model,Location,Tracking Number");
            }

            foreach (DataGridViewRow lvi in dgvPartsList.Rows)
            {
                if ((string)lvi.Cells["MoveTo"].Value== "CHELMSFORD BIN")
                {
                    bool found = false;
                    foreach (string S in returning_parts)
                    {
                        if (S.Contains("SR " + this.SR + "," + (string)lvi.Cells["PartName"].Value + ",PN: " + (string)lvi.Cells["PartNum"].Value + "   SN: " +(string)lvi.Cells["Serial"].Value))
                        {
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        writer.WriteLine(dt.AddDays(8).ToString("MMMM d yyyy") + ",SR " + this.SR + "," + (string)lvi.Cells["PartName"].Value + ",PN: " + (string)lvi.Cells["PartNum"].Value + "   SN: " + (string)lvi.Cells["OldSerial"].Value + " Rev " + (string)lvi.Cells["OldRev"].Value + "," + this.model + ",ZOLL Canada");
                    }
                }
                else if((string)lvi.Cells["MoveTo"].Value== "NON-WARRANTY BIN")
                {
                    var nwbwriter = new StreamWriter("NON-WARRANTY BIN.csv",true);
                    nwbwriter.WriteLine(dt.AddDays(8).ToString("MMMM d yyyy") + ",SR " + this.SR + "," + (string)lvi.Cells["PartName"].Value + ",PN: " + (string)lvi.Cells["PartNum"].Value + "   SN: " + (string)lvi.Cells["OldSerial"].Value + " Rev " + (string)lvi.Cells["OldRev"].Value + "," + this.model + ",ZOLL Canada");
                    nwbwriter.Close();
                }
            }
            writer.Close();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow dgvr in dgvPartsList.Rows)
            {
                if ((string)dgvr.Cells["MoveTo"].Value == "")
                {
                    MessageBox.Show("Please select all MoveTo boxes!");
                    return;
                }
            }

            PartsToChelmsford();

            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow dgvr in dgvPartsList.Rows)
            {
                if (Convert.ToBoolean(dgvr.Cells["Print"].Value))
                {
                    printable.Add((string)dgvr.Cells["PartName"].Value + "|PN: " + (string)dgvr.Cells["PartNum"].Value + " - SN: " + (string)dgvr.Cells["OldSerial"].Value+" - Rev "+(string)dgvr.Cells["OldRev"].Value);
                }
            }

            PrintTextBoxContent();
        }

        private void PrintTextBoxContent()
        {
            #region Printer Selection
            PrintDialog printDlg = new PrintDialog();
            #endregion

            #region Create Document
            PrintDocument printDoc = new PrintDocument();
                printDoc.PrintPage += printDoc_PrintPage;
            printDlg.Document = printDoc;
            #endregion

            if (printDlg.ShowDialog() == DialogResult.OK)
                printDoc.Print();
        }

        void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            string line = printable[0];
            string part_name = line.Split('|')[0];
            string part_num = line.Split('|')[1];
            printable.RemoveAt(0);

            Font med_text = new Font("Microsoft Sans Serif", 10);
            Font smaller_text = new Font("Microsoft Sans Serif", 8);

            e.Graphics.DrawString("SR: " + this.SR, med_text, Brushes.Black, 0, 0);
            e.Graphics.DrawString("SN: " + this.SN, smaller_text, Brushes.Black, 0, 16);
            
            e.Graphics.DrawString(part_name, med_text, Brushes.Black, 0, 38);
            e.Graphics.DrawString(part_num, smaller_text, Brushes.Black, 0, 52);

            e.Graphics.DrawString(DateTime.Now.ToString("yyyy/MM/dd"), smaller_text, Brushes.Black, 0, 80);

            e.HasMorePages = (printable.Count > 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintTextBoxContent();
        }

        private void chkSignedOut_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSignedOut.Checked == true)
            {
                btnFinish.Enabled = true;
            }else
            {
                btnFinish.Enabled = false;
            }
        }
    }
}
