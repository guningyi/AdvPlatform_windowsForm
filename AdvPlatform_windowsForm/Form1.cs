using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace AdvPlatform_windowsForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dictProxy = new Dictionary<string, string>();
            dictUnionUrl = new Dictionary<string, int>();
        }
        private void button1_click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                         System.IO.StreamReader(openFileDialog1.FileName);
                //MessageBox.Show(sr.ReadToEnd());
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    listBox1.Items.Add(line);
                    //加载地址进入Dict
                    string[] ip_port = line.Split(':');
                    dictProxy.Add(ip_port[0],ip_port[1]);
                }

                //显式打开文件的路径
                string filePath = openFileDialog1.FileName;
                label1.Text = filePath;

             
                sr.Close();
            }
        }


#if false
        private void button3_Click(object sender, EventArgs e)
        {
            //取出配置好的代理与访问地址
            string proxy = "http://106.75.128.89:80";
            foreach (KeyValuePair<string, string> kvp in dictProxy)
            {
                proxy = "http://" + kvp.Key + ":" + kvp.Value;
            }

            string url = "http://www.baidu.com";
            int count = 0;
            foreach (KeyValuePair<string, int> kvpp in dictUnionUrl)
            {
                url = "http://" + kvpp.Key;
                count = kvpp.Value;
            }

            //构造代理对象
            WebProxy proxyObject = new WebProxy(proxy, true);
            //构造Http请求
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Proxy = proxyObject;
            req.Timeout = 10000;
            req.Method = "PUT";

            //TODO:清空cookies

            //构造Http应答接受器
            HttpWebResponse webResponse = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(webResponse.GetResponseStream(), System.Text.Encoding.UTF8);
            string content = reader.ReadToEnd();
            reader.Close();

            //用输出窗口显式http response的内容
            MessageBox.Show(content);

        }
#endif
        private void button3_Click(object sender, EventArgs e)
        {
            //取出配置好的代理与访问地址
            string proxy = "http://106.75.128.89:80";
            foreach (KeyValuePair<string, string> kvp in dictProxy)
            {
                proxy = "http://" + kvp.Key + ":" + kvp.Value;
            }

            string url = "http://www.baidu.com";
            int count = 0;
            foreach (KeyValuePair<string, int> kvpp in dictUnionUrl)
            {
                url = "http://" + kvpp.Key;
                count = kvpp.Value;
            }

            webBrowser1.Navigate(url);

            //用输出窗口显式http response的内容
            //MessageBox.Show(content);

        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                         System.IO.StreamReader(openFileDialog1.FileName);
                //MessageBox.Show(sr.ReadToEnd());
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    listBox2.Items.Add(line);
                    dictUnionUrl.Add(line, 1);
                }

                string filePath = openFileDialog1.FileName;
                label2.Text= filePath ;

                sr.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
