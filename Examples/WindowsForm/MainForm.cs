using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void loadJsonButton_Click(object sender, EventArgs e)
        {
            string file = "Data\\Example.json";

            string json = null;
            using (var reader = new StreamReader(File.OpenRead(file)))
            {
                json = reader.ReadToEnd();
            }

            try
            {
                jsonTreeView.ShowJson(json);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Fail to show JSON. " + exc);
            }
        }
    }
}
