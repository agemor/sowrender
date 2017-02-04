using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace sowrender_talk_duke
{
    class Program
    {
        private static NetworkStream stream;
        private static object Lock = new object();
        static void Main(string[] args)
        {          
            TcpClient socket = new TcpClient();
            //IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("12.0.0.1"), 13333);

            Console.WriteLine("SorenderTalk v1.0");

            try
            {
                socket.Connect("192.168.0.12", 10001);
                //socket.Connect(endPoint);
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.ToString());
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

            stream = socket.GetStream();
            //StreamReader reader = new StreamReader(stream);

            Thread thread = new Thread(watchServer);
            thread.Start();
            //thread.Join();
            //thread.Interrupt();

            while (true)
            {
                string messege = Console.ReadLine();
                byte[] enmes = Encoding.UTF8.GetBytes(messege);
                //string original = Encoding.UTF8.GetString(encoded);
                stream.Write(enmes, 0, enmes.Length);
                stream.Flush();
            }         
        }

        private static void watchServer()
        {
            while (true)
            {
                byte[] buffer = new byte[2048];

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
