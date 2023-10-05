using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursa
{
    public partial class login : Form
    {
        Menu menu = new Menu();
        Color FrameColor = Color.Black;//цвет рамки
        bool EnableNonClientAreaPaint = true;
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == Properties.Settings.Default.Password)
            {
                Hide();
                menu.Show();
            }
            else
            {
                MessageBox.Show("Неверный пароль!");
            }
        }
    }
}
