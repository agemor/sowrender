using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace sowrender_talk_duke_server
{
    class Program
    {
        private static object Lock = new object();
        static List<TcpClient> clientsList = new List<TcpClient>();
        static void Main(string[] args)
        {
            TcpListener serverSocket = new TcpListener(IPAddress.Parse("192.168.0.21"), 10001);
            serverSocket.Start();

            while (true)
            {
                TcpClient client = serverSocket.AcceptTcpClient();
                NetworkStream stream = client.GetStream();

                clientsList.Add(client);

                byte[] enmes = Encoding.UTF8.GetBytes("Hello Stupid");
                stream.Write(enmes, 0, enmes.Length);
                stream.Flush();

                Thread watcherThread = new Thread(() => WatchClient(client));
                watcherThread.Start();

                Broadcast("New Stupid joined [" + client.Client.RemoteEndPoint.ToString() + "]",null);
            }

        }

        private static void Broadcast(string message,TcpClient sender)
        {
            foreach (TcpClient client in clientsList)
            {
                if (client.Equals(sender))
                    continue;
                else if (client.Connected)
                {
                    NetworkStream stream = client.GetStream();
                    byte[] enmes = Encoding.UTF8.GetBytes(message);
                    stream.Write(enmes, 0, enmes.Length);
                    stream.Flush();
                }
            }
        }

        private static void WatchClient(TcpClient client)
        {
            while (true)
            {
                byte[] buffer = new byte[2048];
                try
                {
                    NetworkStream stream = client.GetStream();

                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string data = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Console.WriteLine(data);
                    Broadcast(data,client);
                }
                catch
                {
                    break;
                }
            }   
        }
    }
}
