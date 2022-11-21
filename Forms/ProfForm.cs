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
    }
}
