using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EricaServer
{
    class Program
    {
        static List<TcpClient> clientList;
        static void Main(string[] args)
        {
            TcpListener serverSocket = new TcpListener(IPAddress.Parse("192.168.0.12"), 10001);

            serverSocket.Start();

            clientList = new List<TcpClient>();

            while (true)
            {
                TcpClient client = serverSocket.AcceptTcpClient();
                clientList.Add(client);

                NetworkStream stream = client.GetStream();
                byte[] data = Encoding.UTF8.GetBytes("Hello~ Client~~~!! Nice Meet you");
                stream.Write(data, 0, data.Length);
                stream.Flush();

                Thread watcherThread = new Thread(() => Watch(client));
                watcherThread.Start();

                Broadcast("New user joined! [" + client.Client.RemoteEndPoint.ToString() + "]");

            }

        }

        private static void Broadcast(string msg , TcpClient sender)
        {
            foreach (TcpClient client in clientList)
            {
                if (client.Connected && client!=sender)
                {
                    NetworkStream stream = client.GetStream();
                    msg ="[ "+ sender.Client.RemoteEndPoint.ToString()+" ] : " + msg;
                    byte[] emes = Encoding.UTF8.GetBytes(msg);
                    stream.Write(emes, 0, emes.Length);
                    stream.Flush();
                }
            }
        }

        private static void Broadcast(string msg)
        {
            foreach (TcpClient client in clientList)
            {
                if (client.Connected )
                {
                    NetworkStream stream = client.GetStream();
                    byte[] emes = Encoding.UTF8.GetBytes(msg);
                    stream.Write(emes, 0, emes.Length);
                    stream.Flush();
                }
            }
        }

        /* 클라이언트 데이터 감시 */
        public static void Watch(TcpClient client)
        {
            while (true)
            {
                byte[] buffer = new byte[2048];
                lock (client)
                {
                    NetworkStream stream = client.GetStream();
                    int byteRead = stream.Read(buffer, 0, buffer.Length);
                    string data = Encoding.UTF8.GetString(buffer, 0, byteRead);
                    
                    //Console.WriteLine(data);

                    Broadcast(data,client);


                }
            }

        }
    }
}
