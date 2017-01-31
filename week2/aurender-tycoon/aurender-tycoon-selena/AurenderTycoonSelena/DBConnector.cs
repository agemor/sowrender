using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;

namespace AurenderTycoonSelena
{
    class DBConnector
    {
        public static MySqlConnection connection;
        string MY_CONNETION_STRING = "Server=localhost;Port=3306;Database=sowrender;Uid=root;";

        /* DB와 프로그램 연결 */
        public void Connect()
        {
            connection = new MySqlConnection(MY_CONNETION_STRING);
            connection.Open();
        }

        /* connection close */
        public void CloseConnect()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
                Console.WriteLine("클로즈"); // 정상적으로 클로즈 되는지 확인하기 위한 것 후에 삭제.
            }
        }
        

        public MySqlConnection GetConnect()
        {
            return connection;
        }
    }
};
