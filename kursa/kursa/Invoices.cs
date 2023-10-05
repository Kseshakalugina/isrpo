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
    public partial class Invoices : Form
    {
        Zapros zapros = new Zapros();
        Color FrameColor = Color.Black;//цвет рамки
        bool EnableNonClientAreaPaint = true;
        private static string connectString = "Data Source =DESKTOP-N2KIJCC\\SQLEXPRESS;Initial Catalog =kurs_kalugina;" +
                "Integrated Security = true;"; // данные для подключения к базе
        private SqlConnection myConnection; // подключение к базе
        public Invoices()
        {
            InitializeComponent();
        }

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
            Owner.Show();
            Close();
        }

        private void Invoices_Load(object sender, EventArgs e)
        {
            Update1("SELECT * FROM Накладные ORDER BY [Код товара]");
            zapros.Owner = this;
        }
    }
}
