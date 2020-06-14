﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arkanoid
{
  public partial class Form1 : Form
  {
    public int vSpeed;
    public int hSpeed;
    public const int fila = 5;
    public const int col = 6;
    public PictureBox[,] blocks;
    //CONSTRUCTOR
    public Form1()
    {
      vSpeed = 3;
      hSpeed = 3;
      setBlocks();
      InitializeComponent();
    }

    private void setBlocks()
    {
      int blockHeight = 25;
      int blockWidth = 100;
      
      blocks = new PictureBox[fila,col];

      for (int x = 0; x < fila; x++)
      {
        for (int y = 0; y < col; y++)
        {
          blocks[x,y]= new PictureBox();

          blocks[x, y].Width = blockWidth;
          blocks[x, y].Height = blockHeight;
          blocks[x,y].Top = blockHeight * x;
          blocks[x, y].Left = blockWidth * y;
          blocks[x, y].BackColor = Color.Navy;
          blocks[x, y].BorderStyle = BorderStyle.Fixed3D;
          
          this.Controls.Add(blocks[x,y]);
          
        }
      }
    }
    
    // CONTROL DE MOVIMIENTOS DE LA PELOTA
    private void timer1_Tick(object sender, EventArgs e)
    {
      picBall.Top += vSpeed;
      picBall.Left += hSpeed;

     if (picBall.Bottom > this.ClientSize.Height)
     {
       vSpeed = -vSpeed;
     }

     if (picBall.Top < 0)
     {
       vSpeed = -vSpeed;
     }
     
     if (picBall.Right > this.ClientSize.Width)
     {
       hSpeed = -hSpeed; 
     }
     if (picBall.Left < 0)
     {
       hSpeed = -hSpeed;
     }
     // CUANDO LA PELOTA CHOCA CON LA TABLA XD
     if (picBall.Bounds.IntersectsWith(picPaddle.Bounds) == true )
     {
       vSpeed = -vSpeed;
      // hSpeed = -hSpeed;
     }
     
     //DESTRUCCION DE BLOQUES
     for (int x = 0; x < fila; x++)
     {
       for (int y = 0; y < col; y++)
       {
         if (picBall.Bounds.IntersectsWith(blocks[x, y].Bounds) && blocks[x,y].Visible == true )
         {
           blocks[x, y].Visible = false;
           vSpeed = -vSpeed;
         }
       }
     }
     
    }
    
   //CONTROL DE LA TABLE(PADDLE)
    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
      picPaddle.Left = e.X - (picPaddle.Width / 2);
    }
  }
}
