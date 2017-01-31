using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace aurenderTycoonErica
{
    class DBManager
    {
        private MySqlConnection conn;

        /* 싱글톤 */
        static protected DBManager _instance;
        protected DBManager() { }

        /* 싱글톤에서 객체 생성 */
        static public DBManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DBManager();
            }
            return _instance;
        }

        /* DB 연결 */
        public void Connect(string server, string database, string uid, string pwd)
        {
            if (conn == null)
            {
                string strConn = "Server=" + server + ";Database=" + database + ";Uid=" + uid + ";Pwd=" + pwd + ";";
                conn = new MySqlConnection(strConn);

                try
                {
                    conn.Open();
                }
                catch (Exception e)
                {
                    Console.WriteLine("DB Error : " + e);
                }
            }

        }

        /* 제품 추가 (Row 추가) */
        public void Insert(Product p)
        {
            string query = "INSERT INTO sowrender_product VALUES ";

            query += "(NULL,";
            query += "'" + p.ModelName + "', ";
            query += "'" + p.Color + "',";
            query += "'" + p.Capacity + "',";
            query += "" + p.Price + ",";
            query += "" + p.Stock + ");";

            Console.WriteLine(query);


            /* INSERT */
            ExcuteQuery(query);

        }

        //Todo: 
        /* Row 수정 */
        public void Update(Product p)
        {
            string query = "UPDATE sowrender_product SET Name='Tim' WHERE Id=2";
            ExcuteQuery(query);
        }

        /* 제품 삭제 (Row 삭제) */
        public void Delete(Product p)
        {

            string query = "DELETE FROM sowrender_product WHERE (";
            query += "model_name=" + "'" + p.ModelName + "', ";
            query += "model_color=" + "'" + p.Color + "',";
            query += "model_capacity=" + "'" + p.Capacity + "',";
            query += "price=" + "'" + p.Price + "',";
            query += "stock=" + "'" + p.Stock + "',";
            query += "'" + p.Capacity + "',)";

            ExcuteQuery(query);

        }

        /* DB 연결 해제 */
        public void close()
        {
            conn.Close();
        }

        /* 쿼리 실행 */
        private void ExcuteQuery(string query)
        {
            if (conn == null)
            {
                Console.WriteLine("DB not connect");
                return;
            }

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine("ProductManager.ExcuteQuery Error : " + e);
            }
        }
    }
}
