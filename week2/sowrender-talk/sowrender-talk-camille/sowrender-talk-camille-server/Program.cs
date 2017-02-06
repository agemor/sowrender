using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.Net;

namespace sowrender_talk_camille_server
{
    class Program
    {
        private static List<TcpClient> clientList = new List<TcpClient>();
        static void Main(string[] args)
        {
            TcpListener serverSocket = new TcpListener(IPAddress.Parse("192.168.0.24"), 10001);
            serverSocket.Start();

            while (true)
            {
                TcpClient client = serverSocket.AcceptTcpClient();

                NetworkStream stream = client.GetStream();

                clientList.Add(client);

                byte[] enmes = Encoding.UTF8.GetBytes("welcome\n");
                stream.Write(enmes, 0, enmes.Length);
                stream.Flush();

                Thread watcherThread = new Thread(() => WatchClient(client));
                watcherThread.Start();

                Broadcast("\nnew user joined [" + client.Client.RemoteEndPoint.ToString() + "]");
            }
        }

        private static void Broadcast(string message)
        {
            foreach (TcpClient client in clientList)
            {
                if (client.Connected)
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
                byte[] buffer = new byte[1024];
                try
                {
                    NetworkStream stream = client.GetStream();

                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string data = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    Console.WriteLine(data);
                    Broadcast(data);
                }
                catch
                {
                    break;
                }
            }
        }
    }
}
