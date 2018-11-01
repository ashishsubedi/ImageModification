using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;


namespace ImageModification
{
    public partial class Form1 : Form
    {
        Bitmap originalImage,processedImage;

        //For brightness adjustment
        HScrollBar slider;
        Button confirm ;
        Label label;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            originalImage = null;
            processedImage = null;

            slider = new HScrollBar();
            confirm = new Button();
            label = new Label();

            
            slider.Size = new Size(680, 10);
            slider.Location = new Point(0, this.Height - 65);
            slider.Minimum = -100;
            slider.Maximum = 100;
            slider.Value = 0;
            //slider.Dock = DockStyle.Bottom;
            confirm.Location = new Point(slider.Location.X+ 680, slider.Location.Y);
            confirm.Size = new Size(40,20);
            confirm.Text = "OK";

            label.Location = new Point(slider.Location.X, slider.Location.Y - 40);
            label.Size = new Size(50, 20);
            label.Text = "Status";
           


            this.Controls.Add(slider);
            this.Controls.Add(confirm);
            this.Controls.Add(label);

            slider.Scroll += new ScrollEventHandler(slideScroll);
            confirm.Click += Confirm_Click;


            slider.Visible = false;
            confirm.Visible = false;
            label.Visible = false;



        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            slider.Visible = false;

            confirm.Visible = false;
            label.Visible = false;

        }


        private async void slideScroll(object sender, ScrollEventArgs e)
        {
            if (e.Type == ScrollEventType.ThumbPosition)
            {
                Task task = new Task(adjustBrightnessThread);
                task.Start();

                label.Text = "Applying.. Please wait...";
                slider.Enabled = false;
                await task;
                label.Text = "Done.";
                slider.Enabled = true;

            }


        }

      

        private async void adjustBrightnessThread()
        {
            Object lockObject = new object();
            lock (lockObject)
            {

                Bitmap cloneImage = (Bitmap)processedImage.Clone();

                Processing.AdjustBrightness(cloneImage, slider.Value);
                processedImage = (Bitmap)cloneImage.Clone();

                imageProcessedBox.Image = processedImage;

            }
           



            

        }

        private void openImage(PictureBox pictureBox)
        {
            OpenFileDialog ofile = new OpenFileDialog();
            ofile.Filter = "Image (*bmp,*jpg,*png)|*.bmp;*.png;*.jpg";
            if (ofile.ShowDialog() == DialogResult.OK)
            {
                originalImage = new Bitmap(ofile.FileName);
                pictureBox.Image = originalImage;
                processedImage = originalImage.Clone() as Bitmap;

            }
        }
        private void saveImage(PictureBox pictureBox)
        {
            if (processedImage == null)
            {
                MessageBox.Show("No Processed Image Found.");
                return;
            }

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
        private Boolean checkImageExist()
        {
            if (originalImage == null)
            {
                MessageBox.Show("Select an image first");
                return false;
            }
            return true;
        }


        private void bWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkImageExist();

            //processedImage = (Bitmap)processedImage.Clone();
            Processing.MakeGray(processedImage);
            imageProcessedBox.Image = processedImage;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openImage(imageOrginalBox);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveImage(imageProcessedBox);
        }

        private void mirrorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!checkImageExist()) return;

           // processedImage = (Bitmap)originalImage.Clone();
            Processing.Rotate(processedImage, RotateFlipType.RotateNoneFlipX);
            imageProcessedBox.Image = processedImage;

        }

        private void adjustBrightnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!checkImageExist()) return;

           // processedImage = (Bitmap)originalImage.Clone();
            slider.Visible = true;
           
            confirm.Visible = true;
            label.Visible = true;



        }
        

        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!checkImageExist()) return;

           // processedImage = (Bitmap)originalImage.Clone();
            Processing.Invert(processedImage);
            imageProcessedBox.Image = processedImage;
        }

        
    }
}
