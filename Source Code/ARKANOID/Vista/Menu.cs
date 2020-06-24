using System;
using System.Windows.Forms;
using Arkanoid.Controlador;
using Arkanoid.Modelo;

namespace Arkanoid
{
    public partial class Menu : Form
    {
        
        private Player currentPlayer;
                   
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            
            Register fr = new Register();

            fr.gn = (string nick) => 
            {
                if (PlayerControl.CreatePlayer(nick))
                {
                    MessageBox.Show($"Bienvenido nuevamenete {nick}");
                }
                else
                {
                    MessageBox.Show($"Gracias por registrarte {nick}");
                }

                currentPlayer = new Player(nick, 0);

                fr.Dispose();
            };

            fr.Show();
            
          
            Form1 ft = new Form1
            {
                CloseAction = () =>
                {
                    Show();
                }
            };
            
            ft.Show();
            Hide();

        }

    }
}