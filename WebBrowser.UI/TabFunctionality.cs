using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(textBox1.Text);
            eventReconizer = 1;
        }
    }
}
