using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebBrowser.Logic;

namespace WebBrowser.UI
{
    public partial class TabFunctionality : UserControl
    {
        Stack<string> webHistoryB = new Stack<string>();
        Stack<string> webHistoryF = new Stack<string>();
        int eventReconizer = 0;



        public TabFunctionality()
        {
            InitializeComponent();
        }


        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            eventReconizer = 1;
            if (webHistoryB.Count == 0)
            {
                webHistoryB.Push(textBox1.Text);
                webBrowser1.Navigate(textBox1.Text);
            }
            else if (textBox1.Text != webHistoryB.Peek())
            {
                webHistoryB.Push(textBox1.Text);
                webBrowser1.Navigate(textBox1.Text);
            }
            else
            {
                webBrowser1.Navigate(textBox1.Text);
            }
            

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            eventReconizer = 1;
            if (webHistoryB.Count == 0)
            {
                webBrowser1.Navigate(textBox1.Text);
            }
            else if (textBox1.Text == webHistoryB.Peek())
            {
                webHistoryF.Push(textBox1.Text);
                while (webHistoryB.Count != 1 && textBox1.Text == webHistoryB.Peek())
                {
                    webHistoryB.Pop();
                }
                string currentLink = webHistoryB.Pop();
                textBox1.Text = currentLink;
                webBrowser1.Navigate(currentLink);
            }
            else
            {
                webHistoryF.Push(textBox1.Text);
                string currentLink = webHistoryB.Pop();
                textBox1.Text = currentLink;
                webBrowser1.Navigate(currentLink);
            }
            



        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            eventReconizer = 1;
            if (webHistoryF.Count == 0)
            {
                webBrowser1.Navigate(textBox1.Text);
            }
            else if (textBox1.Text == webHistoryF.Peek())
            {
                webHistoryB.Push(textBox1.Text);
                while (webHistoryF.Count != 1 && textBox1.Text == webHistoryF.Peek())
                {
                    webHistoryF.Pop();
                }
                string currentLink = webHistoryF.Pop();
                textBox1.Text = currentLink;
                webBrowser1.Navigate(currentLink);
            }
            else
            {
                webHistoryB.Push(textBox1.Text);
                string currentLink = webHistoryF.Pop();
                textBox1.Text = currentLink;
                webBrowser1.Navigate(currentLink);
            }
            
        }

        private void textBox1_KeyUp_1(object sender, KeyEventArgs e)

        {
            eventReconizer = 1;
            if (e.KeyCode == Keys.Enter)
            {
                if (webHistoryB.Count == 0)
                {
                    webHistoryB.Push(textBox1.Text);
                    webBrowser1.Navigate(textBox1.Text);
                }
                else if (textBox1.Text != webHistoryB.Peek())
                {
                    webHistoryB.Push(textBox1.Text);
                    webBrowser1.Navigate(textBox1.Text);
                }
                else
                {
                    webBrowser1.Navigate(textBox1.Text);
                }
                
            }
            
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

            var historyNew = new HistoryItem();
            historyNew.URL = webBrowser1.Url.ToString();
            historyNew.Title = webBrowser1.DocumentTitle;
            historyNew.Date = DateTime.Now;
            HistoryManager.AddItem(historyNew);
            if (eventReconizer == 1)
            {
                eventReconizer = 0;



            }
            else
            {
                if (webBrowser1.Url.ToString().Contains(textBox1.Text))
                {
                    eventReconizer = 0;
                }
                else
                {
                    webHistoryB.Push(webBrowser1.Url.ToString());
                    textBox1.Text = webBrowser1.Url.ToString();

                } 
            }


            toolStripStatusLabel1.Text = "done";

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(textBox1.Text);
            eventReconizer = 1;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            var items = BookmarkManager.GetItems();

            if (items.Count == 0)
            {
                var bookmarkNew = new BookmarkItem();
                bookmarkNew.URL = webBrowser1.Url.ToString();
                bookmarkNew.Title = webBrowser1.DocumentTitle;
                BookmarkManager.AddItem(bookmarkNew);
            }
            else
            {
                List<string> URLs = new List<string>();

                foreach (var item in items)
                {
                    URLs.Add(item.URL);
                }
                if (!URLs.Contains(webBrowser1.Url.ToString()))
                {
                    var bookmarkNew = new BookmarkItem();
                    bookmarkNew.URL = webBrowser1.Url.ToString();
                    bookmarkNew.Title = webBrowser1.DocumentTitle;
                    BookmarkManager.AddItem(bookmarkNew);
                }
            }

        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Maximum = (int) e.MaximumProgress;
            toolStripProgressBar1.Value = (int)e.CurrentProgress < 0 || (int)e.CurrentProgress > (int)e.MaximumProgress ? (int)e.MaximumProgress : (int)e.CurrentProgress;
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            toolStripStatusLabel1.Text = "loading";
        }
    }
}
