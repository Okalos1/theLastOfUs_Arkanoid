﻿using System.Drawing;
using System.Windows.Forms;
using Arkanoid.Controlador;

namespace Arkanoid
{
    public partial class FormTop : Form
    {
                private Label[,] players;
    
        public FormTop()
        {
            InitializeComponent();
        }
        
        private void FormTop_Load(object sender, System.EventArgs e)
                {
                    LoadPlayers();
                }
        
                private void LoadPlayers()
                {
                    var playersList = PlayerControl.ObtainTopPlayers();
                    players = new Label[10,2];
        
                    int sampleTop = label1.Bottom + 50, sampleLeft = 35;
        
                    for(int i = 0; i < 10; i++)
                    {
                        for(int j = 0; j < 2; j++)
                        {
                            players[i, j] = new Label();
        
                            if (j == 0)
                            {
                                players[i, j].Text = playersList[i].Nickname;
                                players[i, j].Left = sampleLeft;
                            }
                            else
                            {
                                players[i, j].Text = playersList[i].Score.ToString();
                                players[i, j].Left = Width / 2 + sampleLeft;
                            }
        
                            players[i, j].Top = sampleTop + 65 * i;
        
                            players[i, j].Height += 4;
                            players[i, j].Width += 30;
        
                            players[i,j].Font = new Font("Microsoft YaHei", 14F);
                            players[i,j].TextAlign = ContentAlignment.MiddleCenter;
        
                            Controls.Add(players[i,j]);
                        }
                    }
                }
    }
}