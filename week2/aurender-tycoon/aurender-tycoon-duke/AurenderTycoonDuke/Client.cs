using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurenderTycoonDuke
{
    class Client
    {
        public string ClientName { get; }
        public string ContactInformation { get; }
        public string Destination { get; }
        public Client(string clientName, string contactInformation, string destination)
        {
            ClientName = clientName;
            ContactInformation = contactInformation;
            Destination = destination;
        }
    }
}
