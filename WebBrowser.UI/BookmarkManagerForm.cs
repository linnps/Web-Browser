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
    public partial class BookmarkManagerForm : Form
    {
        public BookmarkManagerForm()
        {
            InitializeComponent();
        }

        private void BookmarkManagerForm_Load(object sender, EventArgs e)
        {
            var items = BookmarkManager.GetItems();
            listBox1.Items.Clear();

            foreach (var item in items)
            {
                listBox1.Items.Add(string.Format("{0} {1}", item.Title, item.URL));
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            String key = SearchTextBox.Text;

            var items = BookmarkManager.GetItems();
            listBox1.Items.Clear();

            foreach (var item in items)
            {
                //if (item.Title.Contains(key) || item.URL.Contains(key))
                string searchedString = String.Format("{0} {1}", item.Title, item.URL);
                if (Regex.IsMatch(searchedString, string.Format(@"\b{0}\b", Regex.Escape(key)), RegexOptions.IgnoreCase))
                    listBox1.Items.Add(string.Format("{0} {1}", item.Title, item.URL));
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            int toDeletedItemIndex = listBox1.SelectedIndex;
            var toDeleteditem = BookmarkManager.GetItems();
            BookmarkManager.DeleteDatabaseItem(toDeleteditem.ElementAt(toDeletedItemIndex));

            ///refresh
            var items = BookmarkManager.GetItems();
            listBox1.Items.Clear();

            foreach (var item in items)
            {
                listBox1.Items.Add(string.Format("{0} {1}", item.Title, item.URL));
            }
        }
    }
}
