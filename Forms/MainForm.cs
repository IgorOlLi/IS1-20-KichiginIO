using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;

namespace IS1_20_KichiginIO
{
    public partial class MainForm : MetroForm
    {

        public MainForm()
        {
            InitializeComponent();
        }

        public void ManagerRole(int role)
        {
            switch (role)
            {
                case 0:
                    metroLabel1.Text = "Доступ Стандартный";
                    metroLabel2.Text = $"{Auth.authFio}";
                    metroLabel3.Text = $"Id {Auth.authId}";
                    metroButton2.Enabled = false;
                    metroButton3.Enabled = false;
                    break;
                case 1:
                    metroLabel1.Text = "Админ";
                    metroLabel2.Text = $"{Auth.authFio}";
                    metroLabel3.Text = $"Id {Auth.authId}";
                    break;
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Hide();
            AuthForm authForm = new AuthForm();
            authForm.ShowDialog();
            this.Show();
            ManagerRole(Auth.authRole);
       
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
