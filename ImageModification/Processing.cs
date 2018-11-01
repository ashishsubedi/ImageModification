using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageModification
{
    class Processing
    {
        
        public Processing()
        {

        }
        public static void MakeGray(Bitmap image)
        {
            //Algorithm from wikipedia and https://stackoverflow.com/questions/17615963/standard-rgb-to-grayscale-conversion

            for (int i = 0; i< image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color color = image.GetPixel(i,j);
                    double r = color.R / 255.0;
                    double g = color.G / 255.0;
                    double b = color.B / 255.0;
                    double csrgb;

                    double clinear = (0.2126 *r + 0.7152*g + 0.0722*b); 
                    if(clinear <= 0.0031308)
                    {
                        csrgb = 12.92 * clinear;
                    }
                    else
                    {
                        csrgb = Math.Pow(1.055 * clinear, 1 / 2.4) - 0.055;
                    }
                    byte gray = (byte)(csrgb * 255);
                    
                    
                    image.SetPixel(i, j, Color.FromArgb(gray,gray,gray));
                }
            }
            
        }
        public static void Invert(Bitmap image)
        {
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color color = image.GetPixel(i, j);
                    int r = color.R;
                    int g = color.G;
                    int b = color.B;

                    image.SetPixel(i, j, Color.FromArgb(255 - r, 255 - g, 255 - b));
                }
            }
        }
        public static void Rotate(Bitmap image, RotateFlipType rotateFlipType)
        {
            image.RotateFlip(rotateFlipType);     
        }
        public static void AdjustBrightness(Bitmap image, float value)
        {
            
                for (int i = 0; i < image.Width; i++)
                {
                    for (int j = 0; j < image.Height; j++)
                    {
                        Color color = image.GetPixel(i, j);
                        int r = (int)(color.R + value);
                        int g = (int)(color.G + value);
                        int b = (int)(color.B + value);

                        if (r > 255) r = 255;
                        if (g > 255) g = 255;
                        if (b > 255) b = 255;
                        if (r < 0) r = 0;
                        if (g < 0) g = 0;
                        if (b < 0) b = 0;

                        image.SetPixel(i, j, Color.FromArgb(r, g, b));
                    }
                
            }
            
            
        }
        //HAS ERRORS. DONT USE THIS
        public static void ParallelAdjustBrightness(Bitmap image, float value)
        {
            for (int i = 0; i < image.Width; i++)
            {
                Object lockObject = new object();
                lock (lockObject)
                {
                    Parallel.For(0, image.Height, (j) =>
                    {
                        Color color = image.GetPixel(i, j);
                        int r = (int)(color.R + value);
                        int g = (int)(color.G + value);
                        int b = (int)(color.B + value);

                        if (r > 255) r = 255;
                        if (g > 255) g = 255;
                        if (b > 255) b = 255;
                        if (r < 0) r = 0;
                        if (g < 0) g = 0;
                        if (b < 0) b = 0;

                        image.SetPixel(i, j, Color.FromArgb(r, g, b));

                    });
                }
            }
        }
        
    }
}
