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
using Novacode;



namespace WindowsFormsApplication1
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        string model = "";
        int lowPrice=-0;
        int highPrice=0;
        
        int BoxSelect = 1;
        int dupes = 0;
        

        List<string> PartsList = new List<string>();

        private void ReadPartsToList()
        {
            PartsList.Clear();
            try
            {
                var reader = new StreamReader(File.OpenRead(@"T:\Databases\Parts_List.csv"));
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    PartsList.Add(line);
                    
                }
                reader.Close();
            }
            catch
            {
                MessageBox.Show("Parts_List.csv currently in use. Try refreshing.");
            }
        }

        private void ReadParts()
        {

            //var reader = new StreamReader(File.OpenRead("Parts_List.csv"));
                //var reader = new StreamReader(File.OpenRead(Properties.Resources.E_parts));
                List<string> listA = new List<string>();
                List<string> listB = new List<string>();
                List<string> listC = new List<string>();
                List<string> listD = new List<string>();

                foreach (string item in PartsList)
                {
                    
                    var values = item.Split(',');

                    listA.Add(values[0]);
                    listB.Add(values[2]+" "+values[1]);
                    listC.Add("$"+values[3]);
                    listD.Add(values[4]);
                }

            listPartsResults.Items.Clear();

                for(int i = 0; i < listA.Count; i++)
                {
                    listPartsResults.Items.Add(listA[i]);
                listPartsResults.Items[i].SubItems.Add(listB[i]);
                listPartsResults.Items[i].SubItems.Add(listC[i]);
                listPartsResults.Items[i].SubItems.Add(listD[i]);
            }

               
        }
        
        /*================================================================
         * Tab 2 code
         * ==============================================================*/

        private void PartSearch()
        {
            //Change this to input problems instead of parts
            ReadParts();

            List<string> search = new List<string>();
            List<ListViewItem> resultsNum = new List<ListViewItem>();

            int i = 0;

            search.AddRange(txtPartNum.Text.ToUpper().Split(' ').ToArray());

            foreach (string q in search)
            {
                foreach (ListViewItem item in listPartsResults.Items)
                {
                    if (item.SubItems[0].Text.Contains(q) || item.SubItems[1].Text.Contains(q))
                    {
                        resultsNum.Add(item);
                    }
                }

                listPartsResults.Items.Clear();

                foreach (ListViewItem item in resultsNum)
                {
                    listPartsResults.Items.Add(item);
                }

                resultsNum.Clear();
            }
        }

        private void txtPartNum_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnPartNumClear_Click(object sender, EventArgs e)
        {
            ReadParts();
            txtPartNum.Clear();
        }
        
        private void listPartName_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listPartNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listPartPrice_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        

        private void listPartName_Enter(object sender, EventArgs e)
        {
            
        }
        
        private void listPartNum_MouseEnter(object sender, EventArgs e)
        {
           // listPartNum.Focus();
        }

        private void listPartPrice_MouseEnter(object sender, EventArgs e)
        {
            //listPartPrice.Focus();
        }

        private void listPartName_MouseEnter(object sender, EventArgs e)
        {
           // listPartName.Focus();
        }
        

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReadPartsToList();

            if (tabControl1.SelectedIndex == 1)
            {
                if (txtPartNum.Text == "")
                {
                    ReadParts();
                }
                    txtPartNum.Focus();
                
            }
            
        }

        

        //Repair Scanner Section!!
        //==============================================================================
        
        private void txtPN1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                SelectNextControl((Control)sender, true, true, true, true);

                txtPN1.Clear();
                cmbSol1.SelectedIndex = -1;
                cmbCharge1.SelectedIndex = -1;
                cmbBillable1.SelectedIndex = -1;
            }
        }
        

        private void GenerateOracleEntry()
        {
            string oraclefile = @"C:\Users\Public\OracleEntry.docx";

            // Create a document in memory:
            DocX doc = DocX.Create(oraclefile);

            //Oracle Entry Maker
            //============================================
            foreach (ListViewItem lvi in lvwProb.Items)
            {
                List<String> para1 = new List<string>();
                string problem1 = "";
                string repair1 = "";
                string stat1 = "";
                string tense1 = "";

                //Add problem
                if (lvi.SubItems[3].Text == "verified" || lvi.SubItems[3].Text == "observed but not verified" || lvi.SubItems[3].Text == "not observed")
                {
                    problem1 = "The problem of " + lvi.SubItems[2].Text + " was " + lvi.SubItems[3].Text + ". The ";
                }


                //Search replaced parts for ones that match the problem
                foreach(DataGridViewRow partlvi in dgvParts.Rows)
                {
                    if ((string)partlvi.Cells[6].Value == lvi.SubItems[0].Text)
                    {
                        if ((string)partlvi.Cells[4].Value != "")
                        {
                            para1.Add(partlvi.Cells[1].Value + " (PN: " + partlvi.Cells[0].Value + ", Old SN: " + partlvi.Cells[2].Value + " Rev " + partlvi.Cells[3].Value + ", New SN: " + partlvi.Cells[4].Value + " Rev " + partlvi.Cells[5].Value + ")");
                        }
                        else
                        {
                            para1.Add(partlvi.Cells[1].Value + " (PN: " + partlvi.Cells[0].Value + ")");
                        }
                    }
                }
                
                //If Status is "Failed PM", change the problem statement
                if (lvi.SubItems[3].Text == "failed PM") { problem1 = "During PM, the unit was found to " + lvi.SubItems[2].Text + ". The "; }

                for (int i = 0; i < para1.Count; i++)
                {
                    if (i < para1.Count - 2)
                    {
                        repair1 = repair1 + para1[i] + ", ";
                    }
                    else if (i == para1.Count - 2)
                    {
                        repair1 = repair1 + para1[i] + ", and ";
                    }
                    else if (i == para1.Count - 1)
                    {
                        repair1 = repair1 + para1[i];
                    }
                }

                //If status is "verified" or "failed PM"
                if (lvi.SubItems[3].Text == "verified" || lvi.SubItems[3].Text == "failed PM") { stat1 = "to remedy the problem."; }
                //If status is "not observed" or "observed not verified"
                if (lvi.SubItems[3].Text == "observed but not verified" || lvi.SubItems[3].Text == "not observed") { stat1 = "to reduce the probability of reoccurrence."; }

                //If status is "part of repair process"
                //if (ListStatus[i].SelectedIndex == 3) { stats[i] = "as part of the repair process."; }
                //If status is "ECO"
                //if (ListStatus[i].SelectedIndex == 4) { stats[i] = "as part of the ECOs"; }

                //Set the tense (for grammar!)
                if (para1.Count == 1) { tense1 = " was "; } else { tense1 = " were "; }


                //Put entire sentence together
                if (lvi.SubItems[3].Text == "replaced as part of repair process") { problem1 = "The following parts were replaced as part of the repair process: " + repair1; }
                else if (lvi.SubItems[3].Text == "ECO") { problem1 = "The following parts were replaced as part of the ECOs: " + repair1; }
                else { problem1 = problem1 + repair1 + tense1 + "replaced " + stat1; }



                //Insert paragraph into document
                doc.InsertParagraph(problem1);
                doc.InsertParagraph("");
            }
            
            // Save to the output directory:
                doc.Save();
        

            // Open in Word:
            Process.Start("WINWORD.EXE", oraclefile);

        }

        private void GenerateCoverSheet()
        {
            //COVER SHEET MAKER
            //=============================================
            // Grab a reference to our document template:
            DocX letter = DocX.Load("template.docx");

            if (Directory.Exists("T:\\! SR FOLDERS\\" + txtSR.Text + "\\") == false)
            {
                Directory.CreateDirectory("T:\\! SR FOLDERS\\" + txtSR.Text + "\\");
            }

            string outputFileName = @"T:\! SR FOLDERS\" +txtSR.Text+"\\"+ txtSR.Text + " - " + txtSerialNum.Text + " - " + txtCustomerName.Text + " - cover sheet - "+txtTechName.Text+".docx";
            
            // Perform the replace:

            foreach(DataGridViewRow lvi in dgvParts.Rows)
            {
                if ((string)lvi.Cells[8].Value == "N")
                {
                    dgvParts.Rows.Remove(dgvParts.SelectedRows[0]);
                }
            }

            int i= 0;
            foreach(DataGridViewRow lvi in dgvParts.Rows)
            {
                letter.ReplaceText("%partname"+(i+1)+"%", lvi.Cells[1].Value.ToString());
                letter.ReplaceText("%pn"+ (i + 1) + "%", lvi.Cells[0].Value.ToString());
                letter.ReplaceText("%sn" + (i + 1) + "%", lvi.Cells[4].Value.ToString());
                letter.ReplaceText("%rev" + (i + 1) + "%", lvi.Cells[5].Value.ToString());
                letter.ReplaceText("%charge" + (i + 1) + "%", lvi.Cells[7].Value.ToString());
                i++;
            }

            for (int j = 1; j < 13; j++)
            {
                letter.ReplaceText("%partname" + j + "%", "");
                letter.ReplaceText("%pn" + j + "%", "");
                letter.ReplaceText("%sn" + j + "%", "");
                letter.ReplaceText("%rev" + j+ "%", "");
                letter.ReplaceText("%charge" + j + "%", "");
            }

            
            letter.ReplaceText("%sr%", txtSR.Text);
            letter.ReplaceText("%item%", txtModel.Text);
            letter.ReplaceText("%serial%", txtSerialNum.Text);
            letter.ReplaceText("%tech%", txtTechName.Text);

            letter.ReplaceText("%date%", DateTime.Now.ToString("MMMM dd yyyy"));


            // Save as New filename:
            letter.SaveAs(outputFileName);

            // Open in word:
            Process.Start("WINWORD.EXE", "\"" + outputFileName + "\"");
        }

        private void Sign_Out_Parts()
        {
            var reader = new StreamReader(File.OpenRead(@"T:\Databases\Parts_List.csv"));

            List<string> ITEM = new List<string>();
            List<string> ITEM_DESCRIPTION = new List<string>();
            List<string> MODEL = new List<string>();
            List<int> PRICE = new List<int>();
            List<int> IN_STOCK = new List<int>();
            List<int> MIN = new List<int>();
            List<int> MAX = new List<int>();
            List<string> BILLABLE = new List<string>();

           

            for (int i = 1; i < PartsList.Count();i++ )
            {
                
                var values = PartsList[i].Split(',');

                ITEM.Add(values[0]);
                ITEM_DESCRIPTION.Add(values[1]);
                MODEL.Add(values[2]);
                PRICE.Add(Int32.Parse(values[3]));
                IN_STOCK.Add(Int32.Parse(values[4]));
                MIN.Add(Int32.Parse(values[5]));
                MAX.Add(Int32.Parse(values[6]));
                BILLABLE.Add(values[7]);
            }
            

            List<string> partslist = new List<string>();

            foreach(string[] lvi in dgvParts.Rows)
            {
                partslist.Add(lvi[0]);
            }

            var cal = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar;
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            string movement_filename = Environment.CurrentDirectory+"\\Parts Movement\\Parts_Movement - " + DateTime.Now.ToString("yyyy") + "-" + DateTime.Now.ToString("MMMM") + "- Week " + cal.GetWeekOfYear(DateTime.Today, dfi.CalendarWeekRule, dfi.FirstDayOfWeek).ToString() + ".csv";
            string yearlymovement = Environment.CurrentDirectory + "\\Parts Movement\\Parts_Movement - " + DateTime.Now.ToString("yyyy")+".csv";

            if (File.Exists(movement_filename) == false)
            {
                var init = new StreamWriter(movement_filename, true);
                init.WriteLine("Time,Part Number,Description,Model,Operation,Remaining Stock");
                init.Close();
            }

            if (File.Exists(yearlymovement) == false)
            {
                var init = new StreamWriter(yearlymovement, true);
                init.WriteLine("Time,Part Number,Description,Model,Operation,Remaining Stock");
                init.Close();
            }

            try {
                var record = new StreamWriter(movement_filename, true);
                var yearrecord = new StreamWriter(yearlymovement, true);

                foreach (string num in partslist)
                {
                    for (int i = 0; i < ITEM.Count(); i++)
                    {
                        if (ITEM[i] == num)
                        {
                            IN_STOCK[i] = IN_STOCK[i] - 1;
                            record.WriteLine(DateTime.Now.ToString() + "," + ITEM[i] + "," + ITEM_DESCRIPTION[i] + "," + MODEL[i] + ",OUT," + IN_STOCK[i]);
                            yearrecord.WriteLine(DateTime.Now.ToString() + "," + ITEM[i] + "," + ITEM_DESCRIPTION[i] + "," + MODEL[i] + ",OUT," + IN_STOCK[i]);
                            break;
                        }
                    }
                }
                record.Close();
                yearrecord.Close();
            }
            catch
            {
                MessageBox.Show("The Inventory Movements Record is currently open by a user. The items signed out will not be recorded!");
                return;
            }

            try
            {
                var writer = new StreamWriter(@"T:\Databases\Parts_List.csv");
                writer.WriteLine("PART NUM,DESCRIPTION,MODEL,PRICE,STOCK,MIN,MAX,BILLABLE");
                for (int i = 0; i < ITEM.Count(); i++)
                {
                    writer.WriteLine(ITEM[i] + "," + ITEM_DESCRIPTION[i] + "," + MODEL[i] + "," + PRICE[i] + "," + IN_STOCK[i] + "," + MIN[i] + "," + MAX[i] + "," + BILLABLE[i]);
                }
                writer.Close();
            }
            catch
            {
                MessageBox.Show("Parts_List.csv is currently in open. Items will not be signed out.");
                return;
            }
    }


        private bool CheckValidity()
        {
            foreach(ListViewItem lvi in lvwProb.Items)
            {
                if (lvi.SubItems[3].Text == "???")
                {
                    MessageBox.Show("Please select a valid status for each problem");
                    return false;
                }
            }

            return true;
        }

        private void EstimateFeedback()
        {
            if (lblFound.Visible == true)
            {
                foreach(ListViewItem lvi in lvwProb.Items)
                {
                    if (lvi.SubItems[3].Text == "verified")
                    {
                        string repair = "";

                        foreach(string[] partlvi in dgvParts.Rows)
                        {
                            if (partlvi[6] == lvi.SubItems[0].Text && partlvi[8]=="Y")
                            {
                                if (repair == "")
                                {
                                    repair = partlvi[0];
                                }
                                else
                                {
                                    repair = repair+"+"+partlvi[0];
                                }
                            }
                        }
                        
                        var reader = new StreamReader(@"T:\Databases\"+model + "_Problems.csv");
                        List<ListViewItem> problemdata = new List<ListViewItem>();
                        bool probentry = false;

                        while (!reader.EndOfStream)
                        {
                            var line=reader.ReadLine();
                            var values = line.Split(',');

                            ListViewItem entry = new ListViewItem(values[0]);

                            for(int i=1;i<values.Count();i++)
                            {
                                if (values[i] != "")
                                {
                                    entry.SubItems.Add(values[i]);
                                }
                            }

                            if (entry.SubItems[0].Text == lvi.SubItems[2].Text)
                            {
                                probentry = true;
                                bool found = false;

                                foreach(ListViewItem.ListViewSubItem p in entry.SubItems)
                                {
                                    if (p.Text == repair)
                                    {
                                        found = true;
                                    }
                                }

                                if(found== false)
                                {
                                    entry.SubItems.Add(repair);
                                }
                            }
                        
                            problemdata.Add(entry);
                        }
                        reader.Close();

                        if (probentry == false)
                        {
                            ListViewItem newentry = new ListViewItem(lvi.SubItems[2].Text);
                            newentry.SubItems.Add(repair.ToUpper());
                            problemdata.Add(newentry);
                        }

                        var writer = new StreamWriter(@"T:\Databases\"+model + "_Problems.csv");
                        

                        foreach (ListViewItem prob in problemdata)
                        {
                            string ent = "";

                            foreach (ListViewItem.ListViewSubItem parts in prob.SubItems)
                            {
                                if (ent == "")
                                {
                                    ent = parts.Text;
                                }
                                else
                                {
                                    ent = ent + "," + parts.Text;
                                }
                            }
                            writer.WriteLine(ent);
                        }

                        writer.Close();

                    }
                }
            }
        }

        private void CheckDirectory(string sr)
        {
            string path = @"T:\! SR FOLDERS\" + sr;

            if (Directory.Exists(path) == false)
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (!CheckValidity())
            {
                return;
            }
            
            CheckDirectory(txtSR.Text);
            string outputFileName = @"T:\! SR FOLDERS\" + txtSR.Text + "\\" + txtSR.Text +" - " + txtSerialNum.Text + " - " + txtCustomerName.Text + " - cover sheet - " + txtTechName.Text + ".docx";
            
            if (outputFileName.Contains("/")|| outputFileName.Contains("\"") || outputFileName.Contains("*") || outputFileName.Contains("<") || outputFileName.Contains(">") || outputFileName.Contains("|"))
            {
                MessageBox.Show("Please review the information in Step 1. Output filename can not contain illegal letters! Can not contain / \\ : * ? < > \" |");
                return;
            }
            
            try {
                GenerateOracleEntry();
            }
            catch
            {
                MessageBox.Show("There was an error generating the Oracle entry. Make sure to close all instances of OracleEntry.docx");
               return;
            }
            

            try
            {
                EstimateFeedback();
            }
            catch
            {
                MessageBox.Show("Error while providing estimate feedback");
            }

            
            try {
                GenerateCoverSheet();
            }
            catch
            {
                MessageBox.Show("There was an error generating the Cover Sheet. Make sure the cover sheet for SR " + txtSR.Text + " is not open.");
                return;
            }

            //Sign_Out_Parts();       
            
        }

        private void ClearAll()
        {
            // Clear Fields
            
            txtProb1.Clear();
            cmbStatus1.SelectedIndex = -1;
            lvwProb.Items.Clear();
            dgvParts.Rows.Clear();
                        
            txtSR.Clear();
            txtModel.Clear();
            txtSerialNum.Clear();
            txtCustomerName.Clear();

            txtPN1.Clear();
            cmbSol1.SelectedIndex = -1;
            cmbCharge1.SelectedIndex = -1;
            cmbBillable1.SelectedIndex = -1;

            lblFound.Visible = false;
            lblModel.Text = "";
            model = "";

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void txtSR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void txtModel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void txtSerialNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void txtCustomerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private bool CheckForAbuse(int i)
        {
            if (lvwProb.Items.Count > 0)
            {
                //Input list of words to look for in the problems to automatically switch to 'Abuse'
                List<string> Keywords = new List<string> { "damage", "torn", "puncture", "pierce", "cracked", "bent" };

                foreach (string word in Keywords)
                {
                    if (lvwProb.Items[i].SubItems[2].Text.ToLower().Contains(word))
                    {
                        return true;
                    }
                }
            }
            return false;

        }
            
        private void cmbSol1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSol1.SelectedIndex >= 0)
            {
                if (CheckForAbuse(Int32.Parse(cmbSol1.Items[cmbSol1.SelectedIndex].ToString()) - 1))
                {
                    cmbCharge1.SelectedIndex = 2;
                }
                else
                {
                    if (lvwProb.Items[Int32.Parse(cmbSol1.Text) - 1].SubItems[3].Text == "verified")
                    {
                        cmbCharge1.SelectedIndex = 0;
                    }

                    if (lvwProb.Items[Int32.Parse(cmbSol1.Text) - 1].SubItems[3].Text == "observed but not verified" || lvwProb.Items[Int32.Parse(cmbSol1.Text) - 1].SubItems[3].Text == "not observed" || lvwProb.Items[Int32.Parse(cmbSol1.Text) - 1].SubItems[3].Text == "replaced as part of repair process" || lvwProb.Items[Int32.Parse(cmbSol1.Text) - 1].SubItems[3].Text == "ECO")
                    {
                        cmbCharge1.SelectedIndex = 1;
                    }
                }
            }
            
        }
        
        private void PopulatePartName(object sender)
        {
            if ((sender as TextBox).Text != "")
            {
                var reader = new StreamReader(File.OpenRead(@"T:\Databases\Parts_List.csv"));
                //var reader = new StreamReader(File.OpenRead("Parts_List.csv"));

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if ((sender as TextBox).Text == values[0])
                    {
                        string charge = " ";

                        if (lvwProb.Items.Count > 0)
                        {
                            if (CheckForAbuse(0))
                            {
                                charge = "ABUSE";
                            }
                            else
                            {
                                if (lvwProb.Items[0].SubItems[3].Text == "observed but not verified" || lvwProb.Items[0].SubItems[3].Text == "not observed" || lvwProb.Items[0].SubItems[3].Text == "replaced as part of repair process" || lvwProb.Items[0].SubItems[3].Text == "ECO")
                                {
                                    charge = "N/C";
                                }
                                else
                                {
                                    charge = " ";
                                }
                            }
                        }
                        else
                        {
                            charge = " ";
                        }

                        if (lvwProb.Items.Count > 0)
                        {
                            string[] row = { values[0], values[1], "", "", "", "", "1", charge, values[7] };
                            dgvParts.Rows.Add(row);
                        }
                        else
                        {
                            string[] row = { values[0], values[1], "", "", "", "", "", charge, values[7] };
                            dgvParts.Rows.Add(row);
                        }

                        
                        /*
                        ListViewItem lvi = new ListViewItem(values[0]);
                        lvi.SubItems.Add(values[1]);
                        lvi.SubItems.Add("");
                        lvi.SubItems.Add("");
                        lvi.SubItems.Add("");
                        lvi.SubItems.Add("");
                        lvi.SubItems.Add("1");

                        if (CheckForAbuse(0))
                        {
                            lvi.SubItems.Add("ABUSE");
                        }
                        else
                        {
                            if (lvwProb.Items.Count > 0)
                            {
                                if (lvwProb.Items[0].SubItems[3].Text == "observed but not verified" || lvwProb.Items[0].SubItems[3].Text == "not observed" || lvwProb.Items[0].SubItems[3].Text == "replaced as part of repair process" || lvwProb.Items[0].SubItems[3].Text == "ECO")
                                {
                                    lvi.SubItems.Add("N/C");
                                }
                                else
                                {
                                    lvi.SubItems.Add("");
                                }
                            }
                            else
                            {
                                lvi.SubItems.Add("");
                            }
                        }

                        lvi.SubItems.Add(values[7]);

                        lvwParts.Items.Add(lvi);
                        */
                        (sender as TextBox).Text = "";
                        (sender as TextBox).Focus();
                        break;
                    }

                }
                (sender as TextBox).Text = "";
                (sender as TextBox).Focus();
                reader.Dispose();
            }
        }

        private void txtPN1_Leave(object sender, EventArgs e)
        {
            PopulatePartName(sender);
        }
        
        
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                ReadPartsToList();
            }
            catch
            {
                //something
            }
        }
        

        private void listPartsResults_DoubleClick(object sender, EventArgs e)
        {
                if (listPartsResults.SelectedIndices.Count>0)
                {
                    string PN = listPartsResults.Items[listPartsResults.SelectedIndices[0]].SubItems[0].Text;
                    
                        txtPN1.Text = PN;
                        PopulatePartName(txtPN1 as TextBox);
                        tabControl1.SelectedIndex = 0;
                }
        }

        private void txtPartNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PartSearch();
            }
        }

        private void cmbStatus1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtProb1.Focus();
            }
        }

        private void CommitProblem()
        {
            if (lvwProb.SelectedIndices.Count == 0)
            {
                ListViewItem lvi = new ListViewItem((lvwProb.Items.Count + 1).ToString());
                lvi.SubItems.Add(txtOne.Text);
                lvi.SubItems.Add(txtProb1.Text);
                lvi.SubItems.Add(cmbStatus1.Text);

                lvwProb.Items.Add(lvi);
            }
            else
            {
                lvwProb.Items[lvwProb.SelectedIndices[0]].SubItems[2].Text = txtProb1.Text.ToString();
                lvwProb.Items[lvwProb.SelectedIndices[0]].SubItems[3].Text = cmbStatus1.Text.ToString();
            }

            txtProb1.Clear();
            cmbStatus1.SelectedIndex = -1;
            cmbStatus1.Text = "";
            txtProb1.Focus();

            UpdateSolBoxes();
        }
        
        private void UpdateSolBoxes()
        {
            List<string> sel = new List<string>();

            if (lvwProb.Items.Count > 0)
            {
                DataGridViewComboBoxColumn theColumn = (DataGridViewComboBoxColumn)this.dgvParts.Columns[6];

                if (lvwProb.Items.Count > theColumn.Items.Count)
                {
                    theColumn.Items.Add(lvwProb.Items[lvwProb.Items.Count - 1].SubItems[0].Text);
                }

                if (lvwProb.Items.Count < theColumn.Items.Count)
                {
                    theColumn.Items.RemoveAt(theColumn.Items.Count - 1);
                }
            }
            /*theColumn.Items.Clear();
            
            foreach (ListViewItem lvi in lvwProb.Items)
            {
                theColumn.Items.Add(lvi.SubItems[0].Text);
            }
            */
        }

        private void txtProb1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtProb1.Text != "")
                {
                    if (cmbStatus1.SelectedIndex >= 0)
                    {
                        CommitProblem();
                    }
                    else
                    {
                        cmbStatus1.Focus();
                    }
                }
            }
        }

        private void lvwProb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwProb.SelectedIndices.Count > 0)
            {
                txtProb1.Text = lvwProb.Items[lvwProb.SelectedIndices[0]].SubItems[2].Text;
                cmbStatus1.Text = lvwProb.Items[lvwProb.SelectedIndices[0]].SubItems[3].Text;
            }
        }
        
        private void txtSR_Leave(object sender, EventArgs e)
        {
            try
            {
                string outputFileName = @"T:\! SR FOLDERS\" + txtSR.Text + "\\problems.csv";
                var reader = new StreamReader(outputFileName);

                model=reader.ReadLine();
                lblModel.Text = model;

                lvwProb.Items.Clear();

                while (!reader.EndOfStream)
                {
                    string prob = reader.ReadLine();
                    
                        ListViewItem lvi = new ListViewItem((lvwProb.Items.Count + 1).ToString());
                        lvi.SubItems.Add(txtOne.Text);
                        lvi.SubItems.Add(prob);
                        lvi.SubItems.Add("???");

                        lvwProb.Items.Add(lvi);
                }
                reader.Close();

                txtProb1.Clear();
                cmbStatus1.SelectedIndex = -1;

                UpdateSolBoxes();
                lblFound.Visible = true;
            }
            catch
            {
                //lvwProb.Items.Clear();
                lblFound.Visible = false;
                lblModel.Text = "";
            }
        }

        private void txtSR_TextChanged(object sender, EventArgs e)
        {

        }

        private void lvwProb_DoubleClick(object sender, EventArgs e)
        {
            if (lvwProb.SelectedIndices.Count > 0)
            {
                foreach(DataGridViewRow dgvr in dgvParts.Rows)
                {
                    if (dgvr.Cells[6].Value.ToString() == lvwProb.Items[lvwProb.SelectedIndices[0]].SubItems[0].Text)
                    {
                        dgvParts.Rows.RemoveAt(dgvParts.Rows.IndexOf(dgvr));
                        UpdateSolBoxes();
                    }
                    else if(Int32.Parse(dgvr.Cells[6].Value.ToString()) > Int32.Parse(lvwProb.Items[lvwProb.SelectedIndices[0]].SubItems[0].Text))
                    {
                        //dgvr.Cells[6].Value = (Int32.Parse(dgvr.Cells[6].Value.ToString()) - 1).ToString();
                        dgvr.Cells[6].Value = "";
                    }
                }
                lvwProb.Items.RemoveAt(lvwProb.SelectedIndices[0]);
                
            }

            foreach(ListViewItem lvi in lvwProb.Items)
            {
                lvi.SubItems[0].Text = (lvwProb.Items.IndexOf(lvi)+1).ToString();
            }

            UpdateSolBoxes();
        }
        
        private void txtSerialNum_Leave(object sender, EventArgs e)
        {
            if (txtSerialNum.Text.Length > 5)
            {
                if (txtSerialNum.Text[0].ToString() == "T")
                {
                    model = "M-SERIES";
                    lblModel.Text = model;
                }

                if (txtSerialNum.Text[0].ToString() == "X")
                {
                    model = "AED-PLUS";
                    lblModel.Text = model;
                }

                if (txtSerialNum.Text[0].ToString() + txtSerialNum.Text[1].ToString() == "AB")
                {
                    model = "E-SERIES";
                    lblModel.Text = model;
                }

                if (txtSerialNum.Text[0].ToString() + txtSerialNum.Text[1].ToString() == "AA")
                {
                    model = "AED-PRO";
                    lblModel.Text = model;
                }

                if (txtSerialNum.Text[0].ToString() + txtSerialNum.Text[1].ToString() == "AR")
                {
                    model = "X-SERIES";
                    lblModel.Text = model;
                }

                if (txtSerialNum.Text[0].ToString() + txtSerialNum.Text[1].ToString() == "AF")
                {
                    model = "R-SERIES";
                    lblModel.Text = model;
                }
            }
        }

        private void cmbStatus1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStatus1.SelectedIndex >= 0)
            {
                if (lvwProb.SelectedIndices.Count > 0)
                {
                    lvwProb.Items[lvwProb.SelectedIndices[0]].SubItems[2].Text = txtProb1.Text;
                    lvwProb.Items[lvwProb.SelectedIndices[0]].SubItems[3].Text = cmbStatus1.Text;
                }
            }
        }

        private void txtSerialNum_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName1_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void txtNewRev1_TextChanged(object sender, EventArgs e)
        {
        }

        private void cmbCharge1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnClearParts_Click(object sender, EventArgs e)
        {
            txtPN1.Clear();
            cmbSol1.SelectedIndex = -1;
            cmbCharge1.SelectedIndex = -1;
            cmbBillable1.SelectedIndex = -1;
        }

        private void txtPN1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvParts_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvParts_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void dgvParts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn &&
                e.RowIndex >= 0 && e.ColumnIndex == 6)
            {


                foreach (DataGridViewRow dgvr in dgvParts.Rows)
                {
                    string charge;

                    try
                    {
                        if (CheckForAbuse(Int32.Parse(dgvr.Cells[6].Value.ToString()) - 1))
                        {
                            charge = "ABUSE";
                        }
                        else
                        {
                            if (lvwProb.Items.Count > 0)
                            {
                                if (lvwProb.Items[Int32.Parse(dgvr.Cells[6].Value.ToString()) - 1].SubItems[3].Text == "observed but not verified" || lvwProb.Items[Int32.Parse(dgvr.Cells[6].Value.ToString()) - 1].SubItems[3].Text == "not observed" || lvwProb.Items[Int32.Parse(dgvr.Cells[6].Value.ToString()) - 1].SubItems[3].Text == "replaced as part of repair process" || lvwProb.Items[Int32.Parse(dgvr.Cells[6].Value.ToString()) - 1].SubItems[3].Text == "ECO")
                                {
                                    charge = "N/C";
                                }
                                else
                                {
                                    charge = " ";
                                }
                            }
                            else
                            {
                                charge = " ";
                            }
                        }
                        dgvr.Cells[7].Value = charge;
                    }
                    catch
                    {
                        //something
                    }
                }
            }
        }

        private void dgvParts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                dgvParts.Rows.RemoveAt(dgvParts.Rows.IndexOf(dgvParts.SelectedRows[0]));
                txtPartNum.Focus();
            }

        }

        private void txtProb1_TextChanged(object sender, EventArgs e)
        {
            if (lvwProb.SelectedIndices.Count > 0)
            {

            }
        }

        private void cmbStatus1_Leave(object sender, EventArgs e)
        {
            if (cmbStatus1.SelectedIndex >= 0)
            {
                CommitProblem();
            }
        }
    }

}
