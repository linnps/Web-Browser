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

            var items = HistoryManager.GetItems();
            listBox1.Items.Clear();

            foreach (var item in items)
            {
                //if (item.Title.Contains(key) || item.URL.Contains(key))
                string searchedString = String.Format("{0} {1} {2}", item.Date, item.Title, item.URL);
                if (Regex.IsMatch(searchedString, string.Format(@"\b{0}\b", Regex.Escape(key)), RegexOptions.IgnoreCase))
                    listBox1.Items.Add(string.Format("{0} {1} {2}", item.Date, item.Title, item.URL));
            }
            //if (key == "")
            //{
            //    MessageBox.Show("input keywords or a phrase");
            //}
            //else
            //{


            //}
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

        private void button2_Click(object sender, EventArgs e)
        {
            var toDeleteditem = HistoryManager.GetItems();
            foreach(var item in toDeleteditem)
            {
                HistoryManager.DeleteDatabaseItem(item);
            }

            ///refresh
            listBox1.Items.Clear();
        }
    }
}
