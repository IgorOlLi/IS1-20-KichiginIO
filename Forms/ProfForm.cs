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
using System.Text.RegularExpressions;

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
            GetComboBoxList1();
            GetComboBoxList2();
        }

        public void GetComboBoxList1()
        {
            DataTable list_access_table = new DataTable();
            MySqlCommand list_access_command = new MySqlCommand();
            conn.Open();
            list_access_table.Columns.Add(new DataColumn("id", System.Type.GetType("System.Int32")));
            list_access_table.Columns.Add(new DataColumn("access", System.Type.GetType("System.String")));
            metroComboBox1.DataSource = list_access_table;
            metroComboBox1.DisplayMember = "access";
            metroComboBox1.ValueMember = "id";
            string sql_list_users = "SELECT id_Access, title_Access FROM T_Access";
            list_access_command.CommandText = sql_list_users;
            list_access_command.Connection = conn;
            MySqlDataReader list_access_reader;
            try
            {
                list_access_reader = list_access_command.ExecuteReader();
                while (list_access_reader.Read())
                {
                    DataRow rowToAdd = list_access_table.NewRow();
                    rowToAdd["id"] = Convert.ToInt32(list_access_reader[0]);
                    rowToAdd["access"] = list_access_reader[1].ToString();
                    list_access_table.Rows.Add(rowToAdd);
                }
                list_access_reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка чтения списка ЦП \n\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            finally
            {
                conn.Close();
            }
        }

        public void GetComboBoxList2()
        {
            DataTable list_spec_table = new DataTable();
            MySqlCommand list_spec_command = new MySqlCommand();
            conn.Open();
            list_spec_table.Columns.Add(new DataColumn("id", System.Type.GetType("System.Int32")));
            list_spec_table.Columns.Add(new DataColumn("spec", System.Type.GetType("System.String")));
            metroComboBox2.DataSource = list_spec_table;
            metroComboBox2.DisplayMember = "spec";
            metroComboBox2.ValueMember = "id";
            string sql_list_users = "SELECT id_Spec, title_Spec FROM T_Spec";
            list_spec_command.CommandText = sql_list_users;
            list_spec_command.Connection = conn;
            MySqlDataReader list_spec_reader;
            try
            {
                list_spec_reader = list_spec_command.ExecuteReader();
                while (list_spec_reader.Read())
                {
                    DataRow rowToAdd = list_spec_table.NewRow();
                    rowToAdd["id"] = Convert.ToInt32(list_spec_reader[0]);
                    rowToAdd["spec"] = list_spec_reader[1].ToString();
                    list_spec_table.Rows.Add(rowToAdd);
                }
                list_spec_reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка чтения списка ЦП \n\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            finally
            {
                conn.Close();
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            User.fio = metroTextBox1.Text;
            string phoneNumber = metroTextBox2.Text;
            string pattern = @"\D";
            string target = "";
            Regex regex = new Regex(pattern);
            string result = regex.Replace(phoneNumber, target);
            User.phone = result;
            User.access = metroComboBox1.SelectedValue.ToString();
            User.login = metroTextBox3.Text;
            User.password = Enigma.sha256(metroTextBox4.Text);
            User.spec = metroComboBox2.SelectedValue.ToString();
            MessageBox.Show($"{User.fio},{User.phone},{User.access},{User.login},{User.password},{User.spec}");
            conn.Open();
            string sql = $"INSERT INTO T_Empl (fio_Empl, phone_Empl, access_Empl, login_Empl, pass_Empl, spec_Empl) VALUES ('{User.fio}', '{User.phone}', '{User.access}', '{User.login}', '{User.password}', '{User.spec}');";
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }
    }
}
