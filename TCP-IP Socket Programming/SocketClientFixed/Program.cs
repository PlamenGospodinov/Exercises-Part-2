using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketClientStarter
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket client = null;
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ipaddr = IPAddress.Any;

            try
            {
                Console.WriteLine("Welcome to Socket Client Starter Example");
                Console.WriteLine("Enter a valid IP Address and press Enter:");
                string strIPAdress = Console.ReadLine();
                Console.WriteLine("Enter a port number(0-65535) and press Enter:");
                string strPort = Console.ReadLine();
                int nPortNumber = 0;
                if(!IPAddress.TryParse(strIPAdress, out ipaddr))
                {
                    Console.WriteLine("Invalid IP Address!");
                    return;
                }
                if(!int.TryParse(strPort.Trim(),out nPortNumber))
                {
                    Console.WriteLine("Invalid port number!");
                    return;
                }
                if(nPortNumber <= 0 || nPortNumber > 65535)
                {
                    Console.WriteLine("Enter a port number between 0 and 65535!");
                    return;
                }
                Console.WriteLine(string.Format("IP Address - {0}, Port number - {1}", ipaddr.ToString(),nPortNumber));
                client.Connect(ipaddr, nPortNumber);

                Console.WriteLine("Connected to the server.Type something and press Enter to send it to the server.Type EXIT to close.");
                string input = string.Empty;
                while (true)
                {
                    input = Console.ReadLine();
                    if (input.Equals("EXIT"))
                    {
                        break;
                    }
                    byte[] buffer = Encoding.ASCII.GetBytes(input);
                    client.Send(buffer);
                    byte[] bufferReceived = new byte[128];
                    int nReceived = client.Receive(bufferReceived);
                    Console.WriteLine("Data received: {0}", Encoding.ASCII.GetString(bufferReceived, 0, nReceived));
                }
            }
            catch ( Exception exc)
            {

                Console.WriteLine(exc.ToString());
            }
            finally
            {
                if(client != null)
                {
                    if (client.Connected)
                    {
                        client.Shutdown(SocketShutdown.Both);
                    }
                    
                    client.Close();
                    client.Dispose();
                }
                
            }

            Console.WriteLine("Press a key to exit...");
            Console.ReadKey();
        }
    }
}
