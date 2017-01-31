using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurenderTycoonDuke
{
    class SalesManager
    {
        public List<Invoice> invoiceList = new List<Invoice>();

        public void AddInovoice(string invoiceData)
        {
            Invoice invoice = new Invoice(invoiceData);
            invoiceList.Add(invoice);
        }
    }
}
