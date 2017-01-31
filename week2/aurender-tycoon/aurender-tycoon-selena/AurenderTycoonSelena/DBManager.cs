using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace AurenderTycoonSelena
{
    class DBManager
    {
        MySqlCommand cmd;
        DBConnector connector = new DBConnector();

        /* (tableName) 테이블에  있는 row 개수 가져오기 */
        public int getRowCount(string tableName)
        {
            string countQuery = "SELECT COUNT(*) FROM" + tableName + ";";

            cmd = new MySqlCommand(countQuery, connector.GetConnect());
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            // error : row의 개수가 정상적으로 받아와지지 않음

            Console.WriteLine(count); // 확인용, 나중에 삭제해야 함

            return count;
        }

        public string[] SelectFromTable(string tableName, string query, string[] columns)
        {
            /* 모든 row를 저장하기 위한 배열 따라서 row의 개수 받아옴*/
            int rowCount = getRowCount(tableName);
            string[] chunks = new string[rowCount]; 

            cmd = new MySqlCommand(query, connector.GetConnect());
            MySqlDataReader reader = cmd.ExecuteReader();

            /* 더이상 read할게 없을 때까지 반복 */
            int index = 0;
            while (reader.Read())
            {
                // Console.WriteLine(reader["client_number"]); // 정상적으로 select 되는지 테스팅 코드

                string test = ""; // 나중에 변수명 바꿀 것
                for(int i = 0; i < rowCount; i++)
                {
                    test += reader[columns[i]] + ", ";
                    //예외사항 미처리 : 이럴 경우에는 마지막 컬럼에도 ,가 들어가는데 어떻게 해야할까?
                }

                chunks[index] = test;
                index++;
            }

            reader.Close();

            return chunks;
        } // 이렇게 짰을 경우의 문제점 : 컬럼에 대한 정보를 다 알고있어야함 ;;

        public void ExecuteQuery(string query)
        {
            cmd = new MySqlCommand(query, connector.GetConnect());
            cmd.ExecuteNonQuery();
        }
    }
}
