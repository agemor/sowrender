using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;

namespace AurenderTycoonDuke
{
    class Program : Changeable
    {
        static void Main(string[] args)
        {
            PrepareAurenderProduct();
            StartTycoonRoutine();
            Statisics();
            // A|N10(Black,4TB)|2|B|C
        }
        static void PrepareAurenderProduct()
        {
            ProductManager productManager = ProductManager.GetInstance();
            productManager.MakeProductList();
            
        }
        static void StartTycoonRoutine()
        {
            Changeable changeable = new Program();
            SalesManager salesManager = new SalesManager();

            string text = File.ReadAllText("output_4.txt");
            string[] data = text.Split('\n');
            int clientCount = changeable.StringToInt(data[0]);
            for(int i = 0; i < clientCount; i++)
            {
                Console.Write("{0} : ", i + 1);
                salesManager.ConductInvoice(data[i+1]);
            }
            
            Console.ReadLine();
          
        }
        static void Statisics()
        {
            Changeable changeable = new Program();
            SalesStatisticsGenerator salesStatisticsGenerator = SalesStatisticsGenerator.GetInstance();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1.View Statistics By Sales      2.View Sales Volume");
                Console.WriteLine("3.View Sales Volume By Product  4.Exit");
                int answer = changeable.StringToInt(Console.ReadLine());
                switch (answer)
                {
                    case 1:
                        salesStatisticsGenerator.ViewReceiptBySale();
                        Console.ReadLine();
                        break;

                }
            }
        }
        int Changeable.StringToInt(string value)
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
}
