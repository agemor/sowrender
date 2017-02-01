using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurenderTycoonDuke
{
    class ReceiptManager
    {
        private static ReceiptManager _instance;
        protected ReceiptManager() { }
        static public ReceiptManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ReceiptManager();
            }
            return _instance;
        }

        private Dictionary<Receipt, int> receiptList = new Dictionary<Receipt, int>();

        public void AddReceipt(Invoice invoice,int Quantity)
        {
            if(receiptList.Keys.Count != 0)
            {
                foreach (var data in receiptList.Keys.ToList())
                {
                    Console.WriteLine(invoice.ProductData.ModelName + "|" + data.ProductData.ModelName);
                    if (data.Equal(invoice))
                        receiptList[data] += Quantity;
                    else
                        receiptList.Add(new Receipt(invoice), invoice.Quantity);
                }
            }
            else
                receiptList.Add(new Receipt(invoice), invoice.Quantity);
        }
        public int CheckReceiptAndStock(Invoice invoice)
        {
            int result = 0;
            foreach (var data in receiptList)
            {
                if(data.Key.Equal(invoice))
                    result = data.Value;

                Console.WriteLine(result);
            }
            return result;
        }
        public void PrintReceiptList()
        {
            foreach(var data in receiptList)
            {
                Console.Write(data.Key.Client.ClientName + "," + data.Key.Client.ContactInformation + "," + data.Key.Client.Destination + " | ");
                Console.Write(data.Key.ProductData.ModelName + "," + data.Key.ProductData.Color + "," + data.Key.ProductData.Capacity + " | ");
                Console.WriteLine(data.Value);
            }
        }
    }
}
