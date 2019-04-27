using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.UI;
using Emgu.CV.Structure;

using System.Drawing;
namespace WindowsFormsApp1
{
    class Picture
    {
                public void Capvideo()
                {
                    ImageViewer viewer = new ImageViewer();
                    //捕获
                    VideoCapture capture = new VideoCapture();
                    Application.Idle += new EventHandler(delegate (object sender, EventArgs e)
                    {
                        //获得的图像
                        viewer.Image = capture.QueryFrame();
                    });
                    //显示
                    viewer.ShowDialog();
                }

                public Mat Rgb2gery(Mat img)
                {

                    Mat grayImg = new Mat();
                    //转换为灰度图像

                    CvInvoke.CvtColor(img, grayImg, ColorConversion.Rgb2Gray);
                    CvInvoke.Imshow("Gray Image", grayImg);
                    return grayImg;
                }

                    //sobel算子查找边缘
                public Mat sobelSolve(Mat grayImg)
                {

                    Mat sobelImg = new Mat();
                    CvInvoke.Sobel(grayImg, sobelImg, grayImg.Depth, 1, 0);
                    CvInvoke.Imshow("sobel Img ", sobelImg);
                    return sobelImg;
                }

                 //使用canny算子查找边缘
                public Mat cannySolve(Mat grayImg)
                {

                    Mat cannyImg = new Mat();
                    CvInvoke.Canny(grayImg, cannyImg, 20, 40);
                    CvInvoke.Imshow("Canny Image", cannyImg);
                    return cannyImg;
                }
        public Mat cutPicture(Mat img)
        {
            Console.WriteLine(img.Rows);
            Console.WriteLine(img.Cols);
            Rectangle rect = new Rectangle(120, 220, 120, 40);
            Mat imgRoi= new Mat(img, rect);

         

            // Mat imgcut = img.[100: 200, 100:200];

            CvInvoke.Imshow(imgRoi.Rows.ToString()+" "+ imgRoi.Cols.ToString(), imgRoi);
            return img;
        }
    }
}
