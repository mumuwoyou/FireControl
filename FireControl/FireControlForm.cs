using System;
using System.Windows.Forms;

namespace FireControl
{
    public partial class FireControlForm : Form
    {
        DateTime current;
        string names = "林琳,史丽娟,沈富娟,索亚芳";
        string[] nameArray;
        int index = 0;
        int index1 = 3;
        public FireControlForm()
        {
            InitializeComponent();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void FireControlForm_Load(object sender, EventArgs e)
        {
            this.webBrowser.Url = new Uri("http://223.4.70.2:85/FrameSet/Login.aspx");
            nameArray = names.Split(',');
            current = this.dateTimePicker1.Value;

        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            if (this.webBrowser.Url == new Uri("http://223.4.70.2:85/FrameSet/Login.aspx"))
            {
                MessageBox.Show("请先登入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (this.webBrowser.Url != new Uri("http://223.4.70.2:85/JCDAPage/XFGZJLPage/FHXC_SimpleAddPage.aspx"))
            {
                this.webBrowser.Url = new Uri("http://223.4.70.2:85/JCDAPage/XFGZJLPage/FHXC_SimpleAddPage.aspx");
                this.btnStart.Text = current.Date.ToString("yyyyMMdd");
                
            }
            else
            {
                
                HtmlElement tbDate = this.webBrowser.Document.All["ctl00_MainContent_txtRQ"];
                HtmlElement tbNumber = this.webBrowser.Document.All["ctl00_MainContent_txtBH"];
                HtmlElement tbName = this.webBrowser.Document.All["ctl00_MainContent_txtXCY"];
                HtmlElement tbCall = this.webBrowser.Document.All["ctl00_MainContent_txtXCCS"];
                HtmlElement tbContent = this.webBrowser.Document.All["ctl00_MainContent_txtFXWT"];
                HtmlElement tbChecker = this.webBrowser.Document.All["ctl00_MainContent_txtJCR"];
                HtmlElement btnAdd = this.webBrowser.Document.All["ctl00_MainContent_btnAdd"];

                //this.btnStart.Enabled = false;
                String c = current.Date.Year.ToString() + "年"
                         + current.Date.Month.ToString() + "月"
                         + current.Date.Day.ToString() + "日";
                tbDate.SetAttribute("Value", c);
                tbNumber.SetAttribute("Value", current.ToString("yyyyMMdd"));
                tbName.SetAttribute("Value", nameArray[index%4]+","+ nameArray[index1%4]);
                tbCall.SetAttribute("Value", "2");
                tbContent.SetAttribute("Value", "正常");
                tbChecker.SetAttribute("Value", "尹小龙");
                index += 1;
                index1 += 1;
                current = current.Date.AddDays(-1);
                this.btnStart.Text = current.ToString("yyyyMMdd");
                //this.btnStart.Enabled = true;
                btnAdd.InvokeMember("click");
               
                //this.webBrowser.Url = new Uri("http://223.4.70.2:85/JCDAPage/XFGZJLPage/FHXC_SimpleAddPage.aspx");
            }
                
                         
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            current = this.dateTimePicker1.Value;
            this.btnStart.Text = this.dateTimePicker1.Value.ToString("yyyyMMdd");
        }
    }
}
