using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;


namespace ImageModification
{
    public partial class Form1 : Form
    {
        Bitmap originalImage,processedImage;
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            originalImage = null;
            processedImage = null;
            

        }
     

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofile = new OpenFileDialog();
            ofile.Filter = "Image (*bmp,*jpg,*png)|*.bmp;*.png;*.jpg";
            if(ofile.ShowDialog() == DialogResult.OK)
            {
                originalImage = new Bitmap(ofile.FileName);
                imageOrginal.Image = originalImage;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "JPeg Image|*.jpg|PNG|*.png|Bitmap Image|*.bmp";
            save.FilterIndex = 1;
            save.CheckPathExists = true;
            save.DefaultExt = "png";
            
            save.RestoreDirectory = true;
            save.ShowDialog();
            if (save.FileName != "")
            {
                FileStream fileStream = (FileStream)save.OpenFile();
                switch (save.FilterIndex)
                {
                    case 1:
                        processedImage.Save(fileStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                        MessageBox.Show("Image Successfully Saved");
                        break;
                       
                    case 2:
                        processedImage.Save(fileStream, System.Drawing.Imaging.ImageFormat.Png);
                        MessageBox.Show("Image Successfully Saved");
                        break;
                    case 3:
                        processedImage.Save(fileStream, System.Drawing.Imaging.ImageFormat.Bmp);
                        MessageBox.Show("Image Successfully Saved");
                        break;
                }
                fileStream.Close();
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(originalImage == null)
            {
                MessageBox.Show("Select an image first");
                return;
            }

            processedImage = originalImage;
            Processing.MakeGray(processedImage);
            imageProcessed.Image = processedImage;
        }
    }
}
