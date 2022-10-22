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

namespace IS1_20_KichiginIO
{
    public partial class AuthForm : MetroForm
    {
        MySqlConnection conn;
        public AuthForm()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM T_Empl WHERE login_Empl = @un and  pass_Empl= @up";
            conn.Open();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.Add("@un", MySqlDbType.VarChar, 25);
            command.Parameters.Add("@up", MySqlDbType.VarChar, 25);
            command.Parameters["@un"].Value = metroTextBox1.Text;
            command.Parameters["@up"].Value = metroTextBox2.Text; //Добавить Хеширование
            adapter.SelectCommand = command;
            adapter.Fill(table);
            conn.Close();
            if (table.Rows.Count > 0)
            {
                GetUserInfo(metroTextBox1.Text);
                this.Close();
            }
            else
            {
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

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Auth.authId = "0";
            Auth.authFio = "Гость";
            Auth.authRole = 0;
            this.Close();
        }
    }
}
