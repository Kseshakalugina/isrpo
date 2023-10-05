using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursa
{
    public partial class Tovar : Form
    {
        Add add = new Add();
        Zapros zapros = new Zapros();
        Color FrameColor = Color.Black;//цвет рамки
        bool EnableNonClientAreaPaint = true;
        private static string connectString = "Data Source =DESKTOP-N2KIJCC\\SQLEXPRESS;Initial Catalog =kurs_kalugina;" +
                "Integrated Security = true;"; // данные для подключения к базе
        private SqlConnection myConnection; // подключение к базе
        public Tovar()
        {
            InitializeComponent();
        }

        // Метод для обновления dataGridView1
        private void Update1(string sql) // обновление
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
            if (sender == button2) 
            {
                add.change = false;
                add.ShowDialog();
                Update1("SELECT * FROM Товары ORDER BY [Код товара]");
            }
            else if (sender == button4) 
            {
                int index = 0;
                add.id = int.Parse(textBox1.Text);
                for (int i = 0; i < dataGridView1.Rows.Count; i++) 
                {
                    if (int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()) == add.id)
                    {
                        index = i;
                        break;
                    }
                }
                string[] row = new string[dataGridView1.Rows[index].Cells.Count]; // массив строк, в котором хранится строка для изменений 
                for (int i = 0; i < dataGridView1.Rows[index].Cells.Count; i++) // заполняется значениями массив строк
                {
                    row[i] = dataGridView1.Rows[index].Cells[i].Value.ToString();
                }
                add.row = row;
                add.change = true;
                add.ShowDialog();
                Update1("SELECT * FROM Товары ORDER BY [Код товара]");
                textBox1.Text = "";
            }
            else if (sender == button3) // удалить
            {
                string message = "Вы действительно хотите удалить выбранную запись?";

                if (MessageBox.Show(message, "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }
                myConnection = new SqlConnection(connectString);
                myConnection.Open();
                string cmdDelFromTovari = "Delete from Товары where [Код товара] = @code";
                SqlCommand cmd1 = new SqlCommand(cmdDelFromTovari, myConnection);
                SqlParameter pr1 = new SqlParameter("@code", textBox1.Text);
                cmd1.Parameters.Add(pr1); // добавление параметра в команду
                cmd1.ExecuteNonQuery(); // выполнение запроса
                dataGridView1.Columns.Clear();
                myConnection.Close();
                string sql = "SELECT * FROM Товары ORDER BY [Код товара]";
                Update1(sql);
                textBox1.Text = "";
            }

            else if (sender == button5) // запрос про прибыль
            {
                zapros.ShowDialog();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Owner.Show();
            Close();
        }

        private void Tovar_Load(object sender, EventArgs e)
        {
            Update1("SELECT * FROM Товары ORDER BY [Код товара]");
            add.Owner = this;
            zapros.Owner = this;
        }
    }
}
