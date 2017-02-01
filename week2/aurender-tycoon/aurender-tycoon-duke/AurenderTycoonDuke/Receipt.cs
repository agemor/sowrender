using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurenderTycoonDuke
{
    class Receipt
    {
        public ProductData ProductData { get; }
        public Client Client { get; }
        public Receipt(Invoice invoice)
        {
            Client = invoice.Client;
            ProductData = invoice.ProductData;
        }
        public bool Equal(object _invoice)
        {
            Invoice invoice = (Invoice)_invoice;
            if (ProductData.ModelName.Equals(invoice.ProductData.ModelName, StringComparison.Ordinal) &&
               ProductData.Color.Equals(invoice.ProductData.Color, StringComparison.Ordinal) &&
               ProductData.Capacity.Equals(invoice.ProductData.Capacity, StringComparison.Ordinal) &&
               Client.ClientName.Equals(invoice.Client.ClientName, StringComparison.Ordinal) &&
               Client.ContactInformation.Equals(invoice.Client.ContactInformation, StringComparison.Ordinal) &&
               Client.Destination.Equals(invoice.Client.Destination, StringComparison.Ordinal))
                return true;
            else
                return false;
        }
    }
}
