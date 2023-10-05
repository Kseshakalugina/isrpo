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
using System.Data.Common;
using System.Security.Policy;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace kursa
{
    public partial class Add : Form
    {
        Color FrameColor = Color.Black;//цвет рамки
        bool EnableNonClientAreaPaint = true;
        private static string connectString = "Data Source = DESKTOP-N2KIJCC\\SQLEXPRESS;Initial Catalog =kurs_kalugina;" +
               "Integrated Security = true;"; // данные для подключения к базе
        public bool change; // вызов функции для добавления/изменения
        public int id; // id изменяемой строки
        public string[] row; // строка, которая будет изменятся

        public Add()
        {
            InitializeComponent();
        }


        private void AddRow()
        {

            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();
                if (Owner.Name == "Tovar")
                {
                    SqlCommand command = new SqlCommand($"INSERT INTO Товары values ({int.Parse(textBox2.Text)}, '{textBox3.Text}', {int.Parse(textBox4.Text)}, '{textBox5.Text}', '{textBox6.Text}', {Convert.ToDecimal(textBox7.Text)}, {Convert.ToDecimal(textBox8.Text)}, {int.Parse(textBox9.Text)})");
                    SqlCommand command1 = new SqlCommand($"INSERT INTO Накладные select [Код товара], [Производитель] FROM Товары WHERE Производитель = {int.Parse(textBox2.Text)}  and [Наименование товара] = '{textBox3.Text}' and Категория = {int.Parse(textBox4.Text)} and Описание = '{textBox5.Text}' and Наличие = {textBox6.Text} and [Стоимость закупки] = {Convert.ToDecimal(textBox7.Text)} and [Стоимость продажи] = {Convert.ToDecimal(textBox8.Text)} and Количество = {int.Parse(textBox9.Text)}");
                    command.Connection = conn;
                    command.ExecuteNonQuery();
                    command1.Connection = conn;
                    command1.ExecuteNonQuery();
                    
                }
                else if (Owner.Name == "Category")
                {
                    SqlCommand command = new SqlCommand($"INSERT INTO Категории values ('{textBox2.Text}')");
                    command.Connection = conn;
                    command.ExecuteNonQuery();
                }
                else if (Owner.Name == "Clients")
                {
                    SqlCommand command = new SqlCommand($"INSERT INTO Клиенты values ('{textBox2.Text}', '{textBox3.Text}', '{textBox4.Text}','{textBox5.Text}','{textBox6.Text}')");
                    command.Connection = conn;
                    command.ExecuteNonQuery();
                }
                else if (Owner.Name == "Contracts")
                {
                    SqlCommand command = new SqlCommand($"INSERT INTO [Договоры продаж] values ({int.Parse(textBox2.Text)} , {int.Parse(textBox3.Text)}, {int.Parse(textBox4.Text)},{int.Parse(textBox5.Text)})");
                    command.Connection = conn;
                    command.ExecuteNonQuery();
                }
                else if (Owner.Name == "Manufactures")
                {
                    SqlCommand command = new SqlCommand($"INSERT INTO Производители values ('{textBox2.Text}', '{textBox3.Text}', '{textBox4.Text}')");
                    command.Connection = conn;
                    command.ExecuteNonQuery();
                }
                else if (Owner.Name == "Positions")
                {
                    SqlCommand command = new SqlCommand($"INSERT INTO Должности values ('{textBox2.Text}', '{textBox3.Text}')");
                    command.Connection = conn;
                    command.ExecuteNonQuery();
                }
                else if (Owner.Name == "Workers")
                {
                    SqlCommand command = new SqlCommand($"INSERT INTO Сотрудники values ('{textBox2.Text}', '{Convert.ToDateTime(textBox3.Text)}', {int.Parse(textBox4.Text)}, '{textBox5.Text}','{textBox6.Text}')");
                    command.Connection = conn;
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        private void ChangeRow()
        {
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();
                if (Owner.Name == "Tovar")
                {
                    SqlCommand command = new SqlCommand($"UPDATE Товары SET [Производитель] = '{textBox2.Text}', [Наименование товара] = '{textBox3.Text}', [Категория] = {int.Parse(textBox4.Text)}, [Описание] = '{textBox5.Text}', [Наличие] = '{Convert.ToBoolean(textBox6.Text)}', [Стоимость закупки] = {Convert.ToDouble(textBox7.Text)}, [Стоимость продажи] = {Convert.ToDouble(textBox8.Text)}, Количество = {int.Parse(textBox9.Text)} WHERE [Код товара] = {id}");
                    SqlCommand command1 = new SqlCommand($"UPDATE Накладные SET [Код производителя] = {int.Parse(textBox2.Text)} Where [Код товара] = (Select [Товары].[Код товара] FROM Товары WHERE [Наименование товара] = '{textBox3.Text}' and [Категория] = {int.Parse(textBox4.Text)} and Описание = '{textBox5.Text}' and Наличие = '{Convert.ToBoolean(textBox6.Text)}' and [Стоимость закупки] = {Convert.ToDouble(textBox7.Text)} and [Стоимость продажи] = {Convert.ToDouble(textBox8.Text)} and Количество = {int.Parse(textBox9.Text)})");
                    command.Connection = conn;
                    command.ExecuteNonQuery();
                    command1.Connection = conn;
                    command1.ExecuteNonQuery();
                }
                else if (Owner.Name == "Category")
                {
                    SqlCommand command = new SqlCommand($"UPDATE Категории SET [Категория] = '{textBox2.Text}' WHERE [Код категории] = {id}");
                    command.Connection = conn;
                    command.ExecuteNonQuery();
                }
                else if (Owner.Name == "Clients")
                {
                    SqlCommand command = new SqlCommand($"UPDATE Клиенты SET [Фамилия клиента] = '{textBox2.Text}',[Имя] = '{textBox3.Text}',[Отчество] = '{textBox4.Text}', [Электронная почта] ='{textBox5.Text}', [Телефон] = '{textBox6.Text}' WHERE [Код клиента] = {id}");
                    command.Connection = conn;
                    command.ExecuteNonQuery();
                }
                else if (Owner.Name == "Contracts")
                {
                    SqlCommand command = new SqlCommand($"UPDATE [Договоры продаж] SET Сотрудник = '{int.Parse(textBox2.Text)}', [Товар] = '{int.Parse(textBox3.Text)}', [Клиент] = '{int.Parse(textBox4.Text)}', [Количество] = '{int.Parse(textBox5.Text)}' WHERE [Номер договора] = {id}");
                    command.Connection = conn;
                    command.ExecuteNonQuery();
                }
                else if (Owner.Name == "Manufactures")
                {
                    SqlCommand command = new SqlCommand($"UPDATE Производители SET [Наименование предприятия] = '{textBox2.Text}', [Город] = '{textBox3.Text}', [Телефон] = '{textBox4.Text}' WHERE [Код производителя] = {id}");
                    command.Connection = conn;
                    command.ExecuteNonQuery();
                }
                else if (Owner.Name == "Positions")
                {
                    SqlCommand command = new SqlCommand($"UPDATE Должности SET Наименование =  '{textBox2.Text}', Оклад = '{Convert.ToDouble(textBox3.Text)}' WHERE [Код должности] = {id}");
                    command.Connection = conn;
                    command.ExecuteNonQuery();
                }
                else if (Owner.Name == "Workers")
                {
                    SqlCommand command = new SqlCommand($"UPDATE Сотрудники SET [Фамилия сотрудника] = '{textBox2.Text}', [Дата Рождения] = '{Convert.ToDateTime(textBox3.Text)}', [Должность] = {int.Parse(textBox4.Text)}, [Адрес проживания] = '{textBox5.Text}', [номер телефона] = '{textBox6.Text}' WHERE [Код сотрудника] = {id}");
                    command.Connection = conn;
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (change == true) // изменение 
            {
                ChangeRow();
            }
            else if (change == false) // добавление
            {
                AddRow();
            }
            Close();
        }

        private void Add_Load(object sender, EventArgs e)
        {
            if (change == true)
            {
                button1.Text = "ИЗМЕНИТЬ";
                if (Owner.Name == "Tovar")
                {
                    textBox2.Text = Convert.ToString(row[1]);
                    textBox3.Text = Convert.ToString(row[2]);
                    textBox4.Text = Convert.ToString(row[3]);
                    textBox5.Text = Convert.ToString(row[4]);
                    textBox6.Text = Convert.ToString(row[5]);
                    textBox7.Text = Convert.ToString(row[6]);
                    textBox8.Text = Convert.ToString(row[7]);
                    textBox9.Text = Convert.ToString(row[8]);

                }
                else if (Owner.Name == "Category")
                {
                    label1.Text = "Категория";
                    label2.Text = "";
                    label3.Text = "";
                    label4.Text = "";
                    label5.Text = "";
                    label6.Text = "";
                    label7.Text = "";
                    label8.Text = "";
                    textBox2.Text = Convert.ToString(row[1]);
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;
                    textBox5.Enabled = false;
                    textBox6.Enabled = false;
                    textBox7.Enabled = false;
                    textBox8.Enabled = false;
                    textBox9.Enabled = false;
                }
                else if (Owner.Name == "Clients")
                {
                    label1.Text = "Фамилия клиента";
                    label2.Text = "Имя";
                    label3.Text = "Отчество";
                    label4.Text = "Электронная почта";
                    label5.Text = "Телефон";
                    label6.Text = "";
                    label7.Text = "";
                    label8.Text = "";
                    textBox2.Text = Convert.ToString(row[1]);
                    textBox3.Text = Convert.ToString(row[2]);
                    textBox4.Text = Convert.ToString(row[3]);
                    textBox5.Text = Convert.ToString(row[4]);
                    textBox6.Text = Convert.ToString(row[5]);
                    textBox7.Enabled = false;
                    textBox8.Enabled = false;
                    textBox9.Enabled = false;
                }
                else if (Owner.Name == "Contracts")
                {
                    label1.Text = "Сотрудник";
                    label2.Text = "Товар";
                    label3.Text = "Клиент";
                    label4.Text = "Количество";
                    label5.Text = "";
                    label6.Text = "";
                    label7.Text = "";
                    label8.Text = "";
                    textBox2.Text = Convert.ToString(row[1]);
                    textBox3.Text = Convert.ToString(row[2]);
                    textBox4.Text = Convert.ToString(row[3]);
                    textBox5.Text = Convert.ToString(row[4]);
                    textBox6.Enabled = false;
                    textBox7.Enabled = false;
                    textBox8.Enabled = false;
                    textBox9.Enabled = false;
                }
                else if (Owner.Name == "Manufactures")
                {
                    label1.Text = "Наименование предприятия";
                    label2.Text = "Город";
                    label3.Text = "Телефон";
                    label4.Text = "";
                    label5.Text = "";
                    label6.Text = "";
                    label7.Text = "";
                    label8.Text = "";
                    textBox2.Text = Convert.ToString(row[1]);
                    textBox3.Text = Convert.ToString(row[2]);
                    textBox4.Text = Convert.ToString(row[3]);
                    textBox5.Enabled = false;
                    textBox6.Enabled = false;
                    textBox7.Enabled = false;
                    textBox8.Enabled = false;
                    textBox9.Enabled = false;
                }
                else if (Owner.Name == "Positions")
                {
                    label1.Text = "Наименование";
                    label2.Text = "Оклад";
                    label3.Text = "";
                    label4.Text = "";
                    label5.Text = "";
                    label6.Text = "";
                    label7.Text = "";
                    label8.Text = "";
                    textBox2.Text = Convert.ToString(row[1]);
                    textBox3.Text = Convert.ToString(row[2]);
                    textBox4.Enabled = false;
                    textBox5.Enabled = false;
                    textBox6.Enabled = false;
                    textBox7.Enabled = false;
                    textBox8.Enabled = false;
                    textBox9.Enabled = false;
                }
                else if (Owner.Name == "Workers")
                {
                    label1.Text = "Фамилия Сотрудника";
                    label2.Text = "Дата Рождения";
                    label3.Text = "Должность";
                    label4.Text = "Адрес Проживания";
                    label5.Text = "Номер Телефона";
                    label6.Text = "";
                    label7.Text = "";
                    label8.Text = "";
                    textBox2.Text = Convert.ToString(row[1]);
                    textBox3.Text = Convert.ToString(row[2]);
                    textBox4.Text = Convert.ToString(row[3]);
                    textBox5.Text = Convert.ToString(row[4]);
                    textBox6.Text = Convert.ToString(row[5]);
                    textBox7.Enabled = false;
                    textBox8.Enabled = false;
                    textBox9.Enabled = false;
                }
            }
            else if (change == false)
            {
                button1.Text = "ДОБАВИТЬ";
                if (Owner.Name == "Tovar")
                {
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox9.Text = "";
                }
                else if (Owner.Name == "Category")
                {
                    label1.Text = "Категория";
                    label2.Text = "";
                    label3.Text = "";
                    label4.Text = "";
                    label5.Text = "";
                    label6.Text = "";
                    label7.Text = "";
                    label8.Text = "";
                    textBox2.Text = "";
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;
                    textBox5.Enabled = false;
                    textBox6.Enabled = false;
                    textBox7.Enabled = false;
                    textBox8.Enabled = false;
                    textBox9.Enabled = false;
                }
                else if (Owner.Name == "Clients")
                {
                    label1.Text = "ФамилияКлиента";
                    label2.Text = "Имя";
                    label3.Text = "Отчество";
                    label4.Text = "ЭлектроннаяПочта";
                    label5.Text = "Телефон";
                    label6.Text = "";
                    label7.Text = "";
                    label8.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Enabled = false;
                    textBox8.Enabled = false;
                    textBox9.Enabled = false;
                }
                else if (Owner.Name == "Contracts")
                {
                    label1.Text = "Сотрудник";
                    label2.Text = "Товар";
                    label3.Text = "Клиент";
                    label4.Text = "Количество";
                    label5.Text = "";
                    label6.Text = "";
                    label7.Text = "";
                    label8.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Enabled = false;
                    textBox7.Enabled = false;
                    textBox8.Enabled = false;
                    textBox9.Enabled = false;
                }
                else if (Owner.Name == "Manufactures")
                {
                    label1.Text = "Наименование предприятия";
                    label2.Text = "Город";
                    label3.Text = "Телефон";
                    label4.Text = "";
                    label5.Text = "";
                    label6.Text = "";
                    label7.Text = "";
                    label8.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Enabled = false;
                    textBox6.Enabled = false;
                    textBox7.Enabled = false;
                    textBox8.Enabled = false;
                    textBox9.Enabled = false;
                }
                else if (Owner.Name == "Positions")
                {
                    label1.Text = "Наименование";
                    label2.Text = "Оклад";
                    label3.Text = "";
                    label4.Text = "";
                    label5.Text = "";
                    label6.Text = "";
                    label7.Text = "";
                    label8.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Enabled = false;
                    textBox5.Enabled = false;
                    textBox6.Enabled = false;
                    textBox7.Enabled = false;
                    textBox8.Enabled = false;
                    textBox9.Enabled = false;
                }
                else if (Owner.Name == "Workers")
                {
                    label1.Text = "Фамилия";
                    label2.Text = "ДатаРождения";
                    label3.Text = "Должность";
                    label4.Text = "АдресПроживания";
                    label5.Text = "Телефон";
                    label6.Text = "";
                    label7.Text = "";
                    label8.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Enabled = false;
                    textBox8.Enabled = false;
                    textBox9.Enabled = false;
                }
            }
        }
    }
}
