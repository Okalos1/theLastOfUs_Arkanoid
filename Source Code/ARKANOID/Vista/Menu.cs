using System;
using System.Windows.Forms;

namespace Arkanoid
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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