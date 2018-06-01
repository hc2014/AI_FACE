using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using System.IO;
using System.Net;
using Emgu.CV.Cvb;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using FaceDetection;
using AOP.Common;
using System.Drawing.Imaging;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Threading;

namespace 人脸识别
{
    public partial class Form1 : Form
    {
        private static VideoCapture _cameraCapture;
        
        private static IBackgroundSubtractor _fgDetector;
        private static Emgu.CV.Cvb.CvBlobDetector _blobDetector;
        private static Emgu.CV.Cvb.CvTracks _tracker;
        private Image faceImage;
        List<Rectangle> faces = new List<Rectangle>();
        List<Rectangle> eyes = new List<Rectangle>();
        Mat frame;
        string TokenStr = "";
        

        public Form1()
        {
            InitializeComponent();
            //Run();
            SearchFace();

        }

        void SearchFace()
        {
            Thread.Sleep(2000);

            Task.Factory.StartNew(() =>
            {
                string filePath = CreateDir();

                while (true)
                {
                    if (faces.Count > 0)
                    {
                        SaveImg(filePath);

                        var img = GetImgBase64String(filePath);

                        SearchFace(TokenStr, img);
                        return;
                    }
                }
            });
        }

        void Run()
        {
            TokenStr = Token.GetTotek();
            
            try
            {
                _cameraCapture = new VideoCapture();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }

            _fgDetector = new BackgroundSubtractorMOG2();
            _blobDetector = new CvBlobDetector();
            _tracker = new CvTracks();

            Application.Idle += ProcessFrame;
        }


        void ProcessFrame(object sender, EventArgs e)
        {
            frame = _cameraCapture.QueryFrame();
            Mat smoothedFrame = new Mat();
            CvInvoke.GaussianBlur(frame, smoothedFrame, new Size(3, 3), 1); //filter out noises
                                                                            //frame._SmoothGaussian(3); 

            #region use the BG/FG detector to find the forground mask
            Mat forgroundMask = new Mat();
            _fgDetector.Apply(smoothedFrame, forgroundMask);
            #endregion

            CvBlobs blobs = new CvBlobs();
            _blobDetector.Detect(forgroundMask.ToImage<Gray, byte>(), blobs);
            blobs.FilterByArea(100, int.MaxValue);

            float scale = (frame.Width + frame.Width) / 2.0f;
            _tracker.Update(blobs, 0.01 * scale, 5, 5);


            foreach (var pair in _tracker)
            {
                CvTrack b = pair.Value;
                CvInvoke.Rectangle(frame, b.BoundingBox, new MCvScalar(255.0, 255.0, 255.0), 2);
                CvInvoke.PutText(frame, b.Id.ToString(), new Point((int)Math.Round(b.Centroid.X), (int)Math.Round(b.Centroid.Y)),
                    FontFace.HersheyPlain, 1.0, new MCvScalar(255.0, 255.0, 255.0));
            }

            imageBox1.Image = frame;
            imageBox2.Image = forgroundMask;
            
            GetFaces();
        }


        private void GetFaces()
        {
            long detectionTime;
            IImage image = (IImage)frame;//这一步是重点
            faceImage = frame.Bitmap;
            DetectFace.Detect(image
             , "haarcascade_frontalface_default.xml", "haarcascade_eye.xml",
              faces, eyes,
              out detectionTime);
        }

        private void btn_prtAndAdd_Click(object sender, EventArgs e)
        {
            //GetFaces();
            if (btn_prtAndAdd.Text == "开始")
            {
                Run();
                btn_prtAndAdd.Text = "截图并上传人脸";
            }


            string filePath = CreateDir();

            if (faces.Count == 0)
            {
                MessageBox.Show("无法抓取人脸，请对准摄像头");
                return;
            }

            //AOP.Common.ImageHelper 是第三方的dll  AOP.Common.ImageHelper  用到了4.5的框架，如果不用这个dll 就可以直接用.net framework 4.0
            //ImageHelper.CaptureImage(faceImage, faces.Last(), filePath);

            #region 实现 ImageHelper.CaptureImage 

            SaveImg(filePath);

            #endregion

            var img = GetImgBase64String(filePath);

            AddFace(TokenStr, img);
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

        private void SaveImg(string filePath)
        {
            Rectangle rect = faces.Last();
            Bitmap bitmap = new Bitmap(rect.Width, rect.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.DrawImage(faceImage, 0, 0, rect, GraphicsUnit.Pixel);
            Image saveImage = Image.FromHbitmap(bitmap.GetHbitmap());
            saveImage.Save(filePath, ImageFormat.Png);
            saveImage.Dispose();
            graphics.Dispose();
            bitmap.Dispose();

        }

        private string CreateDir()
        {
            string fileDir = System.Environment.CurrentDirectory + "\\Snapshot\\";
            //FileHelper.CreateDir(fileDir);
            if (!Directory.Exists(fileDir))
            {
                Directory.CreateDirectory(fileDir);
            }

            string filePath = fileDir + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
            return filePath;
        }

        private string AddFace(string tokey,string img)
        {
            User user = new User() {
                Age = txtUserAge.Text,
                Dept = txtUserDept.Text,
                Remark = txtUserRemark.Text,
                UserName = txtUserName.Text
            };

            FaceModle face = new FaceModle()
            {
                image = img,
                user_id = user.UserName,
                user = user
            };


            string token = tokey;
            string host = "https://aip.baidubce.com/rest/2.0/face/v3/faceset/user/add?access_token=" + token;
            Encoding encoding = Encoding.Default;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
            request.Method = "post";
            request.KeepAlive = true;
            //String str = "{\"image\":\""+ img + "\",\"image_type\":\"BASE64\",\"group_id\":\"testGroup\",\"user_id\":\""+ txtUserName.Text 
            //    + "\",\"user_info\":\""+txtUserName.Text+"\",\"quality_control\":\"LOW\",\"liveness_control\":\"NORMAL\"}";

            string str = JsonConvert.SerializeObject(face);

            byte[] buffer = encoding.GetBytes(str);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
            string result = reader.ReadToEnd();
            MessageBox.Show(string.Format("人脸注册:{0}", result));
            return result;
        }

        private void SearchFace(string token,string img)
        {

            string host = "https://aip.baidubce.com/rest/2.0/face/v3/search?access_token=" + token;
            Encoding encoding = Encoding.Default;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
            request.Method = "post";
            request.KeepAlive = true;

            String str = "{\"image\":\""+img+"\",\"image_type\":\"BASE64\",\"group_id_list\":\"testGroup\",\"quality_control\":\"LOW\",\"liveness_control\":\"NORMAL\"}";
            byte[] buffer = encoding.GetBytes(str);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
            string result = reader.ReadToEnd();
            MessageBox.Show(string.Format("人脸搜索:{0}", result));
        }


        public class FaceModle
        {
            public string image { get; set; }

            public string image_type { get;  } = "BASE64";

            public string group_id { get;} = "testGroup";

            public string user_id { get; set; }

            public User user { get; set; }

            public string quality_control { get;  } = "LOW";

            public string liveness_control { get; } = "NORMAL";
        }


        public class User
        {
            public string UserName { get; set; }
            public string Age { get; set; }
            public string Dept { get; set; }
            public string Remark { get; set; }
        }

        private void btn_uplpad_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var img = GetImgBase64String(openFileDialog1.FileName);

                AddFace(TokenStr, img);
            }
        }
    }
}
