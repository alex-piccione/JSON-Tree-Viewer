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

        private void loadJsonButton_1_Click(object sender, EventArgs e) => LoadJson("Data\\Example 01.json");
        private void loadJsonButton_2_Click(object sender, EventArgs e) => LoadJson("Data\\Example 02.json");


        private void LoadJson(string file)
        {       
            try
            {
                var json = File.ReadAllText(file);
                jsonTreeView.ShowJson(json);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Fail to show JSON. " + exc);
            }
        }
    }
}
