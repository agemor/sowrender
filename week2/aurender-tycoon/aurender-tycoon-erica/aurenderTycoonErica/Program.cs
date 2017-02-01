using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Text.RegularExpressions;


namespace aurenderTycoonErica
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText(@"C:\Users\dsm2015\Desktop\소렌더\sowrender\week2\aurender-tycoon\aurender-tycoon-erica\input.csv", Encoding.UTF8);
            string[] DB_DATA = text.Split('\n');
            int[] STOCK = {0,13627 , 13627 , 13627 , 13628, 13627, 13627, 13627, 13627
            ,13626,13626,13626,13626};

            /* DB connect */
            DBManager mDBManager = DBManager.GetInstance();
            mDBManager.Connect("localhost", "sowrender", "erica", "1234");

            ProductManager productManager = ProductManager.GetInstance();
            CustomerManager customerManager = CustomerManager.GetInstance();
            SalesManager salesManager = SalesManager.GetInstance();
            ProductStatistics productStatistics = ProductStatistics.GetInstance();

            /* Read input number */
            string num = Console.ReadLine();
            int n = int.Parse(num);

            /* insert */
            for (int i = 1; i < DB_DATA.Length; i++)
            {
                string[] data = DB_DATA[i].Split(',');
                Product p = new Product(data[1], "", int.Parse(data[2]), STOCK[i], data[3], data[4]);

              //  mDBManager.Insert(p);
            }
            

            /* execute */
            for (int i = 0; i < n; i++)
            {
                string read = Console.ReadLine();

                string[] input = read.Split(new string[] { "), ", ", ", " (" }, StringSplitOptions.RemoveEmptyEntries);
                int stock;

                /* data filter */
                if(!int.TryParse(input[4], out stock))
                {
                    stock = 0;
                }

                /* 이름, 구매하고 싶은 기기(색깔, 용량), 수량, 배송지, 연락처) */
                Customer customer = new Customer(input[0], input[6], input[5]);
                Product product = new Product(input[1], input[2], input[3], stock);
                
                /* 구매 */
                if (product.Stock > 0)
                {
                    salesManager.Purchase(product, customer);
                }
                else/* 환불 */
                {
                    salesManager.Refund(product, customer);
                }
            }
            
            productStatistics.ExportRecieptAsCSV();
            Dictionary < String, Statistics> bindModel = productStatistics.Bind(salesManager.Reciept);
            PrintMap(bindModel);

            /* DB update */
         /*   for(int i=0; i< productManager.ProductInfo.Count; i++)
            {
                Product p = productManager.ProductInfo.ElementAt(i).Value;
                string where = "model_name='" + p.ModelName + "' " + "model_color='" + p.Color + "'" + "model_capacity='" + p.Capacity+"'";
                mDBManager.Update("sowrender_product", "stock=" + p.Stock,where);
            }*/

            mDBManager.close();
        }

        static public void PrintMap(Dictionary<string, Statistics> map, string explanation = "")
        {
            Console.WriteLine(explanation);
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("{0,25} {1,10}", "수량", "총 매출액");
            for (int i = 0; i < map.Count; i++)
            {
                Console.Write("{0,15}", map.ElementAt(i).Value.modelName+"("+ map.ElementAt(i).Value.color+", "+ map.ElementAt(i).Value.capacity + ") : ");
                Console.WriteLine("{0,5} \t    {1,-13:0,0} ", map.ElementAt(i).Value.amount,
                                  map.ElementAt(i).Value.sales);
            }
            Console.WriteLine("---------------------------------------------------");

            Console.WriteLine("Enter을 누르면 메뉴로 넘어갑니다.");

        }
    }
}
