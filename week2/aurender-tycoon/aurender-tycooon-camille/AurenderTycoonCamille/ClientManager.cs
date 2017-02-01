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
     * This class manage client info
     * check the client history exist or not
     * if not, add new client data in dictionary
     * 
     * @date    2017/01/31
     */
    class ClientManager : DBManager
    {
        Dictionary<ClientData, string> clientMap = new Dictionary<ClientData, string>();

        /* read client data at DB */
        new public static void ReadDB()
        {
            string strConn = "Server = localhost;Database = sowrender;uid=camille'Pwd=9210wonwjd;";
            MySqlConnection scon;

            using (scon = new MySqlConnection(strConn))
            {
                scon.Open();
                string sql = "SELECT * FROM client";

                MySqlCommand cmd = new MySqlCommand(sql, scon);
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ClientData clientData = new ClientData(dr);
                    clientMap.Add(clientData, Convert.ToString(dr["client_address"]));
                }

                dr.Close();
            }
        }
    }
}
