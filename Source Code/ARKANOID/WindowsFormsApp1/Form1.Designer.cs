namespace WindowsFormsApp1
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
            this.components = new System.ComponentModel.Container();
            this.picBall = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.picPaddle = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize) (this.picBall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.picPaddle)).BeginInit();
            this.SuspendLayout();
            // 
            // picBall
            // 
            this.picBall.BackColor = System.Drawing.Color.Red;
            this.picBall.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picBall.Location = new System.Drawing.Point(194, 137);
            this.picBall.Name = "picBall";
            this.picBall.Size = new System.Drawing.Size(24, 25);
            this.picBall.TabIndex = 0;
            this.picBall.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // picPaddle
            // 
            this.picPaddle.BackColor = System.Drawing.Color.Lime;
            this.picPaddle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picPaddle.Location = new System.Drawing.Point(194, 464);
            this.picPaddle.Name = "picPaddle";
            this.picPaddle.Size = new System.Drawing.Size(199, 25);
            this.picPaddle.TabIndex = 1;
            this.picPaddle.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.picPaddle);
            this.Controls.Add(this.picBall);
            this.Name = "Form1";
            this.Text = "Form1";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            ((System.ComponentModel.ISupportInitialize) (this.picBall)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.picPaddle)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox picBall;
        private System.Windows.Forms.PictureBox picPaddle;
    }
}