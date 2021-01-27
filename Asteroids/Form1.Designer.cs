
namespace Asteroids
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnRecords = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSplashScreen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(937, 564);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(339, 97);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(225, 57);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnRecords
            // 
            this.btnRecords.Location = new System.Drawing.Point(339, 286);
            this.btnRecords.Name = "btnRecords";
            this.btnRecords.Size = new System.Drawing.Size(225, 57);
            this.btnRecords.TabIndex = 2;
            this.btnRecords.Text = "Records";
            this.btnRecords.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(339, 382);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(225, 57);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(697, 521);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Daniel Lyashchenko © 2021";
            // 
            // btnSplashScreen
            // 
            this.btnSplashScreen.Location = new System.Drawing.Point(340, 193);
            this.btnSplashScreen.Name = "btnSplashScreen";
            this.btnSplashScreen.Size = new System.Drawing.Size(224, 57);
            this.btnSplashScreen.TabIndex = 5;
            this.btnSplashScreen.Text = "SplashScreen";
            this.btnSplashScreen.UseMnemonic = false;
            this.btnSplashScreen.UseVisualStyleBackColor = true;
            this.btnSplashScreen.Click += new System.EventHandler(this.btnSplashScreen_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 564);
            this.Controls.Add(this.btnSplashScreen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnRecords);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Asteroids - Menu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnRecords;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSplashScreen;
    }
}

