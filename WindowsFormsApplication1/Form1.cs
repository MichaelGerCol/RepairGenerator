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
using System.Net.Mail;
using System.Drawing.Printing;
using System.Drawing.Text;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Runtime.InteropServices;



namespace WindowsFormsApplication1
{
    
    public partial class Form1 : Form
    {
        public string kb_path = @"T:\Databases\kd.txt";

        public Form1()
        {
            InitializeComponent();

            var reader = new StreamReader(@"T:\Databases\env.txt");
            kb_path = reader.ReadLine();
            reader.Close();
        }

        string model = "";
        int lowPrice=-0;
        int highPrice=0;
        
        int dupes = 0;
        List<string> problems = new List<string>();
        List<string> PartsList = new List<string>();
        List<string> NeverGoesList = new List<string>();
        public enum SR_type { Unit, Loaner, Accessory };

        public void WriteMetric(SR_type unit_type, string operation, string sr, string origin, string destination, string username, string comment)
        {
            string file_path = @"T:\! SR FOLDERS\" + sr + "\\";
            if (unit_type == SR_type.Unit)
            {
                file_path = @"T:\! SR FOLDERS\" + sr + "\\";
            }
            else if (unit_type == SR_type.Loaner)
            {
                file_path = @"T:\! LOANER SR FOLDERS\" + sr + "\\";
            }
            else if (unit_type == SR_type.Accessory)
            {
                file_path = @"T:\! SR ACCESSORY FOLDERS\" + sr + "\\";
            }

            //Checks if there is an Accessory folder for this SR and uses that as the target path if found
            if (Directory.Exists(@"T:\! SR ACCESSORY FOLDERS\" + sr + "\\"))
            {
                file_path = @"T:\! SR ACCESSORY FOLDERS\" + sr + "\\";
            }

            if (!Directory.Exists(file_path))
            {
                Directory.CreateDirectory(file_path);
            }

            if (!File.Exists(file_path + "metric"))
            {
                var newwriter = new StreamWriter(file_path + "metric");
                newwriter.WriteLine("Operation`Origin`Destination`User`Timestamp`Comment");
                newwriter.Close();
            }

            try
            {
                var writer = new StreamWriter(file_path + "metric", true);
                writer.WriteLine(operation + "`" + origin.Replace("grp", "") + "`" + destination.Replace("grp", "") + "`" + username + "`" + DateTime.Now.ToString("d/MM/yyyy h:mm tt") + "`" + comment);
                writer.Close();
            }
            catch
            {
                //do nothing
            }
        }

        private void ReadPartsToList()
        {
            PartsList.Clear();
            try
            {
                var reader = new StreamReader(@"T:\Databases\Parts_List.csv");
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
            listPartsResults.Items.Clear();
            foreach (string item in PartsList)
            {
                var values = item.Split(',');
                ListViewItem lvi = new ListViewItem(new string[] { values[0], values[2] + " " + values[1], "$" + values[3], values[4] });
                listPartsResults.Items.Add(lvi);
            }
        }
        
        /*================================================================
         * Tab 2 code
         * ==============================================================*/

        private void PartSearch()
        {
            //Change this to input problems instead of parts
            //ReadParts();

            List<string> search = new List<string>();            
            List<ListViewItem> resultsNum = new List<ListViewItem>();
            List<ListViewItem> templist = new List<ListViewItem>();

            #region add
            List<string> listA = new List<string>();
            List<string> listB = new List<string>();
            List<string> listC = new List<string>();
            List<string> listD = new List<string>();

            foreach (string item in PartsList)
            {

                var values = item.Split(',');

                listA.Add(values[0]);
                listB.Add(values[2] + " " + values[1]);
                listC.Add("$" + values[3]);
                listD.Add(values[4]);
            }

            for (int j = 0;j < listA.Count; j++)
            {
                ListViewItem x = new ListViewItem(listA[j]);
                x.SubItems.Add(listB[j]);
                x.SubItems.Add(listC[j]);
                x.SubItems.Add(listD[j]);
                templist.Add(x);
            }
            #endregion

            search.AddRange(txtPartNum.Text.ToUpper().Split(' ').ToArray());

            foreach (string q in search)
            {
                foreach (ListViewItem item in templist)
                {
                    if (item.SubItems[0].Text.Contains(q) || item.SubItems[1].Text.Contains(q))
                    {
                        resultsNum.Add(item);
                    }
                }

                templist.Clear();

                foreach (ListViewItem item in resultsNum)
                {
                    templist.Add(item);
                }

                resultsNum.Clear();
            }

            listPartsResults.Items.Clear();
            foreach (ListViewItem item in templist)
            {
                listPartsResults.Items.Add(item);
            }
        }
        
        private void btnPartNumClear_Click(object sender, EventArgs e)
        {
            ReadParts();
            txtPartNum.Clear();
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
            else if (tabControl1.SelectedIndex == 2)
            {
                LoadSettings();
            }
        }

        private void LoadSettings()
        {
            lstNoCharge.Items.Clear();
            lstCycler.Items.Clear();
            lstNoChelmsford.Items.Clear();

            var reader = new StreamReader("NC.txt");
            while (!reader.EndOfStream)
            {
                lstNoCharge.Items.Add(reader.ReadLine());
            }
            reader.Close();

            var cycler_reader = new StreamReader("cycler_parts.txt");
            while (!cycler_reader.EndOfStream)
            {
                lstCycler.Items.Add(cycler_reader.ReadLine());
            }
            cycler_reader.Close();
            
            var ng_reader = new StreamReader("never_goes.txt");
            while (!ng_reader.EndOfStream)
            {
                lstNoChelmsford.Items.Add(ng_reader.ReadLine());
            }
            ng_reader.Close();
        }
        

        //Repair Scanner Section!!
        //==============================================================================
        
        private void txtPN1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                SelectNextControl((Control)sender, true, true, true, true);

                txtPN1.Clear();
            }
        }
        
        private void GenerateOracleEntry()
        {
            StringBuilder oracle_entry = new StringBuilder();

            //Oracle Entry Maker
            //============================================
            foreach (DataGridViewRow lvi in dgvProblems.Rows)
            {
                List<string> paragraph = new List<string>();

                StringBuilder problem = new StringBuilder();
                StringBuilder repair = new StringBuilder();

                string problem_status_ending = "";
                string tense = "";


                //Add problem
                string problem_num = (string)lvi.Cells["Num"].Value;
                string problem_description = (string)lvi.Cells["Description"].Value;
                string problem_status = (string)lvi.Cells["Status"].Value;

                if (problem_status == "verified" || problem_status == "observed but not verified" || problem_status == "not observed" || problem_status == "observed in the error log but not verified")
                {
                    problem.Append("The problem of " + problem_description + " was " + problem_status + ". The ");
                }
                else if (problem_status == "worn")
                {
                    problem.Append("The problem of " + problem_description + " was verified. The ");
                }
                else if(problem_status=="failed PM")
                {
                    problem.Append("During PM, the unit failed due to " + problem_description + ". The ");
                }
                else if(problem_status== "replaced as part of repair process")
                {
                    problem.Append("The following parts were replaced as part of the repair process: ");
                }
                
                //Search replaced parts for ones that match the problem
                foreach(DataGridViewRow partlvi in dgvParts.Rows)
                {
                    if ((string)partlvi.Cells[dgvParts.Columns.IndexOf(dgvParts.Columns["SolutionNum"])].Value == problem_num)
                    {
                        string part_num = (string)partlvi.Cells["PartNum"].Value;
                        string part_name = (string)partlvi.Cells["PartName"].Value;
                        string old_serial = (string)partlvi.Cells["OldSerial"].Value;
                        string old_revision = (string)partlvi.Cells["OldRev"].Value;
                        string new_serial = (string)partlvi.Cells["NewSerial"].Value;
                        string new_revision = (string)partlvi.Cells["NewRev"].Value;

                        string old_sn = "";
                        string new_sn = "";
                        string old_rev = "";
                        string new_rev = "";

                        if (old_serial != "") { old_sn = ", Old SN: "+ old_serial; }
                        if (old_revision != "") { old_rev = " Old: Rev "+old_revision; }
                        if (new_serial != "") { new_sn = ", New SN: "+new_serial; }
                        if (new_revision != "") { new_rev = " New: Rev "+new_revision; }
                        
                        paragraph.Add(part_name + " (PN: " + part_num + old_sn + old_rev + new_sn + new_rev + ")");
                    }
                }
                
                for (int i = 0; i < paragraph.Count; i++)
                {
                    if (i < paragraph.Count - 2)
                    {
                        repair.Append(paragraph[i] + ", ");
                    }
                    else if (i == paragraph.Count - 2)
                    {
                        repair.Append(paragraph[i] + ", and ");
                    }
                    else if (i == paragraph.Count - 1)
                    {
                        repair.Append(paragraph[i]);
                    }
                }
                
                //If status is "verified" or "failed PM"
                if (problem_status == "verified" || problem_status == "failed PM" || problem_status=="worn")
                {
                    problem_status_ending = "to remedy the problem.";
                }
                else if(problem_status == "observed but not verified" || problem_status == "not observed" || problem_status == "observed in the error log but not verified")
                {
                    problem_status_ending = "to reduce the probability of reoccurrence.";
                }
                
                //Set the tense (for grammar!)
                if (paragraph.Count == 1)
                {
                    tense = " was ";
                } else
                {
                    tense = " were ";
                }
                
                //Put entire sentence together
                if (problem_status == "replaced as part of repair process")
                {
                    problem.Append(repair);
                }
                else if (problem_status == "ECO")
                {
                    problem.Append("The following parts were replaced as part of the ECO: " + repair);
                }
                else if (problem_status == "Upgrade")
                {
                    problem.Append("The following parts were replaced as part of the upgrade: " + repair);
                }
                else if (problem_status == "Customer Accommodation")
                {
                    problem.Append(repair+tense+"replaced as a customer accommodation to remedy the problem.");
                }
                else
                {
                    problem.Append(repair + tense + "replaced " + problem_status_ending);
                }
                
                oracle_entry.Append(problem.ToString() + Environment.NewLine+Environment.NewLine);
            }

            OracleEntry OE = new OracleEntry(oracle_entry.ToString().Trim(),lblModel.Text,txtSR.Text);
            OE.Show();
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

            string outputFileName = @"T:\! SR FOLDERS\" +txtSR.Text+"\\"+ txtSR.Text + " - " + txtSerialNum.Text + " - " + txtCustomerName.Text + " - cover sheet.docx";
            
            // Perform the replace:
            if (chkAccessoriesRequired.Checked)
            {
                letter.ReplaceText("#accessoriesrequired#", "ACCESSORIES REQUIRED");
            }
            letter.ReplaceText("#accessoriesrequired#", "");

            int i= 0;
            foreach(DataGridViewRow lvi in dgvParts.Rows)
            {
                if ((string)lvi.Cells[0].Value != "9310-0709" && (string)lvi.Cells[0].Value != "9310-000705")
                {
                    letter.ReplaceText("%partname" + (i + 1) + "%", lvi.Cells[1].Value.ToString());
                    letter.ReplaceText("%pn" + (i + 1) + "%", lvi.Cells[0].Value.ToString());
                    letter.ReplaceText("%sn" + (i + 1) + "%", lvi.Cells[4].Value.ToString());
                    letter.ReplaceText("%rev" + (i + 1) + "%", lvi.Cells[5].Value.ToString());

                    if (lvi.Cells[7].Value.ToString() != "CUSTOMER ACCOMODATION")
                    {
                        letter.ReplaceText("%charge" + (i + 1) + "%", lvi.Cells[7].Value.ToString());
                    }
                    else
                    {
                        letter.ReplaceText("%charge" + (i + 1) + "%", "N/C");
                    }
                    i++;
                }
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
            //var reader = new StreamReader(File.OpenRead(@"T:\Databases\Parts_List.csv"));

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

            foreach(DataGridViewRow dgvr in dgvParts.Rows)
            {
                if ((string)dgvr.Cells[8].Value == "Y")
                {
                    partslist.Add((string)dgvr.Cells[0].Value);
                }
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
            foreach(DataGridViewRow lvi in dgvProblems.Rows)
            {
                if ((string)lvi.Cells[dgvProblems.Columns.IndexOf(dgvProblems.Columns["Status"])].Value == "")
                {
                    MessageBox.Show("Please select a valid status for each problem");
                    return false;
                }
            }

            return true;
        }

        private void EstimateFeedback()
        {
                foreach(DataGridViewRow lvi in dgvProblems.Rows)
                {
                    if ((string)lvi.Cells[dgvProblems.Columns.IndexOf(dgvProblems.Columns["Status"])].Value == "verified")
                    {
                        string repair = "";

                        foreach(DataGridViewRow partlvi in dgvParts.Rows)
                        {
                            if ((string)partlvi.Cells[6].Value == (string)lvi.Cells[0].Value && (string)partlvi.Cells[8].Value=="Y")
                            {
                                if (repair == "")
                                {
                                    repair = (string)partlvi.Cells[0].Value;
                                }
                                else
                                {
                                    repair = repair+"+"+(string)partlvi.Cells[0].Value;
                                }
                            }
                        }
                        
                        var reader = new StreamReader(@"T:\Databases\"+model + "_Problems");
                        List<ListViewItem> problemdata = new List<ListViewItem>();
                        bool probentry = false;

                        while (!reader.EndOfStream)
                        {
                            var line=reader.ReadLine();
                            var values = line.Split('<');

                            ListViewItem entry = new ListViewItem(values[0].ToUpper());

                            for(int i=1;i<values.Count();i++)
                            {
                                if (values[i] != "")
                                {
                                    entry.SubItems.Add(values[i]);
                                }
                            }

                            if (entry.SubItems[0].Text.Trim().ToUpper() == ((string)lvi.Cells[2].Value).Trim().ToUpper())
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
                            ListViewItem newentry = new ListViewItem((string)lvi.Cells[2].Value);
                            newentry.SubItems.Add(repair.ToUpper());
                            problemdata.Add(newentry);
                        }

                        var writer = new StreamWriter(@"T:\Databases\"+model + "_Problems");
                        

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
                                    ent = ent + "<" + parts.Text;
                                }
                            }
                            writer.WriteLine(ent.Trim().ToUpper());
                        }

                        writer.Close();
                    }
                }
        }
        
        private void CheckRRF(string sr)
        {
            bool found = false;

            var reader = new StreamReader(@"T:\Databases\Kanban Records\_RRF.txt");
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (line.Split('`')[0] == sr)
                {
                    found = true;
                    break;
                }
            }
            reader.Close();

            if (found == true)
            {
                RRFForm rf = new RRFForm(sr);
                rf.Show();
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

        private bool AreThereMissingStatuses()
        {
            foreach(DataGridViewRow dgvr in dgvProblems.Rows)
            {
                if ((string)dgvr.Cells[3].Value == "")
                {
                    return true;
                }
            }

            return false;
        }

        private bool AreThereMissingPartStatuses()
        {
            foreach (DataGridViewRow dgvr in dgvParts.Rows)
            {
                if ((string)dgvr.Cells[6].Value == "")
                {
                    return true;
                }
            }

            return false;
        }

        private void PartsToChelmsford()
        {
            DateTime dt = DateTime.Today;
            while (dt.DayOfWeek != DayOfWeek.Sunday)
            {
                dt=dt.AddDays(-1);
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

            foreach (DataGridViewRow lvi in dgvParts.Rows)
            {
                if (Convert.ToString(lvi.Cells[10].Value) == "Y")
                {
                    bool found = false;
                    foreach (string S in returning_parts)
                    {
                        if (S.Contains("SR " + txtSR.Text + "," + Convert.ToString(lvi.Cells[1].Value) + ",PN: " + Convert.ToString(lvi.Cells[0].Value) + "   SN: " + Convert.ToString(lvi.Cells[2].Value)))
                        {
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        writer.WriteLine(dt.AddDays(8).ToString("MMMM d yyyy") + ",SR " + txtSR.Text + "," + Convert.ToString(lvi.Cells[1].Value) + ",PN: " + Convert.ToString(lvi.Cells[0].Value) + "   SN: " + Convert.ToString(lvi.Cells[2].Value) + " Rev " + Convert.ToString(lvi.Cells[3].Value) + "," + lblModel.Text + ",ZOLL Canada");
                    }
                }
            }
            writer.Close();
        }

        private void YearlyPartsToChelmsford()
        {
            DateTime dt = DateTime.Today;
            while (dt.DayOfWeek != DayOfWeek.Monday)
            {
                dt = dt.AddDays(1);
            }

            string path = @"T:\Shipments\_FIR_Parts to Chelmsford\Yearly\Year of " + DateTime.Today.ToString("yyyy") + " - Returns.csv";
            bool file_found = File.Exists(path);

            var writer = new StreamWriter(path, file_found);
            if (!file_found)
            {
                writer.WriteLine("Date,SR Number,Part Description,Part Num and Serial Num,Model,Location,Tracking Number");
            }

            foreach (DataGridViewRow lvi in dgvParts.Rows)
            {
                if (Convert.ToString(lvi.Cells[10].Value) == "Y")
                {
                    writer.WriteLine(dt.ToString("MMMM d yyyy") + ",SR " + txtSR.Text + "," + Convert.ToString(lvi.Cells[1].Value) + ",PN: " + Convert.ToString(lvi.Cells[0].Value) + "   SN: " + Convert.ToString(lvi.Cells[2].Value) + " Rev " + Convert.ToString(lvi.Cells[3].Value) + "," + lblModel.Text + ",ZOLL Canada");
                }
            }
            writer.Close();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (!CheckValidity())
            {
                return;
            }

            if (AreThereMissingStatuses()==true)
            {
                MessageBox.Show("There is a missing status in at least one of the problems.");
                return;
            }

            if (AreThereMissingPartStatuses() == true)
            {
                MessageBox.Show("At least one part in the report does not have a solution number.");
                return;
            }

            CheckDirectory(txtSR.Text);
            txtCustomerName.Text = txtCustomerName.Text.Replace("/", "").Replace("\"", "").Replace("*", "").Replace("<", "").Replace(">", "").Replace("|", "");
            string outputFileName = @"T:\! SR FOLDERS\" + txtSR.Text + "\\" + txtSR.Text +" - " + txtSerialNum.Text + " - " + txtCustomerName.Text + " - cover sheet - " + txtTechName.Text + ".docx";
            

            if (outputFileName.Contains("/")|| outputFileName.Contains("\"") || outputFileName.Contains("*") || outputFileName.Contains("<") || outputFileName.Contains(">") || outputFileName.Contains("|"))
            {
                MessageBox.Show("Please review the information in Step 1. Output filename can not contain illegal letters! Can not contain / \\ : * ? < > \" |");
                return;
            }

            if (chkAccessoriesRequired.Checked == true)
            {
                DialogResult dr = MessageBox.Show("'Accessories Required' was checked. If this repair is a MS-11 to MX-1 SpO2 Upgrade, we must inform phone support about it.\n\nWould you like to send an email to Phone Support?", "Notice", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
                        Microsoft.Office.Interop.Outlook.MailItem oMsg = (Microsoft.Office.Interop.Outlook.MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

                        Outlook.Recipients oRecips = (Outlook.Recipients)oMsg.Recipients;
                        Outlook.Recipient oRecip = (Outlook.Recipient)oRecips.Add("HelpDeskCanada-Internal@zoll.com");
                        
                        oRecip.Resolve();

                        oMsg.Subject = "SR " + txtSR.Text + " - Accessory Required - Please inquire with the customer";
                        oMsg.Body = "Hi Help Desk,\n\nThe unit under SR " + txtSR.Text + " from "+ txtCustomerName.Text+ " requires an accessory for a MS-11 to MX-1 SpO2 upgrade. Could you please confirm which accessory is needed by the customer? \n14 pin adaptor:  8000-000381 /9 355-000381\n20 pin cable: 8000-0330 / 9355-0330\n\nThanks,\n\n" + txtTechName.Text;
                        //oMsg.Attachments.Add("c:/temp/test.txt", Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue, Type.Missing, Type.Missing);
                        oMsg.Display(true);
                        
                    }
                    catch
                    {
                        MessageBox.Show("Email function failed. Make sure Outlook is open and then try again");
                        return;
                    }
                }
            }
            
            try
            {
                GenerateRepairMetadata();
            }
            catch
            {
                MessageBox.Show("There was an error generating metadata, but that's okay.");
                //return;
            }

            try
            {
                CheckRRF(txtSR.Text);
            }
            catch
            {
                MessageBox.Show("Error while trying find RRF's. Program will continue after hitting OK.");
            }

            if (radMoveCycler.Checked)
            {
                PrintTextBoxContent();
            }
            //try
            //{
                GenerateOracleEntry();
            //}
            //catch
            //{
            //    MessageBox.Show("There was an error generating the Oracle entry.");
            //    return;
            //}

            try
            {
                EstimateFeedback();
            }
            catch
            {
                MessageBox.Show("Could not complete problem-solution feedback loop, but thats okay. The program will continue.");
            }

            //try
            //{
                GenerateCoverSheet();
            //}
            //catch
            //{
            //    MessageBox.Show("There was an error generating the Cover Sheet. Make sure the cover sheet for SR " + txtSR.Text + " is not open.");
            //    return;
            //}
                        
            try
            {
                PartsList pl = new PartsList(dgvParts.Rows,txtSR.Text,txtSerialNum.Text,lblModel.Text);
                pl.Show();
            }
            catch
            {
                MessageBox.Show("There was an error generating the parts sign out. Please remember to sign out the parts!");
                //return;
            }
        }



        private void GenerateRepairMetadata_backup()
        {
            var writer = new StreamWriter(@"T:\! SR FOLDERS\" + txtSR.Text + "\\repair_meta_backup.txt");
            writer.WriteLine("i<" + txtSR.Text + "<" + txtModel.Text + "<" + txtSerialNum.Text + "<" + txtCustomerName.Text);

            foreach (DataGridViewRow dgvr in dgvProblems.Rows)
            {
                writer.WriteLine("p<" + Convert.ToString(dgvr.Cells["Num"].Value) + "<" + Convert.ToString(dgvr.Cells["Description"].Value) + "<" + Convert.ToString(dgvr.Cells["Status"].Value));
            }

            foreach (DataGridViewRow dgvr in dgvParts.Rows)
            {
                writer.WriteLine("s<" + Convert.ToString(dgvr.Cells["PartNum"].Value) + "<" + Convert.ToString(dgvr.Cells["PartName"].Value) + "<" + Convert.ToString(dgvr.Cells["OldSerial"].Value) + "<" + Convert.ToString(dgvr.Cells["OldRev"].Value) + "<" + Convert.ToString(dgvr.Cells["NewSerial"].Value) + "<" + Convert.ToString(dgvr.Cells["NewRev"].Value) + "<" + Convert.ToString(dgvr.Cells["SolutionNum"].Value) + "<" + Convert.ToString(dgvr.Cells["Charge"].Value) + "<Y");
            }
            writer.Close();
        }

        private void GenerateRepairMetadata()
        {
            var writer = new StreamWriter(@"T:\! SR FOLDERS\" + txtSR.Text + "\\repair_meta");
            writer.WriteLine("i<" + txtSR.Text + "<" + txtModel.Text + "<" + txtSerialNum.Text + "<" + txtCustomerName.Text);

            foreach(DataGridViewRow dgvr in dgvProblems.Rows)
            {
                writer.WriteLine("p<" + Convert.ToString(dgvr.Cells["Num"].Value) + "<" + Convert.ToString(dgvr.Cells["Description"].Value) + "<" + Convert.ToString(dgvr.Cells["Status"].Value));
            }

            foreach (DataGridViewRow dgvr in dgvParts.Rows)
            {
                writer.WriteLine("s<" + Convert.ToString(dgvr.Cells["PartNum"].Value) + "<" + Convert.ToString(dgvr.Cells["PartName"].Value) + "<" + Convert.ToString(dgvr.Cells["OldSerial"].Value) + "<" + Convert.ToString(dgvr.Cells["OldRev"].Value) + "<" + Convert.ToString(dgvr.Cells["NewSerial"].Value) + "<" + Convert.ToString(dgvr.Cells["NewRev"].Value) + "<" + Convert.ToString(dgvr.Cells["SolutionNum"].Value) + "<" + Convert.ToString(dgvr.Cells["Charge"].Value) + "<Y");
            }
            writer.Close();
        }

        public void MoveOnKanban()
        {
            var reader = new StreamReader(this.kb_path);
            List<string> templist = new List<string>();

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                var values = line.Split('<');

                if (line.Split('<')[1] == txtSR.Text)
                {
                    string dest = "";

                    if (radMovePM.Checked == true)
                    {
                        values[0] = "grpPM";
                        values[2] = "UNASSIGNED";
                        values[7] = DateTime.Now.ToString("dd/MM/yyyy h:mm:ss tt");
                        dest = "PM";
                    }
                    else if (radMoveCycler.Checked == true)
                    {
                        values[0] = "grpCycler";
                        values[2] = "UNASSIGNED";
                        values[7] = DateTime.Now.ToString("dd/MM/yyyy h:mm:ss tt");
                        dest = "Cycler";
                    }

                    try {
                        var recordwriter = new StreamWriter(@"T:\Databases\Kanban Records\_MOVEMENT.txt", true);

                        DateTime lastmove;
                        string[] formatstring = { "d/MM/yyyy h:mm:ss tt", "dd/MM/yyyy h:mm:ss tt", "d-MM-yyyy h:mm:ss tt", "dd-MM-yyyy h:mm:ss tt", "MM/dd/yyyy h:mm:ss tt", "yyyy/MM/d h:mm:ss tt", "yyyy/MM/dd h:mm:ss tt" };
                        DateTime.TryParseExact(values[7], formatstring, null, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AdjustToUniversal, out lastmove);

                        recordwriter.WriteLine(txtSR.Text + "<" + txtSerialNum.Text + "<" + values[4] + "<" + Environment.UserName + "<" + txtCustomerName.Text + "<" + "Repairs" + "<" + dest + "<" + DateTime.Now.Subtract(lastmove).TotalDays.ToString("0.####") + "<" + DateTime.Now.ToString("dd/MM/yyyy h:mm:ss tt") + "<" + values[3]);
                        recordwriter.Close();
                    }
                    catch
                    {
                        //do nothing
                    }
                    
                    WriteMetric(SR_type.Unit, "Movement", txtSR.Text, "grpRepairs", dest, Environment.UserName, values[3]);
                    
                }
                templist.Add(string.Join("<", values));
            }
            reader.Close();

            

            var writer = new StreamWriter(this.kb_path);

            foreach (string s in templist)
            {
                writer.WriteLine(s);
            }
            writer.Close();

            
        }

        private void ClearAll()
        {
            // Clear Fields
            
            txtProb1.Clear();
            cmbStatus1.SelectedIndex = -1;
            dgvProblems.Rows.Clear();
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
            PopulateSRData();
        }
        
        private void txtSerialNum_KeyDown(object sender, KeyEventArgs e)
        {
            PopulateModelFromSerial();
        }
        
        private bool CheckForAbuse(string problem_num)
        {
            if (dgvProblems.Rows.Count > 0)
            {
                foreach(DataGridViewRow dgvr in dgvProblems.Rows)
                {
                    if ((string)dgvr.Cells["Num"].Value == problem_num)
                    {
                        //Input list of words to look for in the problems to automatically switch to 'Abuse'
                        List<string> Keywords = new List<string> { "damage", "torn", "puncture", "pierce", "cracked", "bent", "water", "missing" };

                        foreach (string word in Keywords)
                        {
                            if (((string)dgvr.Cells["Description"].Value).ToLower().Contains(word))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
  
        private bool CheckIfNoCharge(string pn)
        {
            if (txtSerialNum.Text.Length >= 5)
            {
                //Hardcode for X-SERIES 
                if (txtSerialNum.Text[0].ToString() + txtSerialNum.Text[1].ToString() == "AR")
                {
                    //Front enclosures
                    if (Int32.Parse(txtSerialNum.Text[2].ToString() + txtSerialNum.Text[3].ToString()) <= 14)
                    {
                        if (txtSerialNum.Text[4].ToString() == "A" || txtSerialNum.Text[4].ToString() == "B" || txtSerialNum.Text[4].ToString() == "C" || txtSerialNum.Text[4].ToString() == "D" || txtSerialNum.Text[4].ToString() == "E" || txtSerialNum.Text[4].ToString() == "F")
                        {
                            if (pn == "1027-000003" || pn == "1007-002503-01" || pn == "1027-000002" || pn == "1027-000008-02" || pn == "1027-000009-02")
                            {
                                return true;
                            }
                        }
                    }

                    //Side Panels
                    if (txtSerialNum.Text[2].ToString() + txtSerialNum.Text[3].ToString() == "13" || txtSerialNum.Text[2].ToString() + txtSerialNum.Text[3].ToString() == "14")
                    {
                        if (pn == "1007-001503-03" || pn == "1007-002503-01" || pn == "1007-002504-01")
                        {
                            if (txtSerialNum.Text[2].ToString() + txtSerialNum.Text[3].ToString() == "13")
                            {
                                if (txtSerialNum.Text[4].ToString() == "K" || txtSerialNum.Text[4].ToString() == "L")
                                {
                                    return true;
                                }
                            }

                            if (txtSerialNum.Text[2].ToString() + txtSerialNum.Text[3].ToString() == "14")
                            {
                                return true;
                            }
                        }
                    }
                }

                //Hardcode for PPMD front enclosures
                if (txtSerialNum.Text[0].ToString() + txtSerialNum.Text[1].ToString() == "AI")
                {
                    if (Int32.Parse(txtSerialNum.Text[2].ToString() + txtSerialNum.Text[3].ToString()) <= 13)
                    {
                        if (txtSerialNum.Text[4].ToString() == "A" || txtSerialNum.Text[4].ToString() == "B" || txtSerialNum.Text[4].ToString() == "C")
                        {
                            if (pn == "1037-000001-01")
                            {
                                return true;
                            }
                        }
                    }
                }

                try
                {
                    var reader = new StreamReader("NC.txt");
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();

                        if (line == pn)
                        {
                            return true;
                        }
                    }
                    reader.Close();
                    return false;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                try
                {
                    var reader = new StreamReader("NC.txt");
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();

                        if (line == pn)
                        {
                            return true;
                        }
                    }
                    reader.Close();
                }
                catch
                {
                    return false;
                }
                return false;
            }
        }

        private string SendPartToChelmsford(string part_num)
        {
            foreach(string line in PartsList)
            {
                var values = line.Split(',');
                if (values[0] == part_num)
                {
                    return values[8];
                }
            }
            return "N";
        }

        private void PopulatePartName(string part_num)
        {
            if (part_num.Trim() == "")
            {
                return;
            }

            foreach (string line in PartsList)
            {
                var values = line.Split(',');
                if (part_num == values[0])
                {
                    string charge = " ";
                    if (CheckIfNoCharge(part_num) == true)
                    {
                        charge = "N/C";
                    }

                    bool found = false;

                    foreach (DataGridViewRow dgvr in dgvParts.Rows)
                    {
                        if ((string)dgvr.Cells["PartNum"].Value == part_num)
                        {
                            found = true;
                            if (!((string)dgvr.Cells["PartName"].Value).Contains(" x "))
                            {
                                dgvr.Cells["PartName"].Value = (string)dgvr.Cells["PartName"].Value + " x 2";
                            }
                            else
                            {
                                var part_name = ((string)dgvr.Cells["PartName"].Value).Split(' ');
                                int quantity = Int32.Parse(part_name[part_name.Length - 1]);

                                quantity++;
                                dgvr.Cells["PartName"].Value = values[1] + " x " + quantity.ToString();
                            }
                            break;
                        }
                    }

                    if (found == false)
                    {
                        if (dgvProblems.Rows.Count > 0)
                        {
                            string[] row = { values[0], values[1], "", "", "", "", "1", charge, "Remove" };
                            dgvParts.Rows.Add(row);
                        }
                        else
                        {
                            string[] row = { values[0], values[1], "", "", "", "", "", charge, "Remove" };
                            dgvParts.Rows.Add(row);
                        }
                    }


                    txtPN1.Focus();
                    CheckForCyclerParts();

                    break;
                }
            }
        }

        private void CheckForCyclerParts()
        {
            try
            {
                List<string> cycler_parts = new List<string>();

                var cyclerreader = new StreamReader("cycler_parts.txt");

                while (!cyclerreader.EndOfStream)
                {
                    cycler_parts.Add(cyclerreader.ReadLine());
                }

                cyclerreader.Close();

                foreach (DataGridViewRow dgvr in dgvParts.Rows)
                {
                    if (cycler_parts.Contains(dgvr.Cells["PartNum"].Value.ToString()))
                    {
                        radMoveCycler.Checked = true;
                        return;
                    }
                }

                radMovePM.Checked = true;
            }
            catch
            {
                //do nothing
            }
        }

        private void txtPN1_Leave(object sender, EventArgs e)
        {
            PopulatePartName(txtPN1.Text);
            txtPN1.Clear();
        }

        private void LoadNames()
        {
            try
            {
                var reader = new StreamReader(@"T:\Databases\technames.txt");

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (line.Split('<')[0] == Environment.UserName)
                    {
                        txtTechName.Text = line.Split('<')[1];
                    }
                }

                reader.Close();
            }
            catch
            {
                //do nothing
            }
        }

        private void LoadPresetNames()
        {
            try
            {
                var reader1 = new StreamReader("Preset_1.txt");
                string line=reader1.ReadLine();
                btnPreset1.Text = line;
                reader1.Close();

                var reader2 = new StreamReader("Preset_2.txt");
                string line2 = reader2.ReadLine();
                btnPreset2.Text = line2;
                reader2.Close();

                var reader3 = new StreamReader("Preset_3.txt");
                string line3 = reader3.ReadLine();
                btnPreset3.Text = line3;
                reader3.Close();

                var reader4 = new StreamReader("Preset_4.txt");
                string line4 = reader4.ReadLine();
                btnPreset4.Text = line4;
                reader4.Close();
            }
            catch
            {
                //do nothing
            }
        }

        private void LoadNeverGoes()
        {
            var reader = new StreamReader("never_goes.txt");
            while (!reader.EndOfStream)
            {
                NeverGoesList.Add(reader.ReadLine());
            }
            reader.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadNames();
            LoadPresetNames();
            LoadNeverGoes();

            try
            {
                ReadPartsToList();

                AutoAction();
            }
            catch
            {
                //something
            }
        }
        
        private void AutoAction()
        {
            try
            {
                string auto = @"C:\Users\Public\auto_action";
                var reader = new StreamReader(auto);

                string line = reader.ReadLine();
                reader.Close();

                File.Delete(auto);
                
                txtSR.Text = line;
                PopulateSRData();
            }
            catch
            {
                //do nothing
            }
        }

        private void listPartsResults_DoubleClick(object sender, EventArgs e)
        {
                if (listPartsResults.SelectedIndices.Count>0)
                {
                    string PN = listPartsResults.Items[listPartsResults.SelectedIndices[0]].SubItems[0].Text;
                    
                        PopulatePartName(PN);
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

        private string CorrectCapitalization(string input)
        {
            string output = input.ToLower();

            output = output.Replace("spo2", "SpO2");
            output = output.Replace("etco2", "EtCO2");
            output = output.Replace("30j test", "30J Test");
            output = output.Replace("30j", "30J");
            output = output.Replace("aed", "AED");
            output = output.Replace("mfc", "MFC");
            output = output.Replace("pcmcia", "PCMCIA");
            output = output.Replace("lcd", "LCD");
            output = output.Replace("nibp", "NIBP");
            output = output.Replace("ibp", "IBP");
            output = output.Replace("ecg", "ECG");
            output = output.Replace("v1", "V1");
            output = output.Replace("v2", "V2");
            output = output.Replace("v3", "V3");
            output = output.Replace("v4", "V4");
            output = output.Replace("v5", "V5");
            output = output.Replace("v6", "V6");
            output = output.Replace("cpr", "CPR");
            output = output.Replace("rs-232", "RS-232");
            output = output.Replace("bluetooth", "Bluetooth");
            output = output.Replace("comm error", "COMM ERROR");
            output = output.Replace("zoll", "ZOLL");
            output = output.Replace("roc adaptor", "ROC Adaptor");
            output = output.Replace("co2", "CO2");
            output = output.Replace("recorder fault", "RECORDER FAULT");
            output = output.Replace("defib fault", "DEFIB FAULT");
            output = output.Replace("defib disabled", "DEFIB DISABLED");
            output = output.Replace("pacer fault", "PACER FAULT");
            output = output.Replace("pacer disabled", "PACER DISABLED");
            output = output.Replace("nibp fault", "NIBP FAULT");
            output = output.Replace("gps", "GPS");
            output = output.Replace("clock fault", "CLOCK FAULT");
            output = output.Replace("check cuff/hose", "CHECK CUFF/HOSE");
            output = output.Replace("qrs", "QRS");
            output = output.Replace("ubp", "UBP");
            output = output.Replace("16a", "16A");
            output = output.Replace("17a", "17A");
            output = output.Replace("18a", "18A");
            output = output.Replace("19a", "19A");
            output = output.Replace("200j", "200J");
            output = output.Replace("usb", "USB");
            output = output.Replace("ac connector", "AC Connector");
            output = output.Replace("ac charger", "AC Charger");
            output = output.Replace("wifi", "WiFi");
            output = output.Replace("cable fault", "CABLE FAULT");

            return output;
        }

        private void CommitProblem()
        {
            string[] row = { (dgvProblems.Rows.Count+1).ToString(), CorrectCapitalization(txtProb1.Text), cmbStatus1.Text,"Remove","Check" };
            dgvProblems.Rows.Add(row);
            
            txtProb1.Clear();
            cmbStatus1.SelectedIndex = -1;
            cmbStatus1.Text = "";
            txtProb1.Focus();
            
            UpdateSolBoxes(dgvProblems.Rows.Count);
        }
        
        private void UpdateSolBoxes(int number_of_problems)
        {
            int number_of_sols = ((DataGridViewComboBoxColumn)dgvParts.Columns["SolutionNum"]).Items.Count;
            
            for(int i = 1; i <= number_of_problems; i++)
            {
                ((DataGridViewComboBoxColumn)dgvParts.Columns["SolutionNum"]).Items.Add(i.ToString());
            }
           
            for(int i = 0; i < number_of_sols; i++)
            {
                ((DataGridViewComboBoxColumn)dgvParts.Columns["SolutionNum"]).Items.RemoveAt(0);
            }
            /*
            ((DataGridViewComboBoxColumn)dgvParts.Columns["SolutionNum"]).Items.Clear();
            foreach(DataGridViewRow dgvr in dgvProblems.Rows)
            {
                ((DataGridViewComboBoxColumn)dgvParts.Columns["SolutionNum"]).Items.Add(dgvr.Cells["Num"].Value);
            }*/
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
        
        
        private void txtSR_Leave(object sender, EventArgs e)
        {
            PopulateSRData();
        }

        private void txtSR_TextChanged(object sender, EventArgs e)
        {
            
        }
        
        private void PopulateSRData()
        {
            //Attempt to find a previously done repair by another tech (this is used when unit fails PM and has to go back to repair)
            if (txtSR.Text == "")
            {
                dgvProblems.Rows.Clear();
                dgvParts.Rows.Clear();
                txtModel.Clear();
                txtSerialNum.Clear();
                txtCustomerName.Clear();
                return;
            }

            try
            {
                var metareader = new StreamReader(@"T:\! SR FOLDERS\" + txtSR.Text + "\\repair_meta");
                dgvProblems.Rows.Clear();
                dgvParts.Rows.Clear();
                txtModel.Clear();
                txtSerialNum.Clear();
                txtCustomerName.Clear();

                while (!metareader.EndOfStream)
                {
                    var values = metareader.ReadLine().Split('<');

                    if (values[0] == "i")
                    {
                        txtModel.Text = values[2];
                        txtSerialNum.Text = values[3];
                        txtCustomerName.Text = values[4];
                    }
                    else if (values[0] == "p")
                    {
                        string[] row = { values[1], CorrectCapitalization(values[2].ToLower()), values[3], "Remove", "Check" };
                        dgvProblems.Rows.Add(row);
                        UpdateSolBoxes(dgvProblems.Rows.Count);
                    }
                    else if (values[0] == "s")
                    {
                        string[] row = { values[1], values[2], values[3], values[4], values[5], values[6], values[7], values[8], values[9]};
                        dgvParts.Rows.Add(row);
                        
                    }
                }
                metareader.Close();

                CheckForCyclerParts();
                PopulateModelFromSerial();
            }
            catch
            {

                //If no meta data is found in the folder, try to populate the other fields using this:
                try
                {
                    var reader = new StreamReader(@"T:\! SR FOLDERS\" + txtSR.Text + "\\" + txtSR.Text + "_IncomingInventory.txt");
                    var line = reader.ReadLine().Split('<');

                    string sn = line[0];
                    string custnum = line[2];
                    string custname = line[3];

                    txtSerialNum.Text = sn;
                    txtCustomerName.Text = custname;
                    PopulateModelFromSerial();
                }
                catch
                {
                    txtSerialNum.Clear();
                    txtCustomerName.Clear();
                    txtModel.Clear();
                }
            }
        }
        
        private void txtSerialNum_Leave(object sender, EventArgs e)
        {
            PopulateModelFromSerial();
        }
        
        private void PopulateModelFromSerial()
        {
            if (txtSerialNum.Text.Length > 3)
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

                problems.Clear();
                try
                {
                    var reader = new StreamReader(@"T:\Databases\" + model + "_Problems");
                    while (!reader.EndOfStream)
                    {
                        problems.Add(reader.ReadLine().Split('<')[0].ToLower());
                    }
                    reader.Close();

                    txtProb1.AutoCompleteCustomSource.Clear();
                    txtProb1.AutoCompleteCustomSource.AddRange(problems.ToArray());
                }
                catch
                {
                    //do nothing
                }
            }
        }
        
        
        private void dgvParts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex]==senderGrid.Columns["SolutionNum"] &&
                e.RowIndex >= 0)
            {
                string charge=" ";
                try
                {
                    if (CheckForAbuse((string)senderGrid.Rows[e.RowIndex].Cells["SolutionNum"].Value))
                    {
                        charge = "ABUSE";
                    }
                    else
                    {
                        if (dgvProblems.Rows.Count > 0)
                        {
                            foreach(DataGridViewRow dgvr in dgvProblems.Rows)
                            {
                                if ((string)dgvr.Cells["Num"].Value == (string)senderGrid.Rows[e.RowIndex].Cells["SolutionNum"].Value)
                                {
                                    if((string)dgvr.Cells["Status"].Value== "observed but not verified" ||
                                        (string)dgvr.Cells["Status"].Value == "observed in the error log but not verified" ||
                                        (string)dgvr.Cells["Status"].Value == "not observed" ||
                                        (string)dgvr.Cells["Status"].Value == "replaced as part of repair process" ||
                                        (string)dgvr.Cells["Status"].Value == "worn" ||
                                        CheckIfNoCharge((string)dgvParts.Rows[e.RowIndex].Cells["PartNum"].Value))
                                    {
                                        charge = " ";
                                    }
                                    else if((string)dgvr.Cells["Status"].Value == "Customer Accommodation" || (string)dgvr.Cells["Status"].Value== "ECO")
                                    {
                                        charge = "N/C";
                                    }
                                    break;
                                }
                            }
                        }
                        else
                        {
                            charge = " ";
                        }
                    }
                    dgvParts.Rows[e.RowIndex].Cells["Charge"].Value = charge;
                }
                catch
                {
                    //something
                }
            }
        }

        private void dgvParts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex]==senderGrid.Columns["RemovePart"] &&
                e.RowIndex >= 0)
            {
                dgvParts.Rows.RemoveAt(e.RowIndex);
                txtPartNum.Focus();
            }
        }
        
        private void cmbStatus1_Leave(object sender, EventArgs e)
        {
            if (cmbStatus1.SelectedIndex >= 0)
            {
                CommitProblem();
            }
        }
       

        private void dgvProblems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if (senderGrid.Columns[e.ColumnIndex] == senderGrid.Columns["Remove"])
                {
                    string problem_num = (string)dgvProblems.Rows[e.RowIndex].Cells["Num"].Value;
                    int int_problem_num = Int32.Parse(problem_num);

                    for(int j = 0; j < dgvParts.Rows.Count; j++)
                    {
                        DataGridViewRow dgvr = dgvParts.Rows[j];
                        if ((string)dgvr.Cells["SolutionNum"].Value == problem_num)
                        {
                            dgvParts.Rows.Remove(dgvr);
                        }

                        else if (Int32.Parse((string)dgvr.Cells["SolutionNum"].Value) > int_problem_num)
                        {
                            dgvr.Cells["SolutionNum"].Value = "";
                            //dgvr.Cells["SolutionNum"].Value = (Int32.Parse((string)dgvr.Cells["SolutionNum"].Value) - 1).ToString();
                        }
                    }
                    
                    dgvProblems.Rows.RemoveAt(e.RowIndex);

                    int i = 1;
                    foreach(DataGridViewRow dgvr in dgvProblems.Rows)
                    {
                        dgvr.Cells["Num"].Value = i.ToString();
                        i++;
                    }
                    UpdateSolBoxes(dgvProblems.Rows.Count);
                }

                if (senderGrid.Columns[e.ColumnIndex] == senderGrid.Columns["PossibleRepairs"])
                {
                    PossibleRepairs PR = new PossibleRepairs(lblModel.Text, (string)dgvProblems.Rows[e.RowIndex].Cells["Description"].Value);
                    PR.Show();
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                GenerateRepairMetadata();
            }
            catch
            {
                GenerateRepairMetadata_backup();
                MessageBox.Show("WARNING - repair data could not be saved under 'repair_meta'! \nIt will be saved under 'repair_meta_backup.txt'. Please remember to rename it to 'repair_meta' as soon as possible");
                
            }
        }

        private void btnPreset1_Click(object sender, EventArgs e)
        {
            try
            {
                var reader = new StreamReader("Preset_1.txt");
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    
                    PopulatePartName(line);
                }
                reader.Close();
            }
            catch
            {
                //do nothing
            }
        }

        private void btnPreset2_Click(object sender, EventArgs e)
        {
            try
            {
                var reader = new StreamReader("Preset_2.txt");
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    
                    PopulatePartName(line);
                }
                reader.Close();
            }
            catch
            {
                //do nothing
            }
        }

        private void btnPreset3_Click(object sender, EventArgs e)
        {
            try
            {
                var reader = new StreamReader("Preset_3.txt");
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    
                    PopulatePartName(line);
                }
                reader.Close();
            }
            catch
            {
                //do nothing
            }
        }

        private void btnPreset4_Click(object sender, EventArgs e)
        {
            try
            {
                var reader = new StreamReader("Preset_4.txt");
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    
                    PopulatePartName(line);
                }
                reader.Close();
            }
            catch
            {
                //do nothing
            }
        }

        private void cmbStatus1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void btnEditNoCharge_Click(object sender, EventArgs e)
        {
            Process.Start("NC.txt");
        }

        private void btnEditCycler_Click(object sender, EventArgs e)
        {
            Process.Start("cycler_parts.txt");
        }

        private void btnEditNeverGoes_Click(object sender, EventArgs e)
        {
            Process.Start("never_goes.txt");
        }

        private void btnEstimate_Click(object sender, EventArgs e)
        {
            string output = @"C:\Users\Public\Estimate.csv";
            var writer = new StreamWriter(output);
            writer.WriteLine("Part,Part Num,Replacement Reason,Charge");

            foreach(DataGridViewRow row in dgvParts.Rows)
            {
                writer.WriteLine((string)row.Cells["PartName"].Value + "," + (string)row.Cells["PartNum"].Value + ",," + (string)row.Cells["Charge"].Value);
            }

            writer.WriteLine("Labour Hours: ");
            writer.Close();

            Process.Start(output);
        }

        private void SendEstimateEmail()
        {
                try
                {
                    Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
                    Microsoft.Office.Interop.Outlook.MailItem oMsg = (Microsoft.Office.Interop.Outlook.MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

                    Outlook.Recipients oRecips = (Outlook.Recipients)oMsg.Recipients;
                    Outlook.Recipient oRecip = (Outlook.Recipient)oRecips.Add("mcaamano@zoll.com");
                    oRecip = (Outlook.Recipient)oRecips.Add("jbowers@zoll.com");

                oRecip.Resolve();

                    oMsg.Subject = "SR " + txtSR.Text + " - Repair Estimate";
                    oMsg.Body = "Hi Admin Team,\n\nThis is the estimate for the unit under SR " + txtSR.Text + " from " + txtCustomerName.Text + "."+"Could you kindly forward this to the customer? \n\nThanks,\n\n" + txtTechName.Text;
                    //oMsg.Attachments.Add("c:/temp/test.txt", Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue, Type.Missing, Type.Missing);
                    oMsg.Display(true);

                }
                catch
                {
                    MessageBox.Show("Email function failed. Make sure Outlook is open and then try again");
                    return;
                }
            
        }

        private void PrintTextBoxContent()
        {

            #region Printer Selection
            PrintDialog printDlg = new PrintDialog();
            #endregion

            #region Create Document
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = "Print Document";
            printDoc.PrintPage += printDoc_PrintPage;
            printDlg.Document = printDoc;
            #endregion

            if (printDlg.ShowDialog() == DialogResult.OK)
                printDoc.Print();
        }

        void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            FontFamily[] fontFamilies;

            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile("Code39.ttf");
            fontFamilies = pfc.Families;
            Font code39 = new Font(fontFamilies[0], 18, FontStyle.Regular);
            Font regular = new Font(txtSR.Font.FontFamily, 14, FontStyle.Regular);
            Font small = new Font(txtSR.Font.FontFamily, 10, FontStyle.Regular);

            e.Graphics.DrawString("For Hi-Pot Use", small, Brushes.Black, 34, 0);
            e.Graphics.DrawString("PN: " + txtModel.Text, small, Brushes.Black, 34, 14);
            e.Graphics.DrawString("*" + txtModel.Text + "*", code39, Brushes.Black, 6, 30);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintTextBoxContent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            PrintTextBoxContent();
        }
    }

}
