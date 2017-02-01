using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurenderTycoonDuke
{
    class ClientManager
    {
        private static ClientManager _instance;
        protected ClientManager() { }
        static public ClientManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ClientManager();
            }
            return _instance;
        }

        private List<Client> clientList = new List<Client>();

        public void AddClient(Client client)
        {
            if (!clientList.Contains(client))
                clientList.Add(client);
        }
    }
}
