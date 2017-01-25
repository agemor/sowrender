using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurenderTycoonCamille
{

    /**
     * This class used like structer of purchase data
     * 
     * date 2017/01/25
     */
    class ClientData
    {
        //name
        //call
        //address
        //num of buy : discount benefit
        //information of bought product
        //refund bought product
    }

    /**
     * This class manage client data
     * 
     * date 2017/01/25
     */
    class ClientManager
    {
        /* add new client */
        void ClientRegistration()
        {
            var clientData = new Dictionary<string, ClientData>();
        }

        /* modify data of client */
        void ModifyClient(Dictionary<string, ClientData> clientData)
        {
            //search client with name and call
            //modify name or call
        }
    }
}
