using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        double n = 1;
        double a = 2;
        double p = 0;
        int s = 8;
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            n++;
            s += 2;
            p = Math.Pow(a, n);
            label1.Text = Convert.ToString(n);
            label3.Text = "=   " + Convert.ToString(p);
            if (s <= 30)
            {
                label1.Font = new Font(this.Font.Name, s);
                label2.Font = new Font(this.Font.Name, s);
                label3.Font = new Font(this.Font.Name, s);
            }
        }
    }
}
