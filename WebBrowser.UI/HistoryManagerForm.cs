using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebBrowser.Logic;

namespace WebBrowser.UI
{
    public partial class HistoryManagerForm : Form
    {
        public HistoryManagerForm()
        {
            InitializeComponent();
        }

        private void HistoryManagerForm_Load(object sender, EventArgs e)
        {

            var items = HistoryManager.GetItems();
            listBox1.Items.Clear();

            foreach (var item in items)
            {
                listBox1.Items.Add(string.Format("{0} {1} {2}", item.Date, item.Title, item.URL));
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            String key = SearchTextBox.Text;

            if (key == "")
            {
                MessageBox.Show("input keywords or a phrase");
            }
            else
            {

                var items = HistoryManager.GetItems();
                listBox1.Items.Clear();

                foreach (var item in items)
                {
                    if (item.Title.Contains(key) || item.URL.Contains(key))
                        listBox1.Items.Add(string.Format("{0} {1} {2}", item.Date, item.Title, item.URL));
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int toDeletedItemIndex = listBox1.SelectedIndex;
            var toDeleteditem = HistoryManager.GetItems();
            HistoryManager.DeleteDatabaseItem(toDeleteditem.ElementAt(toDeletedItemIndex));

            ///refresh
            var items = HistoryManager.GetItems();
            listBox1.Items.Clear();

            foreach (var item in items)
            {
                listBox1.Items.Add(string.Format("{0} {1} {2}", item.Date, item.Title, item.URL));
            }
        }
    }
}
