using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace CSDNComment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            webBrowser1.Url =new Uri( "http://www.csdn.net/");
        }

        private void GetCookies_Click(object sender, EventArgs e)
        {
            CookieContainer myCookieContainer = new CookieContainer();
        if (webBrowser1.Document.Cookie != null)
        {
            string cookieStr = webBrowser1.Document.Cookie;
            string[] cookstr = cookieStr.Split(';');
            foreach (string str in cookstr)
            {
                string[] cookieNameValue = str.Split('=');
                Cookie ck = new Cookie(cookieNameValue[0].Trim().ToString(), cookieNameValue[1].Trim().ToString());
                ck.Domain = ".csdn.net";
                myCookieContainer.Add(ck);
            }
        }
        }
    }
}
