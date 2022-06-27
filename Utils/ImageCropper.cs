using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;
using System.Drawing;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace RSB_Ofish_System.Utils
{
    public class ImageCropper : IDisposable
    {
        private IConfiguration _configuration;
        public ImageCropper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public ImageCropper()
        {

        }
        Image<Bgr, Byte> croptedImage;
        public void Dispose()
        {
            croptedImage.Dispose();
        }

        public Bitmap getCrropped(Bitmap originalImage)
        {
            
            Image<Bgr, Byte> src = originalImage.ToImage<Bgr, Byte>();



            int scale = 1;
            if (src.Width > 500)
            {
                scale = 2;
            }
            if (src.Width > 1000)
            {
                scale = 10;
            }
            if (src.Width > 10000)
            {
                scale = 100;
            }
            var size = new Size(src.Width / scale, src.Height / scale);

            Image<Bgr, Byte> srcNewSize = new Image<Bgr, Byte>(size);
            CvInvoke.Resize(src, srcNewSize, size);
            //Convert image to grayscale
            UMat grayImage = new UMat();
            CvInvoke.CvtColor(srcNewSize, grayImage, ColorConversion.Bgr2Gray);
            
            //Gaussian filtering is used to remove noise
            CvInvoke.GaussianBlur(grayImage, grayImage, new Size(1, 1), 0);

           
            UMat cannyEdges = new UMat();
            CvInvoke.Canny(grayImage, cannyEdges, 60, 180);// By edge, and then take out the contour
           

            List<Triangle2DF> triangleList = new List<Triangle2DF>();
            List<RotatedRect> boxList = new List<RotatedRect>(); // Rotating rectangle​
            using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
            {
                CvInvoke.FindContours(cannyEdges, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);
                int count = contours.Size;
                for (int i = 0; i < count; i++)
                {
                    using (VectorOfPoint contour = contours[i])
                    using (VectorOfPoint approxContour = new VectorOfPoint())
                    {
                        CvInvoke.ApproxPolyDP(contour, approxContour, CvInvoke.ArcLength(contour, true) * 0.08, true);
                        //Only contours with an area greater than 50 are considered
                        if (CvInvoke.ContourArea(approxContour, false) > 50)
                        {
                            if (approxContour.Size == 3) // the contour has 3 vertices: Triangle
                            {
                                System.Drawing.Point[] pts = approxContour.ToArray();
                                triangleList.Add(new Triangle2DF(pts[0], pts[1], pts[2]));
                            }
                            else if (approxContour.Size == 4) // the contour has 4 vertices
                            {

                                bool isRectangle = true;
                                System.Drawing.Point[] pts = approxContour.ToArray();
                                LineSegment2D[] edges = Emgu.CV.PointCollection.PolyLine(pts, true);
                                for (int j = 0; j < edges.Length; j++)
                                {
                                    double angle = Math.Abs(edges[(j + 1) % edges.Length].GetExteriorAngleDegree(edges[j]));
                                    if (angle < 80 || angle > 100)
                                    {
                                        isRectangle = false;
                                        break;
                                    }
                                }

                                if (isRectangle) boxList.Add(CvInvoke.MinAreaRect(approxContour));
                            }
                        }
                    }
                }
            }



            Rectangle rectangle = new Rectangle(0, 0, src.Width, src.Height);
            int maxWidth = 0;
            //boxList = boxList.Where(p => p.Size.Width > 300).ToList();
            for (int i = 0; i < boxList.Count; i++)
            {
                RotatedRect box = boxList[i];
                Rectangle rectangleTemp = box.MinAreaRect();
                //Here, the obtained vertex coordinates are widened, because the rectangle may have an angle, and there is no angle rotation here, so if the value range is widened, the complete graph can be obtained
                rectangleTemp = new Rectangle(rectangleTemp.X * scale, rectangleTemp.Y * scale, rectangleTemp.Width * scale + scale, rectangleTemp.Height * scale + scale);

                //Take the largest rectangular picture
                if (rectangleTemp.Width > maxWidth)
                {
                    maxWidth = rectangleTemp.Width;
                    rectangle = rectangleTemp;
                }
            }
            src.Draw(rectangle, new Bgr(System.Drawing.Color.Red), 4);// Draw lines in the picture
                                                                      // CvInvoke.Imwrite("original picture. BMP", src);// Save original picture
            CvInvoke.cvSetImageROI(src.Ptr, rectangle);// Interest of region

            croptedImage = src.Clone();
            //CvInvoke.Imwrite("cut rectangular picture. BMP", clone);// Save result graph  
            
            src.Dispose();
            srcNewSize.Dispose();
            grayImage.Dispose();
            return croptedImage.AsBitmap<Bgr, byte>();


        }

    }
}
