//----------------------------------------------------------------------------
//  Copyright (C) 2004-2017 by EMGU Corporation. All rights reserved.       
//----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.Cvb;
using Emgu.CV.UI;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.VideoSurveillance;
using FaceDetection;
using Emgu.CV.Cuda;
using AOP.Common;
using System.Drawing.Imaging;
using Baidu.Aip.API;
using System.Threading;
using BaiduAIAPI.Model;

namespace VideoSurveilance
{
    public partial class VideoSurveilance : Form
    {

        private static VideoCapture _cameraCapture;

        private static BackgroundSubtractor _fgDetector;
        private static Emgu.CV.Cvb.CvBlobDetector _blobDetector;
        private static Emgu.CV.Cvb.CvTracks _tracker;

        private static Queue<ImageModel> FacIdentifyQueue = new Queue<ImageModel>();
        public Image faceImage;
        Thread t1;
        public VideoSurveilance()
        {
            InitializeComponent();
            Run();
        }

        void Run()
        {
            try
            {
                _cameraCapture = new VideoCapture();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }

            _fgDetector = new Emgu.CV.VideoSurveillance.BackgroundSubtractorMOG2();
            _blobDetector = new CvBlobDetector();
            _tracker = new CvTracks();

            Application.Idle += ProcessFrame;
        }

        void ProcessFrame(object sender, EventArgs e)
        {
            Mat frame = _cameraCapture.QueryFrame();
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

            long detectionTime;

            List<Rectangle> faces = new List<Rectangle>();
            List<Rectangle> eyes = new List<Rectangle>();

            IImage image = (IImage)frame;//这一步是重点
            faceImage = frame.Bitmap;
            DetectFace.Detect(image
             , "haarcascade_frontalface_default.xml", "haarcascade_eye.xml",
              faces, eyes,
              out detectionTime);

            #region 多人识别
            Graphics g1 = Graphics.FromImage(frame.Bitmap);
            List<FaceIdentifyModel> tempList = new List<FaceIdentifyModel>();
            foreach (Rectangle face in faces)
            {
                Image rectImage1 = ImageHelper.CaptureImage(frame.Bitmap, face);// 自己封装的方法，通过大图截取矩形框的人脸图片，返回Image 对象
                FaceIdentifyModel MoreIdentifyInfo = FaceAPI.FaceIdentify(rectImage1, tb_Group.Text.Trim(), 1, 1);
                MoreIdentifyInfo.rect = face;
                tempList.Add(MoreIdentifyInfo);
            }
            Color color_of_pen1 = Color.Gray;
            color_of_pen1 = Color.Yellow;
            Pen pen1 = new Pen(color_of_pen1, 2.0f);

            Font font1 = new Font("微软雅黑", 16, GraphicsUnit.Pixel);
            SolidBrush drawBrush1 = new SolidBrush(Color.Yellow);


            tb_Identify.Text = tempList.ToJson();
            foreach (var t in tempList)
            {
                g1.DrawRectangle(pen1, t.rect);

                if (t.result != null)
                {
                    g1.DrawString(t.result[0].user_info.Replace("，", "\r\n"), font1, drawBrush1, new Point(t.rect.X + 20, t.rect.Y - 20));
                }
                125             }
            #endregion

            imageBox1.Image = frame;
            imageBox2.Image = forgroundMask;
        }



        private void btn_Screenshot_Click(object sender, EventArgs e)
        {
            if (faceImage != null)
            {
                System.Drawing.Image ResourceImage = faceImage;
                string fileDir = System.Environment.CurrentDirectory + "\\Snapshot\\";
                FileHelper.CreateDir(fileDir);
                string filePath = fileDir + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
                ResourceImage.Save(filePath);
                MessageBox.Show("保存成功！" + filePath);
            }

        }
    }
}