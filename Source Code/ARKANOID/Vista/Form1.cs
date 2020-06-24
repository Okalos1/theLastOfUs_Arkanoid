﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 using Arkanoid.Modelo;

 namespace Arkanoid
{
  public partial class Form1 : Form
  {
    public delegate void OnClosedWindow();
    public OnClosedWindow CloseAction;
    private delegate void BallActions();
    private readonly BallActions BallMovements;
    public Action FinishGame, WinningGame;
     
    private Player currentPlayer;
  
      
    private bool goleft;
    private bool goRight;
    private bool isGameOver;

    private int score;
    private int ballx;
    private int bally;
    private int playerSpeed;
    private int remainingPb = 0;
    private CustomPictureBox[,] cpb;


    
    Random rnd = new Random();
    private PictureBox[] blockArray;
    

    public Form1(int idPlayer)
    {
      InitializeComponent();
      
      BallMovements = BounceBall;
      currentPlayer.idPlayer = idPlayer;
       setupGame();
    }
    
    protected override CreateParams CreateParams {
      get {
        CreateParams cp = base.CreateParams;
        cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
        return cp;
      }
    } 


    private void setupGame()
    {
      isGameOver = false;
      GameData.score = 0;
      GameData.lifes = 3;
      ballx = 10;
      bally = 10;
      playerSpeed = 20;
      txtScore.Text = "Score: " + GameData.score+ "  Lifes: "+ GameData.lifes;
      

      gameTimer.Start();
    
    }

    private void gameOver(string message)
    {
      isGameOver = true;
      gameTimer.Stop();

      currentPlayer.Score = GameData.score;

      txtScore.Text = "Score: " + GameData.score + "  Lifes: "+ GameData.lifes+ "        " + message;
    }

    //Controlesssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss
    private void gameTimer_Tick(object sender, EventArgs e)
    {
      BallMovements?.Invoke();
      txtScore.Text = "Score: " + GameData.score+ "  Lifes: "+ GameData.lifes;
        
      if (goleft == true && picPaddle.Left >5)
      {
        picPaddle.Left -= playerSpeed;
      }
      if (goRight == true && picPaddle.Left < Width)
      {
        picPaddle.Left += playerSpeed;
      }

      picBall.Left += ballx;
      picBall.Top += bally;

      if (picBall.Left < 0 || picBall.Left> Width)
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
        if (x is CustomPictureBox)
        {
          if (picBall.Bounds.IntersectsWith(x.Bounds))
          {
            GameData.score += 1;
            bally = -bally;
           
             if(!x.Tag.Equals("blinded")) Controls.Remove(x);
          }
        }
      }

      if (GameData.score == 50)
      {
        gameOver("HAS SOBREVIVIDO AL CORONAVIRUS!!! ");
      }

      if (picBall.Top > Height)
      {
        GameData.lifes--;
        if (GameData.lifes == 0)
        {


          gameOver($"MORISTE DE CORONAVIRUS!!! ");

        }
        else
        {
          
          picPaddle.Top = Height - picPaddle.Height - 80;
          picPaddle.Left = Width / 2;
          picBall.Top = picPaddle.Top - picBall.Height;
          picBall.Left = picPaddle.Left + picPaddle.Width / 2 - picBall.Width / 2;
        }

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

      // if (e.KeyCode == Keys.Enter && isGameOver == true)
      // {
      //   removeBlocks();
      //   // placeBlocks();
      // }
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      //Configurando atributos para jugador
      picPaddle.Top = Height - picPaddle.Height - 80;
      picPaddle.Left = Width / 2 - picPaddle.Width / 2;
        
      //Configurando atributos para bola
      picBall.Top = picPaddle.Top - picBall.Height;
      picBall.Left = picPaddle.Left + picPaddle.Width / 2 - picBall.Width / 2;

      
      // Variables auxiliares para el calculo de tamano de cada cpb
      int xAxis = 10, yAxis = 5;
      remainingPb = xAxis * yAxis;

      int pbWidth = (Width - (xAxis - 5)) / xAxis;
      int pbHeight = (int)(Height * 0.3) / yAxis;

      cpb = new CustomPictureBox[yAxis, xAxis];

      // Rutina de instanciacion y agregacion al Form
      for (var i = 0; i < yAxis; i++)
      for (var j = 0; j < xAxis; j++)
      {
        cpb[i, j] = new CustomPictureBox();

        if (i == 4)
          cpb[i, j].Hits = 2;
        else
          cpb[i, j].Hits = 1;

        // Seteando el tamano
        cpb[i, j].Height = pbHeight;
        cpb[i, j].Width = pbWidth;

        // Posicion de left, y posicion de top
        cpb[i, j].Left = j * pbWidth;
        cpb[i, j].Top = i * pbHeight + (int)(Height * 0.07) + 1;

        int imageBack;
        if (i % 2 == 0 && j % 2 == 0)
          imageBack = 4;
        else if (i % 2 == 0 && j % 2 != 0)
          imageBack = 5;
        else if (i % 2 != 0 && j % 2 == 0)
          imageBack = 6;
        else
          imageBack = 7;

        if (i == 4)
        {
          cpb[i, j].BackgroundImage = Image.FromFile("../../Resources/tb1.png");
          cpb[i, j].Tag = "blinded";
        }
        else
        {
          cpb[i, j].BackgroundImage = Image.FromFile("../../Resources/" + imageBack + ".png");
          cpb[i, j].Tag = "tileTag";
        }

        cpb[i, j].BackgroundImageLayout = ImageLayout.Stretch;

        Controls.Add(cpb[i, j]);
      }
    }

    private void BounceBall()
    {
      for (int i = 4; i >= 0; i--)
      {
        for (int j = 0; j < 10; j++)
        {
          if (cpb[i, j] != null && picBall.Bounds.IntersectsWith(cpb[i, j].Bounds))
          {   
            GameData.score += (int)(cpb[i, j].Hits * GameData.ticksCount);
            cpb[i, j].Hits--;

            if (cpb[i, j].Hits == 0)
            {
              Controls.Remove(cpb[i, j]);
              cpb[i, j] = null;

              remainingPb--;
            }
            else if(cpb[i, j].Tag.Equals("blinded"))
              cpb[i, j].BackgroundImage = Image.FromFile("../../Resources/tb2.png");

            GameData.dirY = -GameData.dirY;

            //score = Convert.ToInt32(GameData.score.ToString());

            if (remainingPb == 0)
              WinningGame?.Invoke();

            return;
          }
        }
      }
    }
  }
}
