using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace CsvParser_Camille
{
    class Program
    {
        static void Main(string[] args)
        {
            TypeOfDataCollector Collect = new TypeOfDataCollector();
            List<SalesRowData> salesRowData = new List<SalesRowData>(200);
            StatisticsExtractor yearOfDate = new StatisticsExtractor();

            string text = File.ReadAllText(@"C:\Users\dsm\Downloads\sample_revenue.csv", Encoding.UTF8);

            salesRowData = Collect.ReadFromCsv(text);
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Model   :    Price   :Account:  Average   ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("---------------------------------------------");
            Console.ResetColor();
            yearOfDate.YearSaperated(salesRowData);

        }
    }
    /**
     * This class is article of Dictionary
     */
    class PriceAccount
    {
        public double price;
        public double account;
    }

    /**
     * This class extrac data and make statistics
     * 
     * @author  WonJung Jeong
     * @date    2017/01/19
     */
    class StatisticsExtractor
    {
        /* extract year */
        public void YearSaperated(List<SalesRowData> salesRowData)
        {
            List<string> yearList = new List<string>();
            bool counting = false;
            for (int i = 1; i < salesRowData.Count; i++)
            {
                for (int j = 0; j < yearList.Count; j++)
                {
                    if (salesRowData[i].dateShipped.ToString("yyyy") == yearList[j])
                        counting = true;
                }
                if (counting == false)
                {
                    yearList.Add(salesRowData[i].dateShipped.ToString("yyyy"));
                    MapExtract(salesRowData, salesRowData[i].dateShipped.ToString("yyyy"));
                    Console.WriteLine();
                }
                counting = false;
            }
        }
        /* descending order */
        /* make statistics */
        public void MapExtract(List<SalesRowData> salesRowDataList, string year)
        {
            var map = new Dictionary<string, PriceAccount>();

            for (int i = 1; i < salesRowDataList.Count; i++)
            {
                if (year == salesRowDataList[i].dateShipped.ToString("yyyy"))
                {
                    SalesRowData rowData = salesRowDataList[i];
                    if (!map.ContainsKey(rowData.model))
                    {
                        map.Add(rowData.model, new PriceAccount());
                    }
                    map[rowData.model].price += rowData.amountUsd;
                    map[rowData.model].account += rowData.quantity;
                }
            }
            Console.WriteLine(year + "\n");
            foreach (KeyValuePair<string, PriceAccount> entry in map.OrderByDescending(num => num.Value.price))
            {
                Console.WriteLine("{0,10} : {1,10} : {2,5} : {3,10}",
               entry.Key, AddThousandCommas(Math.Round(entry.Value.price)), AddThousandCommas(entry.Value.account),
               Math.Round(entry.Value.price / entry.Value.account));
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("---------------------------------------------",Console.ForegroundColor);
            Console.ResetColor();
        }

        /* add commas */
        public string AddThousandCommas(double number)
        {
            string rawNumber = number.ToString();
            string[] decimalNum = rawNumber.Split('.');
            for (int i = 1; i < (decimalNum[0].Length + 1) / 3; i++)
            {
                decimalNum[0] = decimalNum[0].Insert(decimalNum[0].Length - (3 * i), ",");
            }
            rawNumber = decimalNum[0];
            if (decimalNum.Length == 2)
                rawNumber += "." + decimalNum[1];
            return rawNumber;
        }
    }

    /**
     * This class descirbes how we handle row data
     * 
     * @author WonJung Jeong    
     * @date   2017/01/18       
     */
    class SalesRowData
    {
        /* sales data */
        public uint rowId;
        public string model;
        public string orderNumber;
        public uint productId;
        public int quantity;

        /* sales day */
        public uint dateMonth;
        public DateTime dateOrder;
        public DateTime dateShipped;

        /* price */
        public double amountUsd;
        public double priceUnit;
        public int exchangeRate;
        public int discount;

        /* product state */
        public string company;
        public string customer;
        public string country;
        public string productName;
        public string status;
        public string zip;
    }

    /**
     * This class read csv file and collect data with each type
     * 
     * @author  WonJung Jeong
     * @date    2017/01/19
     */
    class TypeOfDataCollector
    {
        /* reading csv file and save data */
        public List<SalesRowData> ReadFromCsv(string text)
        {
            List<SalesRowData> salesRowDataList = new List<SalesRowData>(200);
            List<string> chucks = new List<string>(200);

            String[] lines = text.Split('\n'); //collect line which divided with '\n'

            foreach (string line in lines)
            {
                chucks = line.Split(',').ToList();

                if (chucks.Count > 19)
                {
                    chucks[5] = chucks[5] + ',' + chucks[6];
                    chucks[5] = chucks[5].Replace('"', ' ');
                    chucks[5] = chucks[5].Trim();
                    chucks.Remove(chucks[6]);
                }
                SalesRowData salesRowData = new SalesRowData();

                /* save salesRomData with each type of data */
                uint.TryParse(chucks[0], out salesRowData.rowId);
                double.TryParse(chucks[2], out salesRowData.amountUsd);
                salesRowData.company = chucks[3];
                salesRowData.country = chucks[4];
                salesRowData.customer = chucks[5];
                uint.TryParse(chucks[6], out salesRowData.dateMonth);
                salesRowData.dateOrder = ConvertToDateTime(chucks[7]);
                salesRowData.dateShipped = ConvertToDateTime(chucks[8]);
                int.TryParse(chucks[9], out salesRowData.discount);
                int.TryParse(chucks[10], out salesRowData.exchangeRate);
                salesRowData.model = chucks[11];
                salesRowData.orderNumber = chucks[12];
                double.TryParse(chucks[13], out salesRowData.priceUnit);
                uint.TryParse(chucks[14], out salesRowData.productId);
                salesRowData.productName = chucks[15];
                int.TryParse(chucks[16], out salesRowData.quantity);
                salesRowData.status = chucks[17];
                salesRowData.zip = chucks[18];

                salesRowDataList.Add(salesRowData);
            }
            return salesRowDataList;
        }
        /* string to DateTime funtion */
        public static DateTime ConvertToDateTime(string value)
        {
            DateTime convertedDate = new DateTime();
            try
            {
                convertedDate = Convert.ToDateTime(value);
            }
            catch (FormatException) { }
            return convertedDate;
        }
    }
}
