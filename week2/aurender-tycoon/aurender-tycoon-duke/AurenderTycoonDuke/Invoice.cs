using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurenderTycoonDuke
{
    class Invoice : Changeable
    {
        ProductManager productManager = ProductManager.GetInstance();
        public int Quantity { get; }
        public int DiscountRate { get; }
        public ProductData ProductData { get; }
        public Client Client { get; }
        private Invoice() { }
        public Invoice(string invoiceData)
        {
            Changeable changeable = new Invoice();
            try
            {
                string[] splitResult = BindInvoiceData(invoiceData);
                Quantity = changeable.StringToInt(splitResult[4]);
                ProductData = new ProductData(splitResult[1].Trim(), splitResult[2].Trim(), splitResult[3].Trim());
                Client = new Client(splitResult[0].Trim(), splitResult[5].Trim(), splitResult[6].Trim());
            }
            catch
            {
                Console.WriteLine("Invoice Data Error ");
                Quantity = -1;
                ProductData = new ProductData("-", "-", "-");
                Client = new Client("-","-","-");
            }

        }
        private string[] BindInvoiceData(string invoiceData)
        {
            invoiceData = invoiceData.Replace("(", ",");
            invoiceData = invoiceData.Replace(")", "");
            //Console.WriteLine(invoiceData);
            string[] splitResult = invoiceData.Split(',');
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
        int Changeable.StringToInt(string data)
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
