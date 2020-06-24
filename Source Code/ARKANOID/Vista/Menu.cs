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
        
        
        //Iniciar juego, abrir frm de Register
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

                currentPlayer.Nickname = nick;

                fr.Dispose();
            };

            fr.Show();
      
        }
        
   //Abrir Top 10 jugadores 


    private void button2_Click(object sender, EventArgs e)
{
    var ft = new FormTop();
    
            ft.Show();
            Hide();
            
}
//Cerrar Aplicación
    private void button3_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }
    }
}