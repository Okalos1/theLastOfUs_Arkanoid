using System;
using System.Data;
using System.Windows.Forms;
using Arkanoid.Controlador;
using Arkanoid.Modelo;

namespace Arkanoid
{
    public partial class Register : Form
    {
        public delegate void GetNickname(string text);
        public GetNickname gn;
        
                private Player currentPlayer;

            
        public Register()
        {
            InitializeComponent();
        }
        
        //Boton de iniciar jugar
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                switch (textBox1.Text)
                {
                                       

                    case string aux when aux.Length > 15:
                        throw new ExceededMaxCharactersException($"No se puede introducir un nick de mas de 15 car");
                    case string aux when aux.Trim().Length == 0:
                        throw new EmptyNicknameException("No puede dejar campos vacios");
                    default:
                        
                        
                        if (PlayerControl.CreatePlayer(textBox1.Text))
                        {
                            MessageBox.Show($"Bienvenido nuevamenete {textBox1.Text}");
                        }
                        else
                        {
                            MessageBox.Show($"Gracias por registrarte {textBox1.Text}");
                        }

                        
                        var x = new DataTable();

                        x = DataBaseController.ExecuteQuery($"SELECT idplayer FROM PLAYER WHERE nickname = '{textBox1.Text}'");

                        int id = 0;
                        foreach (DataRow row in x.Rows)
                        {
                            id = Convert.ToInt32(row[0].ToString());
                        }
                        
                        
                        Form1 ft = new Form1(id);
                                    ft.Show();
                                    Hide();
                        break;
                }
            }
            catch(EmptyNicknameException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(ExceededMaxCharactersException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

         ///Cierre de ventana
        private void Register_FormClosed(object sender, FormClosedEventArgs e)
        {
            Menu ft = new Menu();
                      
                              ft.Show();
                              Hide();
        }
    }
}