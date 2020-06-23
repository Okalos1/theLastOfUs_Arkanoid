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
    private bool goleft;
    private bool goRight;
    private bool isGameOver;

    private int score;
    private int ballx;
    private int bally;
    private int playerSpeed;
    
    Random rnd = new Random();
    private PictureBox[] blockArray;
    

    public Form1()
    {
      InitializeComponent();
      
      placeBlocks();
    }

    private void setupGame()
    {
      isGameOver = false;
      score = 0;
      ballx = 5;
      bally = 5;
      playerSpeed = 12;
      txtScore.Text = "Score:" + score;

      picBall.Left = 448;
      picBall.Top = 453;

      picPaddle.Left =434 ;

      gameTimer.Start();
      //COLOREEEEEEEEEEEEEEEEEEES JBALVIN
      foreach (Control x in this.Controls)
      {
        if (x is PictureBox && (String) x.Tag == "blocks")
        {
          x.BackColor = Color.FromArgb(rnd.Next(256),rnd.Next(256),rnd.Next(256));
        }
          
      }
    }

    private void gameOver(string message)
    {
      isGameOver = true;
      gameTimer.Stop();

      txtScore.Text = "Score: " + score + "        " + message;
    }

    private void placeBlocks()
    {
      blockArray = new PictureBox[25];
      int a = 0;
      int top = 50;
       int left = 100;

       for (int i = 0; i < blockArray.Length; i++)
       {
         blockArray[i]=new PictureBox();
         blockArray[i].Height = 25;
         blockArray[i].Width = 100;
         blockArray[i].Tag = "blocks";
         blockArray[i].BackColor=Color.Peru;

         if (a == 5)
         {
           top = top + 50;
           left = 100;
           a = 0;
         }

         if (a < 5)
         {
           a++;
           blockArray[i].Left = left;
           blockArray[i].Top = top;

           this.Controls.Add(blockArray[i]);
           left = left + 130;
         }
       }
       setupGame();
    }

    private void removeBlocks()
    {
      foreach (PictureBox x in blockArray)
      {
        this.Controls.Remove(x);
      }
      
    }
    
    
    
    //Controlesssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss
    private void gameTimer_Tick(object sender, EventArgs e)
    {
      txtScore.Text = "Score: " + score;
        
      if (goleft == true && picPaddle.Left >5)
      {
        picPaddle.Left -= playerSpeed;
      }
      if (goRight == true && picPaddle.Left <725)
      {
        picPaddle.Left += playerSpeed;
      }

      picBall.Left += ballx;
      picBall.Top += bally;

      if (picBall.Left < 0 || picBall.Left> 826)
      {
        ballx = -ballx;
      }

      if (picBall.Top < 0)
      {
        bally = -bally;
      }

      if (picBall.Bounds.IntersectsWith(picPaddle.Bounds))
      {
        
        bally = rnd.Next(5, 12) * -1;
        if (ballx<0)
        {
          ballx = rnd.Next(5, 12) * -1;
        }
        else
        {
          ballx = rnd.Next(5, 12);
        }
      }
      //Eliminacion de blocks

      foreach (Control x in this.Controls)
      {
        if (x is PictureBox && (String) x.Tag == "blocks")
        {
          if (picBall.Bounds.IntersectsWith(x.Bounds))
          {
            score += 1;
            bally = -bally;
           
            this.Controls.Remove(x);
          }
        }
      }

      if (score == 25)
      {
        gameOver("HAS SOBREVIVIDO AL CORONAVIRUS!!! PRESS ENTER ");
      }

      if (picBall.Top >550)
      {
        gameOver("MORISTE DE CORONAVIRUS!!! PRESS ENTER ");
      }

    
    }
    
    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Left)
      {
        goleft = true;
      }

      if (e.KeyCode == Keys.Right)
      {
        goRight = true;
      }
    }
    
    private void Form1_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Left)
      {
        goleft = false;
      }

      if (e.KeyCode == Keys.Right)
      {
        goRight = false;
      }

      if (e.KeyCode == Keys.Enter && isGameOver == true)
      {
        removeBlocks();
        placeBlocks();
      }
    }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
