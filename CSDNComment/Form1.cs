using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using CommonTool;
using System.Runtime.InteropServices;
using System.IO;
using System.Net.Security;

namespace CSDNComment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            webBrowser1.Url = new Uri("http://blog.csdn.net/qxuewei/article/details/51394264");
        }

        private void GetCookies_Click(object sender, EventArgs e)
        {
           // webBrowser1.Document.GetElementById("comment_content").InnerText = "[url=http://www.newjson.com]json在线解析[/url]";
            webBrowser1.Navigate(new Uri( "http://blog.csdn.net/qiuxuewei2012/comment/submit?id=51394264"),"",  Encoding.Default.GetBytes("content=[url=http://www.newjson.com]json在线解析[/url]"), "");
        }

        public static string SendWebRequest(string URL, string postData, CookieCollection CookieCollection)
        {


            HttpWebRequest httpWebRequest;

            HttpWebResponse webResponse;

            Stream getStream;

            StreamReader streamReader;

            string getString = "";
     

                httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(URL);

                httpWebRequest.CookieContainer.Add(CookieCollection);// = new CookieContainer().Add(CookieCollection); ;

            httpWebRequest.Accept = "*/*";

            httpWebRequest.ContentType = "application/x-www-form-urlencoded";



            httpWebRequest.UserAgent = "User-Agent:Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.106 Safari/535.2";

            httpWebRequest.Method = "Post";
         
            byte[] byteRequest = Encoding.Default.GetBytes(postData);

            httpWebRequest.ContentLength = byteRequest.Length;

            Stream stream;

            stream = httpWebRequest.GetRequestStream();

            stream.Write(byteRequest, 0, byteRequest.Length);

            stream.Close();

            webResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            string header = webResponse.Headers.ToString();

            getStream = webResponse.GetResponseStream();

            streamReader = new StreamReader(getStream, Encoding.UTF8);

            getString = streamReader.ReadToEnd();

            streamReader.Close();

            getStream.Close();

            httpWebRequest.Abort();

            webResponse.Close();


            return getString;


        }
        public static CookieCollection SendWebRequestC(string URL, string postData, CookieContainer cookieContainer)
        {


            HttpWebRequest httpWebRequest;

            HttpWebResponse webResponse;

            Stream getStream;

            StreamReader streamReader;

            string getString = "";
            CookieCollection collect;

            httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(URL);

            // httpWebRequest.CookieContainer = cookieContainer;

            httpWebRequest.Accept = "*/*";

            httpWebRequest.ContentType = "application/x-www-form-urlencoded";



            httpWebRequest.UserAgent = "User-Agent:Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.106 Safari/535.2";

            httpWebRequest.Method = "Post";
          
            byte[] byteRequest = Encoding.Default.GetBytes(postData);

            httpWebRequest.ContentLength = byteRequest.Length;

            Stream stream;

            stream = httpWebRequest.GetRequestStream();

            stream.Write(byteRequest, 0, byteRequest.Length);

            stream.Close();

            webResponse = (HttpWebResponse)httpWebRequest.GetResponse();
         collect=   webResponse.Cookies;

            string header = webResponse.Headers.ToString();

            getStream = webResponse.GetResponseStream();

            streamReader = new StreamReader(getStream, Encoding.UTF8);

            getString = streamReader.ReadToEnd();

            streamReader.Close();

            getStream.Close();

            httpWebRequest.Abort();

            webResponse.Close();


            return collect;


        }
    }
}
