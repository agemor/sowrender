﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;

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
            mDBManager.Connect("localhost", "sowrender", "root", "");

            /* Read input number */
            string num = Console.ReadLine();
            int n = int.Parse(num);

            /* insert */
            for (int i = 1; i < DB_DATA.Length; i++)
            {
                string[] data = DB_DATA[i].Split(',');
                Product p = new Product(data[0], "", int.Parse(data[1]), STOCK[i], data[2], data[3]);

               // mDBManager.Insert(p);
            }

            ProductManager productManager = ProductManager.GetInstance();
            CustomerManager customerManager = CustomerManager.GetInstance();
            SalesManager salesManager = SalesManager.GetInstance();
            ProductStatistics productStatistics = ProductStatistics.GetInstance();

            /* execute */
            for (int i = 0; i < n; i++)
            {
                string read = Console.ReadLine();
                string[] input = read.Split('/');
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
                if(product.Stock>0)
                {
                    salesManager.Purchase(product, customer);
                }
                else/* 환불 */
                {
                    salesManager.Refund(product, customer);
                }
            }
            
            productStatistics.ExportRecieptAsCSV();
            mDBManager.close();
        }
    }
}
