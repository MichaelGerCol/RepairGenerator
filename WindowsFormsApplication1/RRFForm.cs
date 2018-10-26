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
    public partial class RRFForm : Form
    {
        public RRFForm()
        {
            InitializeComponent();
        }

        public RRFForm(string sr)
        {
            InitializeComponent();

            lblSR.Text = sr;
        }

        private void RRFForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbStatus.Text == "")
            {
                MessageBox.Show("Please select a status.");
                return;
            }

            try
            {
                List<string> temp = new List<string>();

                var reader = new StreamReader(@"T:\Databases\Kanban Records\_RRF.txt");
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line.Split('`')[0] == lblSR.Text)
                    {
                        var values = line.Split('`');
                        values[8] = cmbStatus.Text;
                        values[9] = txtComment.Text;

                        temp.Add(String.Join("`", values));
                    }
                    else
                    {
                        temp.Add(line);
                    }
                }
                reader.Close();

                var writer = new StreamWriter(@"T:\Databases\Kanban Records\_RRF.txt");
                foreach (string S in temp)
                {
                    writer.WriteLine(S);
                }
                writer.Close();

                this.Close();
            }catch
            {
                MessageBox.Show("There was a problem reading or writing to the RRF file. Try again later.");
                return;
            }
        }
    }
}
