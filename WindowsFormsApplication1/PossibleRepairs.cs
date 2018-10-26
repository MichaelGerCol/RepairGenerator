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
    public partial class PossibleRepairs : Form
    {
        List<string> Parts_List = new List<string>();

        public PossibleRepairs()
        {
            InitializeComponent();

            LoadPartsList();
        }

        public void LoadPartsList()
        {
            Parts_List.Clear();

            var reader = new StreamReader(@"T:\Databases\Parts_List.csv");
            while (!reader.EndOfStream)
            {
                Parts_List.Add(reader.ReadLine());
            }
            reader.Close();
        }

        public PossibleRepairs(string model, string problem_description)
        {
            InitializeComponent();
            LoadPartsList();

            cmbModel.Text = model;

            txtProblem.Text = problem_description;

            LoadProblems();
            LoadRepairs(model,problem_description);
        }

        private void LoadProblems()
        {
            try
            {
                List<string> Problems = new List<string>();

                var reader = new StreamReader(@"T:\Databases\" + cmbModel.Text + "_Problems");
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    Problems.Add(line.Split('<')[0]);
                }
                reader.Close();

                txtProblem.AutoCompleteCustomSource.Clear();
                txtProblem.AutoCompleteCustomSource.AddRange(Problems.ToArray());
            }
            catch
            {
                MessageBox.Show("could not find");
            }
        }

        private void LoadRepairs(string model, string problem_description)
        {
            try
            {
                var reader = new StreamReader(@"T:\Databases\" + model + "_Problems");

                dgvPossibleRepair.Rows.Clear();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    var values = line.Split('<');

                    if (values[0] == problem_description.ToUpper())
                    {
                        for(int i = 1; i < values.Length; i++)
                        {
                            if(chkPartNames.Checked== true)
                            {
                                dgvPossibleRepair.Rows.Add(ReplacePartNumbers(values[i]));
                            }
                            else
                            {
                                dgvPossibleRepair.Rows.Add(values[i]);
                            }
                            
                        }
                    }
                }
                reader.Close();
            }
            catch
            {
                MessageBox.Show("could not find");
            }
        }

        private void txtProblem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgvPossibleRepair.Rows.Clear();

                LoadRepairs(cmbModel.Text,txtProblem.Text);
            }
        }

        private string ReplacePartNumbers(string part_num)
        {
            string output = "";
            var values = part_num.Split('+');
            
            for(int i = 0; i < values.Length; i++)
            {
                foreach(string S in Parts_List)
                {
                    if (S.Split(',')[0] == values[i])
                    {
                        output = output + S.Split(',')[1] + " + ";
                        break;
                    }
                }
            }

            output = output.Substring(0, output.Length - 3);

            return output;

        }

        private void chkPartNames_CheckedChanged(object sender, EventArgs e)
        {
            LoadRepairs(cmbModel.Text, txtProblem.Text);
        }

        private void PossibleRepairs_Load(object sender, EventArgs e)
        {

        }
    }
}
