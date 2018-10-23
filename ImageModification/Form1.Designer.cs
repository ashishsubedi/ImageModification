namespace ImageModification
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.imageOrginal = new System.Windows.Forms.PictureBox();
            this.imageProcessed = new System.Windows.Forms.PictureBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabBW = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.imageOrginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageProcessed)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabBW.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageOrginal
            // 
            this.imageOrginal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.imageOrginal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageOrginal.Location = new System.Drawing.Point(6, 6);
            this.imageOrginal.Name = "imageOrginal";
            this.imageOrginal.Size = new System.Drawing.Size(455, 390);
            this.imageOrginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageOrginal.TabIndex = 0;
            this.imageOrginal.TabStop = false;
            // 
            // imageProcessed
            // 
            this.imageProcessed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.imageProcessed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageProcessed.Location = new System.Drawing.Point(489, 6);
            this.imageProcessed.Name = "imageProcessed";
            this.imageProcessed.Size = new System.Drawing.Size(455, 390);
            this.imageProcessed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageProcessed.TabIndex = 1;
            this.imageProcessed.TabStop = false;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(347, 442);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(428, 442);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Convert";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(509, 442);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabBW);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(958, 511);
            this.tabControl1.TabIndex = 5;
            // 
            // tabBW
            // 
            this.tabBW.Controls.Add(this.button2);
            this.tabBW.Controls.Add(this.imageOrginal);
            this.tabBW.Controls.Add(this.button1);
            this.tabBW.Controls.Add(this.btnOpen);
            this.tabBW.Controls.Add(this.imageProcessed);
            this.tabBW.Location = new System.Drawing.Point(4, 25);
            this.tabBW.Name = "tabBW";
            this.tabBW.Padding = new System.Windows.Forms.Padding(3);
            this.tabBW.Size = new System.Drawing.Size(950, 482);
            this.tabBW.TabIndex = 0;
            this.tabBW.Text = "BW";
            this.tabBW.UseVisualStyleBackColor = true;
            this.tabBW.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 524);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Image Processing";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageOrginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageProcessed)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabBW.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imageOrginal;
        private System.Windows.Forms.PictureBox imageProcessed;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabBW;
    }
}

