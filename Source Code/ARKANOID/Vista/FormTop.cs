using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;
using Arkanoid.Controlador;
using Arkanoid.Modelo;

namespace Arkanoid
{
    public partial class FormTop : Form
    {
                private Label[,] _players;
                private List<Player> _playersList = null;
                private static List<Player> _players2List;
                private FormClosedEventArgs r;
                private object sender1;
    
        public FormTop()
        {
            _players2List = PlayerControl.ObtainTopPlayers();
                InitializeComponent();
        }
        
        //Cargar jugadores
        private void FormTop_Load(object sender, System.EventArgs e)
        {
            LoadPlayers();

        }
        
        /// <summary>
        /// Obtener jugadores de base de datos y agregarlos a labels
        /// </summary>
        private void LoadPlayers()
        {
            _playersList = PlayerControl.ObtainTopPlayers();
            _players = new Label[10,2];

            int sampleTop = label1.Bottom + 50, sampleLeft = 35;

            for(var i = 0; i < 10; i++)
            for(var j = 0; j < 2; j++)
            {
                _players[i, j] = new Label();

                if (j == 0)
                {
                    _players[i, j].Text = _playersList[i].Nickname;
                    _players[i, j].Left = sampleLeft;
                }
                else
                {
                    _players[i, j].Text = _playersList[i].Score.ToString();
                    _players[i, j].Left = Width / 2 + sampleLeft;
                }

                _players[i, j].Top = sampleTop + 65 * i;

                _players[i, j].Height += 4;
                _players[i, j].Width += 30;

                _players[i,j].Font = new Font("Impact", 14F);
                _players[i,j].TextAlign = ContentAlignment.MiddleCenter;
                _players[i,j].ForeColor = Color.Honeydew;
                _players[i, j].BackColor = Color.Transparent;
                    
                Controls.Add(_players[i,j]);
            }
        }
        //Cierre de ventana
        private void FormTop_FormClosed(object sender, FormClosedEventArgs e)
        {
            var ft = new Menu();
                      
                              ft.Show();
                              Hide();
        }

        public static bool CountList()
        {
            if ((_players2List.Count<10))
            {
                return true;
            }
            else return false;
        }
    }
}