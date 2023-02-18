using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS1_20_KichiginIO
{
    static class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "10.90.12.110";
            //string host = "chuc.caseum.ru";
            string port = "33333";
            string database = "is_1_20_st16_KURS";
            string username = "st_1_20_16";
            string password = "44247229";
            string connString = $"server={host};port={port};user={username};database={database};password={password};";
            MySqlConnection conn = new MySqlConnection(connString);
            return conn;
        }
    }
}
