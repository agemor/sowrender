using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurenderTycoonDuke
{
    class SalesManager
    {
        ProductManager productManager = ProductManager.GetInstance();
        ClientManager clientManager = ClientManager.GetInstance();
        ReceiptManager receiptManager = ReceiptManager.GetInstance();
        Invoice invoice;

        public void ConductInvoice(string invoiceData)
        {
            invoice = new Invoice(invoiceData);
            if (CheckInvoice(invoice) == 0)
            {
                if (invoice.Quantity > 0)
                    Sell(invoice);
                else if (invoice.Quantity < 0)
                    Refund(invoice);
                else
                    Console.WriteLine("Zero exception");
            }
        }
        private int CheckInvoice(Invoice invoice)
        {            
            if (invoice.Quantity == -1 && invoice.ProductData.ModelName.Equals("-", StringComparison.Ordinal) && invoice.Client.ClientName.Equals("-", StringComparison.Ordinal))
                return -1;
            else if (productManager.CheckProductData(invoice.ProductData) == 0)
            {
                Console.WriteLine("Wrong Product");
                return -1;
            }
            else
                return 0;
        }

        private void Sell(Invoice invoice)
        {
            if (productManager.GetProductStock(invoice.ProductData) >= invoice.Quantity && invoice.Quantity != 0)
            {
                productManager.UpdateProductStock(invoice.ProductData, invoice.Quantity);
                clientManager.AddClient(invoice.Client);
                receiptManager.AddReceipt(invoice,invoice.Quantity);
            }
            else
                Console.WriteLine("We don't have enough {0}-{1}-{2}, Sorry", invoice.ProductData.ModelName, invoice.ProductData.Color, invoice.ProductData.Capacity);
        }
        private void Refund(Invoice invoice)
        {
            int refundQuantity = invoice.Quantity * -1;
            int refundAvailableQuantity = receiptManager.CheckReceiptAndStock(invoice);
            if (refundAvailableQuantity > 0)
            {
                if (refundQuantity > refundAvailableQuantity)
                    refundQuantity = refundAvailableQuantity;
                
                productManager.UpdateProductStock(invoice.ProductData, refundQuantity*-1);
                receiptManager.AddReceipt(invoice,refundQuantity * -1);
            }
            else
                Console.WriteLine("You haven't bought {0}-{1}-{2}, Please check your receipt",invoice.ProductData.ModelName,invoice.ProductData.Color,invoice.ProductData.Capacity);  
        }
    }
}
