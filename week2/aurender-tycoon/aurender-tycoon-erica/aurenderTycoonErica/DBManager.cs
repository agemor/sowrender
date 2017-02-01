using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

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
        public bool Connect(string server, string database, string uid, string pwd)
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
                    return false;
                }
            }
            return true;

        }

        /* DB가 connect이 됐는지 체크 */
        public bool IsConnected()
        {
            if (conn == null)
            {
                return false;
            }
            return true;
        }

        /* 제품 추가 (Row 추가) */
        public bool Insert(Product p)
        {
            if (!IsConnected()) { return false; }
            string query = "INSERT INTO sowrender_product VALUES ";

            query += "(NULL,";
            query += "'" + p.ModelName + "', ";
            query += "'" + p.Color + "',";
            query += "'" + p.Capacity + "',";
            query += "" + p.Price + ",";
            query += "" + p.Stock + ");";
            

            /* INSERT */
            ExcuteQuery(query);

            return true;

        }

        public DataSet Select(string query, string table)
        {
            DataSet ds = new DataSet();

            //MySqlDataAdapter 클래스를 이용하여 비연결 모드로 데이타 가져오기
            MySqlDataAdapter adpt = new MySqlDataAdapter(query, conn);
            adpt.Fill(ds, table);

            return ds;
        }

        //Todo: 
        /* Row 수정 */
        public void Update(string table, string set, string where)
        {
            string query = "UPDATE "+table+" SET "+set+" WHERE "+ where;

            ExcuteQuery(query);
        }

        /* 제품 삭제 (Row 삭제) */
        public bool Delete(Product p)
        {
            if (!IsConnected()) { return false; }
            string query = "DELETE FROM sowrender_product WHERE (";
            query += "model_name=" + "'" + p.ModelName + "', ";
            query += "model_color=" + "'" + p.Color + "',";
            query += "model_capacity=" + "'" + p.Capacity + "',";
            query += "price=" + "'" + p.Price + "',";
            query += "stock=" + "'" + p.Stock + "',";
            query += "'" + p.Capacity + "',)";

            ExcuteQuery(query);
            return true;

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
