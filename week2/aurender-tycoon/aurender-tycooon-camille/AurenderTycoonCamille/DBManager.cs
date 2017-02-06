using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace AurenderTycoon
{
    /**
     * This class define read and write data from DB
     * 
     * @date    2017/01/31
     */
    public class DBManager
    {
        

        /* connect with DB */
        public void ConnectDB()
        {
        }

        /* disconnect with DB */
        public void DisconnectDB()
        {
        }

        /* read data from DB (connect mode)*/

        public static void ReadDB(string table)
        {
            string strConn = "Server = localhost;Database = sowrender;uid=camille'Pwd=9210wonwjd;";
            MySqlConnection scon;
            scon = new MySqlConnection(strConn);

            scon.Open();
            string sql = "SELECT * FROM " + table;

            MySqlCommand cmd = new MySqlCommand(sql, scon);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ProductData productData = new ProductData(dr);
            }
            dr.Close();

        }
    }
        /* write data at DB */
        /*
        public void InsertDB(string table, string data)
        {
            //scom.CommandText = "INSERT INTO " + table + " VALUES(" + data + ")";
        }*/
}
