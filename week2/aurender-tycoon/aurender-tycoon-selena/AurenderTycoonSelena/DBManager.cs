using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;

namespace AurenderTycoonSelena
{
    class DBManager
    {
        /* 싱글톤 */
        //-------------------------------------------------------

        private static DBManager _instance;

        protected DBManager() { }

        public static DBManager GetInstance()
        {
            /* 한 번도 생성 안된 경우 생성 */
            if(_instance == null)
            {
                _instance = new DBManager();
            }

            return _instance;
        }

        //-------------------------------------------------------

        private MySqlConnection connection;
        private MySqlCommand cmd;

        /* DB와 프로그램 연결 */
        public void Connect(string server, string databaseName, string userId, string password)
        {
            string connectionString = "Server=" + server + ";Database=" + databaseName + ";Uid=" + userId + ";Pwd=" + password + ";";
            connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        /* connection close */
        public void CloseConnect()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        /* (tableName) 테이블에  있는 row 개수 가져오기 */
        public int GetRowCount(string tableName)
        {
            string countQuery = "SELECT COUNT(*) FROM " + tableName + ";";

            cmd = new MySqlCommand(countQuery, connection);
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());

            return count;
        }

        public string[] SelectFromTable(string tableName, string query, string[] columns)
        {
            /* 모든 row를 저장하기 위한 배열 따라서 row의 개수 받아옴*/
            int rowCount = GetRowCount(tableName);
            Console.WriteLine(rowCount.ToString());

            string[] chunks = new string[rowCount]; 

            cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            /* 더이상 read할 데이터가 없을 때까지 반복 */
            int index = 0;
            while (reader.Read())
            {

                string test = ""; // 나중에 변수명 바꿀 것
                for(int i = 0; i < columns.Length - 1; i++)
                {
                    test += reader[columns[i]] + ", ";
                }
                test += reader[columns[columns.Length - 1]];

                Console.WriteLine(test); // 테스팅 코드

                chunks[index] = test;
                index++;
            }

            reader.Close();

            return chunks;
        }

        /* insert, update, delete 처리 가능 */
        public void ExecuteQuery(string query)
        {
            cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }
    }
}
