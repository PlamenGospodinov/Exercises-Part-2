using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocketAsync2;

namespace AsyncSocketClient2
{
    class Program
    {
        static void Main(string[] args)
        {
            SocketClient client = new SocketClient();
            Console.WriteLine("***Welcome!***");
            Console.WriteLine("Provide a valid IP address and press enter:");

            string strIPAddress = Console.ReadLine();

            Console.WriteLine("Provide a valid port number(0-65535) and press enter:");
            string strPortNumber = Console.ReadLine();

            
            

            if(client.SetServerIPAddress(strIPAddress) == false || client.SetPortNumber(strPortNumber) == false)
            {
                Console.WriteLine(string.Format("Invalid IP Address or Port Number! - {0} - {1} - Press a key to exit.",strIPAddress,strPortNumber));
                Console.ReadKey();
                return;
            }

            client.ConnectToServer();

            string strInputUser = null;
            do
            {
                strInputUser = Console.ReadLine();
                if(strInputUser.Trim() != "<EXIT>")
                {
                    client.SendToServer(strInputUser);
                }
                else
                {
                    client.CloseAndDisconnect();
                }
                
            } while (strInputUser != "<EXIT>");

        }
    }
}
