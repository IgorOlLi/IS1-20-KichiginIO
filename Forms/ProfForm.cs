using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IS1_20_KichiginIO.Classes;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;

namespace IS1_20_KichiginIO
{
    public partial class Form1 : MetroForm
    {
        MySqlConnection conn;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = DBUtils.GetDBConnection();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            User.fio = metroTextBox1.Text;
            User.phone = metroTextBox2.Text;
            User.access = Convert.ToInt32(metroComboBox1.Text);
            User.login = metroTextBox3.Text;
            User.password = metroTextBox4.Text;
            User.prof = Convert.ToInt32(metroComboBox1.Text);
            conn.Open();
            string sql = $"INSERT INTO T_Empl (fio_Empl, phone_Empl, access_Empl, login_Empl, pass_Empl, spec_Empl) VALUES ('{User.fio}','{User.phone}','{User.access}','{User.login}','{User.password}','{User.prof}')";
            MySqlCommand command = new MySqlCommand(sql, conn);
            conn.Close();
        }
    }
}
