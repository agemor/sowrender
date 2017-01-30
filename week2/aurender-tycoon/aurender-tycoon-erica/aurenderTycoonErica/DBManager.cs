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
        static  protected DBManager _instance;
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
        public void DBConnect(string server, string database, string uid, string pwd)
        {
            string strConn = "Server=" + server + "Database=" + database + "Uid=" + uid + "Pwd=" + pwd;
            conn = new MySqlConnection(strConn);

            try
            {
                conn.Open();
            }
            catch
            {
                Console.WriteLine("DB Error : Not Connect");
            }
        }

        /* 제품 추가 (Row 추가) */
        public void Add(Product p)
        {
            string query = "INSERT INTO sowrender_product VALUES ";
            for (int i = 0; i < p.AttributeList.Count(); i++)
            {
                query += "( null,";
                query += "'" + p.ModelName + "', ";
                query += "'" + p.AttributeList[i].Color + "',";
                query += "'" + p.AttributeList[i].Capacity + "'";
                query += "'" + p.AttributeList[i].Price + "',";
                query += "'" + p.AttributeList[i].Stock + "',)";

                /* 여러 value를 insert하기 위해 ,를 붙임 */
                if (i != p.AttributeList.Count())
                {
                    query += ",";
                }
            }

            /* INSERT */
            ExcuteQuery("INSERT INTO sowrender_product VALUES" + query);

        }

        //Todo: 
        /* Row 수정 */
        public void Modify(Product p)
        {
            string query = "UPDATE sowrender_product SET Name='Tim' WHERE Id=2";
            ExcuteQuery(query);
        }

        /* 제품 삭제 (Row 삭제) */
        public void Delete(Product p)
        {
            /* 속성값이 넘어오지 않을 경우, 모든 제품을 삭제 */
            if (p.AttributeList.Count() == 0)
            {
                string query = "DELETE FROM sowrender_product WHERE ";
                  query += "model_name=" + p.ModelName;

                ExcuteQuery(query);
            }
            else
            {
                for (int i = 0; i < p.AttributeList.Count(); i++)
                {
                    string query = "DELETE FROM sowrender_product WHERE (";
                    query += "model_name=" + "'" + p.ModelName + "', ";
                    query += "model_color=" + "'" + p.AttributeList[i].Color + "',";
                    query += "model_capacity=" + "'" + p.AttributeList[i].Capacity + "',";
                    query += "price=" + "'" + p.AttributeList[i].Price + "',";
                    query += "stock=" + "'" + p.AttributeList[i].Stock + "',";
                    query += "'" + p.AttributeList[i].Capacity + "',)";

                    ExcuteQuery(query);
                }
            }
          
        }

        /* DB 연결 해제 */
        public void DBclose()
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
