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
                //И в зависимости от того, какая роль (цифра) хранится в поле класса и передана в метод, показываются те или иные кнопки.
                //Вы можете скрыть их и не отображать вообще, здесь они просто выключены
                case 1:
                    metroLabel1.Text = "Админ";
                    metroLabel2.Text = $"{Auth.authFio}";
                    metroLabel3.Text = $"Id {Auth.authId}";
                    break;
                case 2:
                    metroLabel1.Text = "Доступ Стандартный";
                    metroLabel2.Text = $"{Auth.authFio}";
                    metroLabel3.Text = $"Id {Auth.authId}";
                    metroButton2.Enabled = false;
                    metroButton3.Enabled = false;
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Hide();
            //Инициализируем и вызываем форму диалога авторизации
            AuthForm authForm = new AuthForm();
            //Вызов формы в режиме диалога
            authForm.ShowDialog();
            //Если авторизации была успешна и в поле класса хранится истина, то делаем движуху
            this.Show();
            //Вытаскиваем из класса поля в label'ы
            ManagerRole(Auth.authRole);
            }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
