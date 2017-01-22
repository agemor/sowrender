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
            SowrenderCSVParser parser = new SowrenderCSVParser();
            List<SalesRowData> salesRowDataList = parser.SplitReadText(text);
            var statisticalDataMap = parser.StatisticsDataByYear(salesRowDataList);
            parser.PrintStatisticalDataMap(statisticalDataMap);
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
    class StatisticalData
    {
        public double amountUsd;
        public uint quantity;
    }

    interface Readable
    {
        uint StringToUnsignedInt(string value);
        double StringToDouble(string value);
        DateTime ConvertToDateTime(string value);
        List<SalesRowData> SplitReadText(string text);
    }
    interface Calculatable
    {
        SortedDictionary<int, SortedDictionary<string, StatisticalData>> StatisticsDataByYear(List<SalesRowData> salesRowDataList);
        void PrintStatisticalDataMap(SortedDictionary<int, SortedDictionary<string, StatisticalData>> statisticalDataMap);
    }
    class SowrenderCSVParser : Readable, Calculatable
    {
        public uint StringToUnsignedInt(string value)
        {
            uint result;
            if (uint.TryParse(value, out result) && result >= 0)
                return result;
            else
            {
                Console.WriteLine("Unsignedint Error : Wrong Value : " + value);
                Environment.Exit(0);
                return 0;
            }
        }
        public double StringToDouble(string value)
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
        public DateTime ConvertToDateTime(string value)
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
        public List<SalesRowData> SplitReadText(string text)
        {
            List<SalesRowData> salesRowDataList = new List<SalesRowData>();

            string[] lines = text.Split('\n');

            for(int i = 1; i < lines.Length; i++)
            {
                string[] chucks = lines[i].Split(',');


                if (chucks.Length > 19)
                {
                    chucks[5] = chucks[5] + "," + chucks[6];
                    for (int j = 6; j < chucks.Length - 1; j++)
                    {
                        chucks[j] = chucks[j + 1];
                    }
                    chucks[chucks.Length - 1] = null;
                    chucks[5] = chucks[5].Substring(1, chucks[5].Length - 2);
                }

                SalesRowData salesRowData = new SalesRowData();

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
            }
            return salesRowDataList;
        }
        public SortedDictionary<int, SortedDictionary<string, StatisticalData>> StatisticsDataByYear(List<SalesRowData> salesRowDataList)
        {
            var statisticalDataMap = new SortedDictionary<int, SortedDictionary<string, StatisticalData>>();

            for (int i = 0; i < salesRowDataList.Count; i++)
            {
                SalesRowData rowData = salesRowDataList[i];
                if (!statisticalDataMap.ContainsKey(rowData.dateShipped.Year))
                {
                    var data = new SortedDictionary<string, StatisticalData>();
                    statisticalDataMap.Add(rowData.dateShipped.Year, data);
                }
            }
            foreach (var year in statisticalDataMap)
            {
                for (int i = 0; i < salesRowDataList.Count; i++)
                {
                    SalesRowData rowData = salesRowDataList[i];
                    if (rowData.dateShipped.Year == year.Key)
                    {
                        if (!year.Value.ContainsKey(rowData.model))
                        {
                            StatisticalData valueData = new StatisticalData();
                            year.Value.Add(rowData.model, valueData);
                        }
                        year.Value[rowData.model].amountUsd += rowData.amountUsd;
                        year.Value[rowData.model].quantity += rowData.quantity;
                    }
                }
            }

            return statisticalDataMap;
        }
        public void PrintStatisticalDataMap(SortedDictionary<int, SortedDictionary<string, StatisticalData>> statisticalDataMap)
        {
            string etcHandler = "";
            foreach (var year in statisticalDataMap)
            {
                Console.WriteLine(year.Key);
                foreach (var data in year.Value)
                {
                    if(data.Key == "Etc")
                        etcHandler = data.Key + " : " + data.Value.quantity + " / " + AddCommas(data.Value.amountUsd) + " => " + AddCommas(data.Value.amountUsd / data.Value.quantity);
                    else
                        Console.WriteLine(data.Key + " : " + data.Value.quantity + " / " + AddCommas(data.Value.amountUsd) + " => " + AddCommas(data.Value.amountUsd/data.Value.quantity));
                }
                Console.WriteLine(etcHandler);
                Console.WriteLine("\n-----------------\n");
            }
        }
        public string AddCommas(double number)
        {
            string rawNumber = number.ToString();
            string[] splitedByDot = rawNumber.Split('.');
            string result = splitedByDot[0];
            int commaPlace = splitedByDot[0].Length % 3;

            for (int i = 0; i < splitedByDot[0].Length / 3; i++)
            {
                if(commaPlace != 0)
                {
                    result = result.Insert(commaPlace, ",");
                    commaPlace++;
                }
                commaPlace += 3;
            }
            if(splitedByDot.Length != 1)
                result = result.Insert(result.Length, "." + splitedByDot[1]);

            return result;
        }
    }
}
