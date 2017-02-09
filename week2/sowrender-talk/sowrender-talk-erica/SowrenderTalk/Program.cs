using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace SowrenderTalk
{
    class Program
    {
        private static NetworkStream stream;
        private static object Lock = new object();

        static void Main(string[] args)
        {
            Console.WriteLine("SowrenderTalk v1.0");

            TcpClient socket = new TcpClient();

            try
            {
                socket.Connect("192.168.0.12", 10001);
            }
            catch (Exception e)
            {

            }

            if (socket.Connected)
            {
                Console.WriteLine("success");
            }
            else
            {
                Console.WriteLine("fail");
                return;
            }

            //--------------------------------------------------
            stream = socket.GetStream();

            //StreamReader reader = new StreamReader(stream);

            byte[] buffer = new byte[5524];

            string data = Encoding.UTF8.GetString(buffer, 0, buffer.Length);

            //Encoding.UTF8.GetString(b);

            Thread thread = new Thread(Watch);
            thread.Start();

            while (true)
            {
                string message = Console.ReadLine();
                byte[] emes = Encoding.UTF8.GetBytes(message);
                stream.Write(emes, 0, emes.Length);
                stream.Flush();
            }
        }

        public static void Watch()
        {
            while (true)
            {
                byte[] buffer = new byte[2048];
                lock (Lock)
                {
                    int byteRead = stream.Read(buffer, 0, buffer.Length);
                    string data = Encoding.UTF8.GetString(buffer, 0, byteRead);
                    Console.WriteLine(data);
                }
            }
        }
    }
}
