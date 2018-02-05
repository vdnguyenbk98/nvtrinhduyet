using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate(txtUrl.Text);

          
            webBrowser1.DocumentCompleted += WebBrowser1_DocumentCompleted;
        }

        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            tabControl1.SelectedTab.Text = webBrowser1.DocumentTitle;
        }

       

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            WebBrowser web = tabControl1.SelectedTab.Controls[0] as WebBrowser;
            if(web != null)
            {
                web.Navigate(txtUrl.Text);
            }
        }
        WebBrowser webTab = null;
        private void btnNewtab_Click(object sender, EventArgs e)
        {
            TabPage tab = new TabPage();
            tab.Text = "New Tab";
            tabControl1.Controls.Add(tab);
            tabControl1.SelectTab(tabControl1.TabCount - 1);
            webTab = new WebBrowser() { ScriptErrorsSuppressed = true };
            webTab.Parent = tab;
            webTab.Dock = DockStyle.Fill;
           
           
            webTab.DocumentCompleted += WebTab_DocumentCompleted;
        }

        private void WebTab_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            tabControl1.SelectedTab.Text = webTab.DocumentTitle;

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            WebBrowser web = tabControl1.SelectedTab.Controls[0] as WebBrowser;
            if (web != null)
            {
                if (web.CanGoBack)
                    web.GoBack();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            WebBrowser web = tabControl1.SelectedTab.Controls[0] as WebBrowser;
            if (web != null)
            {
                if (web.CanGoForward)
                    web.GoForward();
            }

        }

        private void txtUrl_KeyDown(object sender, KeyEventArgs e)
        {
            WebBrowser web = tabControl1.SelectedTab.Controls[0] as WebBrowser;
            if (web != null)
            {
                if(e.KeyCode==Keys.Enter)
                { web.Navigate(txtUrl.Text); }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            WebBrowser web = tabControl1.SelectedTab.Controls[0] as WebBrowser;
           if(web!=null)
            {
                web.GoHome();
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            WebBrowser web = tabControl1.SelectedTab.Controls[0] as WebBrowser;
            if (web != null)
            {
                web.Refresh();
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            WebBrowser web = tabControl1.SelectedTab.Controls[0] as WebBrowser;
            if (web != null)
            {
                web.Stop();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.Controls.Clear();

        }
    }
}
