using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketServerStarter
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ipaddr = IPAddress.Any;
            IPEndPoint ipep = new IPEndPoint(ipaddr, 23000);
            listenerSocket.Bind(ipep);
            listenerSocket.Listen(5);
            Console.WriteLine("About to accept incoming connections.");
            Socket client = listenerSocket.Accept();
            Console.WriteLine("Client connected. " + client.ToString() + " - IP End Point: " + client.RemoteEndPoint.ToString());
            byte[] buff = new byte[128];
            int numberOfReceivedBytes = 0;

            while (true)
            {
                numberOfReceivedBytes = client.Receive(buff);
                Console.WriteLine("Number of received bytes: " + numberOfReceivedBytes);

                Console.WriteLine("Data sent by client is: " + buff);

                string text = Encoding.ASCII.GetString(buff, 0, numberOfReceivedBytes);

                Console.WriteLine("Data sent by client is: " + text);

                client.Send(buff);
                if(text == "x"){
                    break;
                }
                Array.Clear(buff,0,buff.Length);
                numberOfReceivedBytes = 0;
            }
            
        }
    }
}
