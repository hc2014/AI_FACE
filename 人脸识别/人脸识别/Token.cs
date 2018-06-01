using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace 人脸识别
{
   public class Token
    {
        public string access_token { get; set; }

        public const string APIKey = "";//根据自己创建的百度AI应用 填写对应的KEY
        public const string SecretKey = "";

        public static string GetTotek()
        {
            var url = string.Format("https://aip.baidubce.com/oauth/2.0/token?grant_type=client_credentials&client_id={0}&client_secret={1}", APIKey, SecretKey);
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;//创建请求对象
            request.Method = "POST";//请求方式
            request.ContentType = "application/x-www-form-urlencoded";//链接类型

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            
            

            using (Stream s = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(s, Encoding.UTF8);
                
                var tokey= JsonConvert.DeserializeObject<Token>(reader.ReadToEnd());
                return tokey.access_token;
            }
        }

    }
}
