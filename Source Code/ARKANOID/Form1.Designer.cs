namespace Arkanoid
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
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.picPaddle = new System.Windows.Forms.PictureBox();
            this.txtScore = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPaddle)).BeginInit();
            this.SuspendLayout();
            // 
            // picBall
            // 
            this.picBall.BackColor = System.Drawing.Color.Red;
            this.picBall.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picBall.Location = new System.Drawing.Point(384, 393);
            this.picBall.Name = "picBall";
            this.picBall.Size = new System.Drawing.Size(18, 19);
            this.picBall.TabIndex = 0;
            this.picBall.TabStop = false;
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // picPaddle
            // 
            this.picPaddle.BackColor = System.Drawing.Color.Lime;
            this.picPaddle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picPaddle.Location = new System.Drawing.Point(372, 526);
            this.picPaddle.Name = "picPaddle";
            this.picPaddle.Size = new System.Drawing.Size(118, 25);
            this.picPaddle.TabIndex = 1;
            this.picPaddle.TabStop = false;
            // 
            // txtScore
            // 
            this.txtScore.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScore.Location = new System.Drawing.Point(12, 9);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(454, 20);
            this.txtScore.TabIndex = 2;
            this.txtScore.Text = "Score: 0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(849, 561);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.picPaddle);
            this.Controls.Add(this.picBall);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.picBall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPaddle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBall;
        private System.Windows.Forms.PictureBox picPaddle;
        private System.Windows.Forms.Label txtScore;
        private System.Windows.Forms.Timer gameTimer;
    }
}