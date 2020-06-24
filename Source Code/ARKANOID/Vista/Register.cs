﻿using System;
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                switch (textBox1.Text)
                {
                    case string aux when aux.Length > 15:
                        throw new ExceededMaxCharactersException("No se puede introducir un nick de mas de 15 car");
                    case string aux when aux.Trim().Length == 0:
                        throw new EmptyNicknameException("No puede dejar campos vacios");
                    default:
                        //gn?.Invoke(textBox1.Text);
                        
                        if (PlayerControl.CreatePlayer(textBox1.Text))
                        {
                            MessageBox.Show($"Bienvenido nuevamenete {textBox1.Text}");
                        }
                        else
                        {
                            MessageBox.Show($"Gracias por registrarte {textBox1.Text}");
                        }

                        currentPlayer = new Player(textBox1.Text, 0);
                        
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
    }
}