using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;

namespace SowrenderTalkServer
{
    class Program
    {
        private static List<TcpClient> clientList = new List<TcpClient>();
        static void Main(string[] args)
        {
            TcpListener serverSocket = new TcpListener(IPAddress.Parse("127.0.0.1"),10000);
            serverSocket.Start();

            int clientNum = 0;
            while (true)
            {
                TcpClient client = serverSocket.AcceptTcpClient();
                
                byte[] msg = Encoding.UTF8.GetBytes("Welcome Client\n");

                NetworkStream stream = client.GetStream();
                clientList.Add(client);

                stream.Write(msg, 0, msg.Length);

                StreamWriter writer = new StreamWriter(stream, Encoding.UTF8);
                writer.Flush();

                Thread watcherThread = new Thread(() => WatchClient(client));
                watcherThread.Start();

                Broadcast("New user joined : [" + client.Client.RemoteEndPoint.ToString() + "]\n");
                clientNum++;

                //Console.Clear();
                //Console.WriteLine(clientNum + "명 접속 중..");
                
            }
            
        }

        private static void Broadcast(string message)
        {
            foreach(TcpClient client in clientList)
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
                byte[] buffer = new byte[2048];

                /*lock (client)
                {*/
                    NetworkStream stream = client.GetStream();

                    int byteRead = stream.Read(buffer, 0, buffer.Length);
                    string data = Encoding.UTF8.GetString(buffer, 0, byteRead);

                    Console.WriteLine(client.Client.RemoteEndPoint.ToString() + " - " + data);
                    Broadcast(data);
                }
            }
        }
    }
}
