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

        public TabFunctionality()
        {
            InitializeComponent();
        }


        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (webHistoryB.Count == 0)
            {
                webHistoryB.Push(textBox1.Text);
                webBrowser1.Navigate(textBox1.Text);
            }
            else if (webHistoryB.Count != 0 && textBox1.Text != webHistoryB.Peek())
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
            webHistoryF.Push(textBox1.Text);
            if (webHistoryB.Count == 0)
            {
                webBrowser1.Navigate(textBox1.Text);
            }
            else if (textBox1.Text == webHistoryB.Peek())
            {
                while (textBox1.Text == webHistoryB.Peek())
                {
                    webHistoryB.Pop();
                }
                string currentLink = webHistoryB.Pop();
                textBox1.Text = currentLink;
                webBrowser1.Navigate(currentLink);
            }
            else
            {
                string currentLink = webHistoryB.Pop();
                textBox1.Text = currentLink;
                webBrowser1.Navigate(currentLink);
            }
            
            
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            webHistoryB.Push(textBox1.Text);
            if (webHistoryF.Count == 0)
            {
                webBrowser1.Navigate(textBox1.Text);
            }
            else
            {
                string currentLink = webHistoryF.Pop();
                textBox1.Text = currentLink;
                webBrowser1.Navigate(currentLink);
            }  
        }

        private void textBox1_KeyUp_1(object sender, KeyEventArgs e)

        {
            if (e.KeyCode == Keys.Enter)
            {
                if (webHistoryB.Count == 0)
                {
                    webHistoryB.Push(textBox1.Text);
                    webBrowser1.Navigate(textBox1.Text);
                }
                else if (webHistoryB.Count != 0 && textBox1.Text != webHistoryB.Peek())
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
    }
}
