using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace IS1_20_KichiginIO
{
    public partial class AuthForm : MetroForm
    {
        MySqlConnection conn;
        string authId;
        string authFio;
        int authRole;

        public AuthForm()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            //Запрос в БД на предмет того, если ли строка с подходящим логином и паролем
            string sql = "SELECT * FROM T_Empl WHERE login_Empl = @un and  pass_Empl= @up";
            //Открытие соединения
            conn.Open();
            //Объявляем таблицу
            DataTable table = new DataTable();
            //Объявляем адаптер
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            //Объявляем команду
            MySqlCommand command = new MySqlCommand(sql, conn);
            //Определяем параметры
            command.Parameters.Add("@un", MySqlDbType.VarChar, 25);
            command.Parameters.Add("@up", MySqlDbType.VarChar, 25);
            //Присваиваем параметрам значение
            command.Parameters["@un"].Value = metroTextBox1.Text;
            command.Parameters["@up"].Value = metroTextBox2.Text; //Добавить Хеширование
            //Заносим команду в адаптер
            adapter.SelectCommand = command;
            //Заполняем таблицу
            adapter.Fill(table);
            //Закрываем соединение
            conn.Close();
            //Если вернулась больше 0 строк, значит такой пользователь существует
            if (table.Rows.Count > 0)
            {
                //Достаем данные пользователя в случае успеха
                GetUserInfo(metroTextBox1.Text);
                //Закрываем форму
                this.Close();
            }
            else
            {
                //Отобразить сообщение о том, что авторизаия неуспешна
                MessageBox.Show("Неверные данные авторизации!");
            }
        }

        private void metroTextBox2_Click(object sender, EventArgs e)
        {

        }

        private void AuthForm_Load(object sender, EventArgs e)
        {
            //string connStr = "server=chuc.caseum.ru;port=33333;user=st_1_20_16;database=is_1_20_st16_KURS;password=44247229;";
            string connStr = "server=10.90.12.110;port=33333;user=st_1_20_16;database=is_1_20_st16_KURS;password=44247229;";
            conn = new MySqlConnection(connStr);
        }

        public void GetUserInfo(string login_user)
        {
            
            string selected_id_stud = metroTextBox1.Text;
            conn.Open();
            string sql = $"SELECT * FROM T_Empl WHERE login_Empl='{login_user}'";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Auth.authId = reader[0].ToString();
                Auth.authFio = reader[1].ToString();
                Auth.authRole = Convert.ToInt32(reader[3].ToString());
            }
            reader.Close();
            conn.Close();
        }
    }
}
