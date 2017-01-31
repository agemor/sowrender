using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurenderTycoonDuke
{
    class Client
    {
        public string clientName { get; }
        public string contactInformation { get; }
        public string destination { get; }
        public Client(string clientName, string contactInformation, string destination)
        {
            this.clientName = clientName;
            this.contactInformation = contactInformation;
            this.destination = destination;
        }
    }
}
