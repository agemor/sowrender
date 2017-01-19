using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
            Console.WriteLine("연도별 분류");
            yearOfDate.YearSaperated(salesRowData);
            Console.WriteLine("--------------------------------");

        }
    }

    /**
     * This class extrac data and make statistics
     * 
     * @author  WonJung Jeong
     * @date    2017/01/19
     */
    class StatisticsExtractor
    {
        public void YearSaperated(List<SalesRowData> salesRowData)
        {
            List<string> yearList = new List<string>(); //임시
            bool counting = false;       //임시
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
        public void MapExtract(List<SalesRowData> salesRowDataList, string year)
        {
            var map = new Dictionary<string, double>();

            for (int i = 1; i < salesRowDataList.Count; i++)
            {
                if (year == salesRowDataList[i].dateShipped.ToString("yyyy"))
                {
                    SalesRowData rowData = salesRowDataList[i];

                    if (!map.ContainsKey(rowData.model))
                    {
                        map.Add(rowData.model, 0);
                    }
                    map[rowData.model] += rowData.amountUsd;
                }
            }

            foreach (KeyValuePair<string, double> entry in map)
            {
                Console.WriteLine(year + " " + entry.Key + " : " + AddThousandCommas(entry.Value));//string.Format("{0:n0}",entry.Value));
            }
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
            rawNumber = decimalNum[0] + ".";
            if (decimalNum.Length == 2)
                rawNumber += decimalNum[1];
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
