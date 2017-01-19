using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace CsvParser
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText(@"C:\Users\yangd\Documents\Sowrender\sample_revenue.csv", Encoding.UTF8);
            List<SalesRowData> salesRowDataList = new List<SalesRowData>();
            int count = 0;

            string[] lines = text.Split('\n');

            foreach (string line in lines)
            {
                string[] chucks = line.Split(',');


                if (chucks.Length > 19)
                {
                    chucks[5] = chucks[5] + "," + chucks[6];
                    for (int i = 6; i < chucks.Length - 1; i++)
                    {
                        chucks[i] = chucks[i + 1];
                    }
                    chucks[chucks.Length - 1] = null;
                    chucks[5] = chucks[5].Substring(1, chucks[5].Length - 2);
                }

                SalesRowData salesRowData = new SalesRowData();

                if (count != 0)
                {
                    salesRowData.rowId = StringToUnsignedInt(chucks[0]);
                    salesRowData.amoutUntaxed = StringToDouble(chucks[1]);
                    salesRowData.amountUsd = StringToDouble(chucks[2]);
                    salesRowData.company = chucks[3];
                    salesRowData.country = chucks[4];
                    salesRowData.customer = chucks[5];
                    salesRowData.dateMonth = StringToUnsignedInt(chucks[6]);
                    salesRowData.dateOrder = ConvertToDateTime(chucks[7]);
                    salesRowData.dateShipped = ConvertToDateTime(chucks[8]);
                    salesRowData.discount = StringToUnsignedInt(chucks[9]);
                    salesRowData.exchange = StringToUnsignedInt(chucks[10]);
                    salesRowData.model = chucks[11];
                    salesRowData.orderNumber = chucks[12];
                    salesRowData.priceUnit = StringToDouble(chucks[13]);
                    salesRowData.productId = StringToUnsignedInt(chucks[14]);
                    salesRowData.productName = chucks[15];
                    salesRowData.quantity = StringToUnsignedInt(chucks[16]);
                    salesRowData.status = chucks[17];
                    salesRowData.zip = chucks[18];

                    salesRowDataList.Add(salesRowData);
                    Console.WriteLine(salesRowData.rowId + " / " + salesRowData.productName);
                }
                count++;
            }
        }

        private static DateTime ConvertToDateTime(string value)
        {
            DateTime convertedDate = new DateTime();
            try
            {
                convertedDate = Convert.ToDateTime(value);
            }
            catch (FormatException)
            {
                Console.WriteLine("'{0}' is not in the proper format.", value);
                Environment.Exit(0);
            }
            return convertedDate;
        }
        public static uint StringToUnsignedInt(string value)
        {
            uint result;
            if (uint.TryParse(value, out result) && result >= 0)
                return result;
            else
            {
                Console.WriteLine("Unsignedint Error : Wrong Value : "+ value);
                Environment.Exit(0);
                return 0;
            }
        }
        public static double StringToDouble(string value)
        {
            double result;
            if (double.TryParse(value, out result))
                return result;
            else
            {
                Console.WriteLine("Double Error : Wrong Value : " + value);
                Environment.Exit(0);
                return 0;
            }
        }
    }

    class SalesRowData
    {
        public uint rowId;
        public double amoutUntaxed;
        public double amountUsd;
        public string company;
        public string country;
        public string customer;
        public uint dateMonth;
        public DateTime dateOrder;
        public DateTime dateShipped;
        public uint discount;
        public uint exchange;
        public string model;
        public string orderNumber;
        public double priceUnit;
        public uint productId;
        public string productName;
        public uint quantity;
        public string status;
        public string zip;
    }
}
