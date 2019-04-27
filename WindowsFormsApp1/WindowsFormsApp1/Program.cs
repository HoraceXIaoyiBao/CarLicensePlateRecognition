using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.UI;
using Emgu.CV.Structure;

namespace WindowsFormsApp1
{
     class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Picture p = new Picture();
            //p.Capvideo();
           
            //简单图像处理
            Mat img = CvInvoke.Imread("C://Users//n10322248//OneDrive - Queensland University of Technology//2.jpg");
            if (img.IsEmpty)
            {
                Console.WriteLine("can not load the image \n");
            }
            CvInvoke.Imshow("Image", img);


            Mat grayImg = p.Rgb2gery(img);

            //sobel算子查找边缘
             p.sobelSolve(grayImg);


            //使用canny算子查找边缘
            p.cannySolve(grayImg);
          

            p.cutPicture(img);


            CvInvoke.WaitKey(0);
        }


       

    }
}
