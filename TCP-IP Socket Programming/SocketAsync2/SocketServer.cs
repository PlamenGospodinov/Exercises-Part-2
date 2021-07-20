using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketAsync2
{
    public class SocketServer
    {
        IPAddress mIP;
        int mPort;
        TcpListener mTCPListener;

        public async void StartListeningForIncomingCOnnection(IPAddress ipadrr = null, int port = 23000)
        {
            if (ipadrr == null)
            {
                ipadrr = IPAddress.Any;
            }

            if (port < 0)
            {
                port = 23000;
            }

            mIP = ipadrr;
            mPort = port;

            System.Diagnostics.Debug.WriteLine(string.Format("IP Adress - {0}, Port number - {1}", mIP.ToString(), mPort));

            mTCPListener = new TcpListener(mIP, mPort);
            mTCPListener.Start();
            var returnedByAccept = await mTCPListener.AcceptTcpClientAsync();
            System.Diagnostics.Debug.WriteLine("Client connected successfully: " + returnedByAccept.ToString());
        }
    }
}
