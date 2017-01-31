using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurenderTycoonDuke
{
    class Invoice : ChangeAble
    {
        public int quantity { get; }
        public int discountRate { get; }
        public ProductData productData { get; }
        public Client customerData { get; }
        private Invoice() { }
        public Invoice(string invoiceData)
        {
            ChangeAble changeAble = new Invoice();
            try
            {
                string[] splitResult = BindInvoiceData(invoiceData);
                string[] productData = BindInvoiceProductData(splitResult[1]);
                this.quantity = changeAble.StringToInt(splitResult[2]);
                this.productData = new ProductData(productData[0], productData[1], productData[2]);
                this.customerData = new Client(splitResult[0], splitResult[3], splitResult[4]);
            }
            catch
            {
                Console.WriteLine("Split Invoice Data Error");

            }

        }
        private string[] BindInvoiceData(string invoiceData)
        {
            string[] splitResult = invoiceData.Split('|');
            return splitResult;
        }
        private string[] BindInvoiceProductData(string invoiceProductData)
        {
            string[] splitResult = new string[3];
            string[] _splitResult = invoiceProductData.Split('(');
            string[] _secondSplitResult = _splitResult[1].Split(',');
            splitResult[0] = _splitResult[0];
            splitResult[1] = _secondSplitResult[0];
            splitResult[2] = _secondSplitResult[1].Substring(0, _secondSplitResult[1].Length - 1);
            return splitResult;
        }
        int ChangeAble.StringToInt(string data)
        {
            int result;
            if (int.TryParse(data, out result))
                return result;
            else
            {
                Console.WriteLine("String To Int Error - Wrong Data : " + data);
                Environment.Exit(0);
                return 0;
            }
        }
    }
}
