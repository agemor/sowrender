using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;

namespace sowrender_talk_camille
{
    class Program
    {
        private static NetworkStream stream;
        private static object Lock = new object();
        static void Main(string[] args)
        {
            TcpClient socket = new TcpClient();
            //IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse("127..0.0.1"));
            Console.WriteLine("SowrenderTalk v1.0\n");
            try
            {
                socket.Connect("192.168.0.12", 10001);
            }
            catch (Exception e) { }
            if (socket.Connected)
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine("Failed");
                return;
            }

            stream = socket.GetStream();
            byte[] encoded = Encoding.UTF8.GetBytes("Camille");

            Thread thread = new Thread(watchServer);
            thread.Start(); //start

            while (true)
            {
                string message = Console.ReadLine();
                byte[] enmes = Encoding.UTF8.GetBytes(message);
                stream.Write(enmes, 0, enmes.Length);
            }
            thread.Join(); //end 
        }

        private static void watchServer()
        {
            while (true)
            {
                byte[] buffer = new byte[1024];
                lock (Lock)
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string data = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Console.WriteLine(data);
                }
            }
        }
    }
}
