using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input a number you would like to test for primality: ");
            int number = Convert.ToInt32(Console.ReadLine()); //convert user input (string) to int
            bool isPrime = true;

            if (number == 0 || number == 1)
            {
                isPrime = false;
            }

            for (int i = 2; i < Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    isPrime = false;
                    break;
                }

                else
                    isPrime = true;
         
            }

            if (isPrime == true)
            {
                Console.WriteLine("The number is a prime number.");
                Console.Read();
            }

            else
            {
                Console.WriteLine("The  number is not a prime number.");
                Console.Read();
            }


        }
    }

 
}
