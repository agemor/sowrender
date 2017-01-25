using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurenderTycoonDuke
{
    class Program
    {
        static void Main(string[] args)
        {
           
        }
        private void PrepareAurenderProduct()
        {

        }
        private void StartTycoonRoutine()
        {
            int clientCount = StringToInt(Console.ReadLine());
            if(clientCount > 0)
            {
                SalesManager salesManager = new SalesManager();
                
                for (int i = 0; i < clientCount; i++)
                {
                    salesManager.AddInovoice(Console.ReadLine());
                }
            }
        }
        private int StringToInt(string value)
        {
            int result;
            if (int.TryParse(value, out result))
                return result;
            else
            {
                Console.WriteLine("String To Int Error - Wrong Value : " + value);
                Environment.Exit(0);
                return 0;
            }
        }
    }

    #region Product
    class ProductManager
    {
        
        Dictionary<ProductData, ProductValue> productList = new Dictionary<ProductData, ProductValue>();
        public void AddProduct(string productString)
        {
            Product product = new Product(productString);
            productList.Add(product.productData, product.productValue);
        }
    }
    class Product
    {
        public ProductData productData { get; }
        public ProductValue productValue { get; }
        public Product(string productData)
        {
            this.productData = new ProductData(,,);
            this.productValue = new ProductValue(,);
        }
        private string[] SplitProductData(string productData)
        {

        }
        private int StringToInt(string value)
        {
            int result;
            if (int.TryParse(value, out result))
                return result;
            else
            {
                Console.WriteLine("String To Int Error - Wrong Value : " + value);
                Environment.Exit(0);
                return 0;
            }
        }
    }
    class ProductData
    {
        public string modelName { get; }
        public string color { get; }
        public string capacity { get; }
        public ProductData(string modelName, string color, string capacity)
        {
            this.modelName = modelName;
            this.color = color;
            this.capacity = capacity;
        }
    }
    class ProductValue
    {
        public int price { get; }
        public int stock { get; set; }
        public string shortInformation { get; }
        public ProductValue(int price, int stock, string shortInformation)
        {
            this.price = price;
            this.stock = stock;
            this.shortInformation = shortInformation;
        }
    }
    #endregion

    #region Client
    class ClientManager
    {
        List<Client> clientList = new List<Client>();
    }
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
    #endregion

    #region Sales
    class SalesManager
    {
        public List<Invoice> invoiceList = new List<Invoice>();

        public void AddInovoice(string invoiceData)
        {
            Invoice invoice = new Invoice(invoiceData);
            invoiceList.Add(invoice);
        }
    }
    class Invoice
    {
        public int quantity { get; }
        public int discountRate { get; }
        public ProductData productData { get; }
        public Client customerData { get; }
        public Invoice(string invoiceData)
        {
             try
            {
                string[] splitResult = SplitInvoiceData(invoiceData);
                string[] productData = SplitInvoiceProductData(splitResult[1]);
                this.quantity = StringToInt(splitResult[2]);
                this.productData = new ProductData(productData[0], productData[1], productData[2]);
                this.customerData = new Client(splitResult[0], splitResult[3], splitResult[4]);
            }
            catch
            {
                Console.WriteLine("Split Invoice Data Error");

            }

        }
        private string[] SplitInvoiceData(string invoiceData)
        {
            string[] splitResult = invoiceData.Split('|');
            return splitResult;
        }
        private string[] SplitInvoiceProductData(string invoiceProductData)
        {
            string[] splitResult = new string[3];
            string[] _splitResult = invoiceProductData.Split('(');
            string[] _secondSplitResult = _splitResult[1].Split(',');
            splitResult[0] = _splitResult[0];
            splitResult[1] = _secondSplitResult[0];
            splitResult[2] = _secondSplitResult[1].Substring(0, _secondSplitResult[1].Length - 1);
            return splitResult;
        }
        private int StringToInt(string data)
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
    #endregion

    #region Statistics
    class SalesStatistician
    {
        public void ViewReceiptBySale()
        {

        }
        public void ViewSalesVolume()
        {

        }
        public void ViewSalesVolumeByProduct()
        {

        }
        public void MakeCsv()
        {

        }
    }
    class Receipt
    {

    }
    #endregion
}
