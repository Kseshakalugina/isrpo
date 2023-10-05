using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursa
{
    public partial class Zapros : Form
    {
        Color FrameColor = Color.Black;//цвет рамки
        bool EnableNonClientAreaPaint = true;
        private static string connectString = "Data Source =DESKTOP-N2KIJCC\\SQLEXPRESS;Initial Catalog =kurs_kalugina;" +
                "Integrated Security = true;"; // данные для подключения к базе
        private SqlConnection myConnection; // подключение к базе
        public Zapros()
        {
            InitializeComponent();
        }

        private void Update1(string sql)
        {
            dataGridView1.Columns.Clear();
            myConnection = new SqlConnection(connectString);
            myConnection.Open();
            SqlCommand cmd = myConnection.CreateCommand(); // создается команда
            cmd.CommandText = sql; // добавление текста запроса 
            SqlDataAdapter adapter = new SqlDataAdapter(cmd); // мост между DataSet и SQL Server
            DataSet m_set = new DataSet(); // хранилище таблицы
            adapter.Fill(m_set); // заполнение DataSet
            dataGridView1.DataSource = m_set.Tables[0]; // заполнение dataGridView1 из таблицы
            myConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

       

        private void Zapros_Load(object sender, EventArgs e)
        {
            if (Owner.Name == "Tovar")
            {
                label1.Text = "Расчет прибыли по товару";
                Update1("SELECT [Наименование товара], (([Стоимость продажи] - [Стоимость закупки])*[Договоры продаж].Количество) As [Прибыль] FROM Товары, [Договоры продаж] WHERE [Код товара] = Товар ORDER BY Прибыль");
            }
            else if (Owner.Name == "Workers")
            {
                label1.Text = "Список сотрудников, чей оклад выше 50000";
                Update1("SELECT [Фамилия сотрудника], Должность, Оклад FROM Сотрудники, Должности WHERE Сотрудники.Должность = [Код должности] and (Оклад > 50000)");
            }
        }
    }
}
