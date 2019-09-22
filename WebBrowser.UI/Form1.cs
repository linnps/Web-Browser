using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowser.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("a simple homemade browser made by student Li-Kai Lin ID: 904012712");
        }

        private void exitWebBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabFunctionality tabFunc1 = new TabFunctionality();
            tabFunc1.Dock = DockStyle.Fill;
            TabPage newPage1 = new TabPage("New Tab");
            newPage1.Controls.Add(tabFunc1);
            this.tabControl1.TabPages.Add(newPage1);

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.T))
            {
                TabFunctionality tabFunc1 = new TabFunctionality();
                tabFunc1.Dock = DockStyle.Fill;
                TabPage newPage1 = new TabPage("New Tab");
                newPage1.Controls.Add(tabFunc1);
                this.tabControl1.TabPages.Add(newPage1);
            }
            if (e.Control && (e.KeyCode == Keys.W))
                this.tabControl1.TabPages.RemoveAt(this.tabControl1.SelectedIndex);
        }

        private void closeCurrentTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tabControl1.TabPages.RemoveAt(this.tabControl1.SelectedIndex);
        }

        private void manageHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var historyForm = new HistoryManagerForm();
            historyForm.ShowDialog();
        }
    }
}
