using System.Drawing;
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
            var playersList = PlayerControl.ObtainTopPlayers();
            players = new Label[10,2];

            int sampleTop = label1.Bottom + 50, sampleLeft = 35;

            for(var i = 0; i < 10; i++)
            for(var j = 0; j < 2; j++)
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

                players[i,j].Font = new Font("Impact", 14F);
                players[i,j].TextAlign = ContentAlignment.MiddleCenter;
                players[i,j].ForeColor = Color.Honeydew;
                players[i, j].BackColor = Color.Transparent;
                    
                Controls.Add(players[i,j]);
            }
        }
        //Cierre de ventana
        private void FormTop_FormClosed(object sender, FormClosedEventArgs e)
        {
            var ft = new Menu();
                      
                              ft.Show();
                              Hide();
        }
    }
}