using System;
using System.Net;
using System.Net.Sockets;

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
            listenerSocket.Accept();
        }
    }
}
