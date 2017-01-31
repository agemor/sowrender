using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace AurenderTycoonDuke
{
    class Program : ChangeAble
    {
        static void Main(string[] args)
        {
           
        }
        private void PrepareAurenderProduct()
        {

        }
        private void StartTycoonRoutine()
        {
            ChangeAble changeAble = new Program();

            int clientCount = changeAble.StringToInt(Console.ReadLine());
            if(clientCount > 0)
            {
                SalesManager salesManager = new SalesManager();
                
                for (int i = 0; i < clientCount; i++)
                {
                    salesManager.AddInovoice(Console.ReadLine());
                }
            }
        }
        int ChangeAble.StringToInt(string value)
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
