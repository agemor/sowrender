using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AurenderTycoonCamille
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionData = "Server = localhost;Database=test;uid=camille'Pwd=9210wonwjd;";
            
            MySqlCommand cmd = new MySqlCommand(connectionData);
            string purchaseOrder;
            while (true)
            {
                /*이름, 구매하고 싶은 기기, 수량, 배송지, 연락처*/
                Console.WriteLine("\"이름, 구매할 기기, 색상, 용량, 수량, 배송지, 연락처\"를 입력하세요");
                Console.WriteLine("ex) camille, N100H, Silver, 2TB, 5, SowrenderOffce, 01011112222");
                purchaseOrder = Console.ReadLine();

                GetKeyword(purchaseOrder);
            }
        }

        /* get each keyword from order */
        static void GetKeyword(string order)
        {
            order = order.Replace(" ", "");
            string[] keyword = order.Split(',');

            ClientManager client = new ClientManager();
            client.ReadDB(keyword[0]);
            if (keyword.Length != 7)
            {
                Console.WriteLine("보기의 형식을 따라 다시 입력하세요");
            }

            
        }
    }
}