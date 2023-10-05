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
    public partial class Menu : Form
    {
        Tovar tovar = new Tovar(); // инициализация объекта класса формы Товары
        Category category = new Category(); // инициализация объекта класса формы Категория
        Workers workers = new Workers(); // инициализация объекта класса формы Сотрудники
        Manafactures manufacturers = new Manafactures(); // инициализация объекта класса формы Производители
        Contracts contracts = new Contracts(); // инициализация объекта класса формы Договоры продаж
        Positions positions = new Positions(); // инициализация объекта класса формы Должности 
        Clients clients = new Clients(); // инициализация объекта класса формы Клиенты
        Invoices invoices = new Invoices(); // инициализация объекта класса формы Накладные
        public Menu()
        {
            InitializeComponent();
            tovar.Owner = this;
            category.Owner = this;
            workers.Owner = this;
            manufacturers.Owner = this;
            contracts.Owner = this;
            positions.Owner = this;
            clients.Owner = this;
            invoices.Owner = this;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (sender == button1) 
            {
                Hide();
                category.ShowDialog();
            }
            else if (sender == button2) 
            {
                Hide();
                clients.ShowDialog();
            }
            else if (sender == button3) 
            {
                Hide();
                contracts.ShowDialog();
            }
            else if (sender == button6) 
            {
                Hide();
                invoices.ShowDialog();
            }
            else if (sender == button5) 
            {
                Hide();
                manufacturers.ShowDialog();
            }
            else if (sender == button4) 
            {
                Hide();
                positions.ShowDialog();
            }
            else if (sender == button9) 
            {
                Hide();
                tovar.ShowDialog();
            }
            else if (sender == button8) 
            {
                Hide();
                workers.ShowDialog();
            }
            else if (sender == button7) 
            {
                Close();
            }
        }
    }
}
