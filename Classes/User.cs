using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace IS1_20_KichiginIO.Classes
{
    class User
    {
        public static int userId;
        public static string userFio;
        public static string userPhone;
        public static int UserAccess;
        public static string userLogin;
        public static string userPassword;
        public static int userProf;

        void UserCreate()
        {
            conn = DBUtils.GetDBConnection();
            string sql = $"INSERT INTO T_Empl ()";
        }

        void UserDelete()
        {
            string sql = $"";
        }

        void UserChange()
        {
            string sql = $"";
        }
    }
}
