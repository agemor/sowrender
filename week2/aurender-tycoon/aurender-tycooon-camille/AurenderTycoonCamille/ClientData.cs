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
     * This class define key value of client data
     * 
     * @date    2017/01/31
     */
    class ClientData
    {
        string client_name { get; }
        string client_call { get; }

        public ClientData(MySqlDataReader dr)
        {
            client_name = Convert.ToString(dr["client_name"]);
            client_call = Convert.ToString(dr["client_call"]);
        }
    }
}
