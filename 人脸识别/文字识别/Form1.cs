using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Web;

namespace 文字识别
{
    public partial class Form1 : Form
    {
        
        string TokenString = "";

        public Form1()
        {
            InitializeComponent();
            TokenString = Token.GetTotek();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var img = GetImgBase64String(openFileDialog1.FileName);
                
                string host = "https://aip.baidubce.com/rest/2.0/ocr/v1/accurate_basic?access_token=" + TokenString;
                Encoding encoding = Encoding.UTF8;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
                request.Method = "post";
                request.ContentType = "application/x-www-form-urlencoded";
                request.KeepAlive = true;

                String str = "image=" + HttpUtility.UrlEncode(img,Encoding.UTF8);
                byte[] buffer = encoding.GetBytes(str);
                request.ContentLength = buffer.Length;
                request.GetRequestStream().Write(buffer, 0, buffer.Length);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string result = reader.ReadToEnd();
                MessageBox.Show(string.Format("通用文字识别:{0}", result));
            }
        }
        private string GetImgBase64String(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open);
            Byte[] imagebytes = new byte[fs.Length];  //二进制转换
            BinaryReader br = new BinaryReader(fs);
            imagebytes = br.ReadBytes(Convert.ToInt32(fs.Length)); //读取二进制流

            string img = Convert.ToBase64String(imagebytes);
            return img;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var img = GetImgBase64String(openFileDialog1.FileName);

                string host = "https://aip.baidubce.com/rest/2.0/ocr/v1/idcard?access_token=" + TokenString;
                Encoding encoding = Encoding.UTF8;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
                request.Method = "post";
                request.ContentType = "application/x-www-form-urlencoded";
                request.KeepAlive = true;
                String str = "id_card_side=front&image=" + HttpUtility.UrlEncode(img);
                byte[] buffer = encoding.GetBytes(str);
                request.ContentLength = buffer.Length;
                request.GetRequestStream().Write(buffer, 0, buffer.Length);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string result = reader.ReadToEnd();

                MessageBox.Show(string.Format("身份证识别:{0}", result));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var img = GetImgBase64String(openFileDialog1.FileName);

                string host = "https://aip.baidubce.com/rest/2.0/ocr/v1/bankcard?access_token=" + TokenString;
                Encoding encoding = Encoding.UTF8;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
                request.Method = "post";
                request.ContentType = "application/x-www-form-urlencoded";
                request.KeepAlive = true;
                String str = "image=" + HttpUtility.UrlEncode(img);
                byte[] buffer = encoding.GetBytes(str);
                request.ContentLength = buffer.Length;
                request.GetRequestStream().Write(buffer, 0, buffer.Length);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string result = reader.ReadToEnd();
                MessageBox.Show(string.Format("银行卡识别:{0}", result));
            }

        }
    }
}
