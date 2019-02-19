using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendSMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                try
                {
                    string url = "http://smsc.vianett.no/v3/send.ashx?" +
                        "src=" + txtPhone.Text + "&" +
                        "dst=" + txtPhone.Text + " &" +
                      "msg=" + System.Web.HttpUtility.UrlEncode(txtMessage.Text, System.Text.Encoding.GetEncoding("ISO-8859-1")) + "&" +
                        "username=" + System.Web.HttpUtility.UrlEncode(txtUsername.Text) + "&" +
                        "password=" + System.Web.HttpUtility.UrlEncode(txtPassword.Text);
                    string result = client.DownloadString(url);
                    if (result.Contains("OK"))
                        MessageBox.Show("Your Message has been successfully sent.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Message send failure.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
