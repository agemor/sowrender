using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AurenderTycoonCamille
{
    /**
     * This class manage client data
     */
    class ClientManager //: DBReader, DBWriter
    {
        /* check whether entered client is exist or not */
        bool ListCheck()//bool DBReader.ListCheck()
        {
            bool isClientExist = true;
            return isClientExist;
        }

        /* add new client data on DB */
        /*void DBWriter.WriteOnDB()
        {
        }*/

        /* read data in DB & return client_id and discount */
        public ReturnData ReadDB(string table)//ReturnData DBReader.ReadDB(string table)
        {
            ReturnData clientData = new ReturnData();
            string strConn = "Server = localhost;Database=test;uid=camille'Pwd=9210wonwjd;";

            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                conn.Open();
                Console.WriteLine("실화냐?....;");
            }
            return clientData;
        }
    }
}
