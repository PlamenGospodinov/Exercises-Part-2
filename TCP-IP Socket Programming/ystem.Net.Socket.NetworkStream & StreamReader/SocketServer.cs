using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

        public bool KeepRunning { get; set; }
        private async void TakeCareOfTCPClient(TcpClient parentClient)
        {
            NetworkStream stream = null;
            StreamReader reader = null;

            try
            {
                stream = parentClient.GetStream();
                reader = new StreamReader(stream);

                char[] buff = new char[64];
                while (KeepRunning)
                {
                    Debug.WriteLine("***Ready to read");
                    int nRet = await reader.ReadAsync(buff, 0,buff.Length);
                    Debug.WriteLine("Returned: " + nRet);
                    if(nRet == 0)
                    {
                        Debug.WriteLine("Socket disconnected!");
                        break;
                    }
                    string receivedText = new string(buff);
                    Debug.WriteLine("***Received: " + receivedText);

                    Array.Clear(buff, 0, buff.Length);
                }
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.ToString());
            }
        }

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
            try
            {
                mTCPListener.Start();
                KeepRunning = true;
                while (KeepRunning)
                {
                    var returnedByAccept = await mTCPListener.AcceptTcpClientAsync();
                    System.Diagnostics.Debug.WriteLine("Client connected successfully: " + returnedByAccept.ToString());
                    TakeCareOfTCPClient(returnedByAccept);
                }
                
            }
            catch(Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.ToString());
            }
        }
    }
}
