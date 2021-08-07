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
        List<TcpClient> mClients;
        public EventHandler<ClientConnectedEventArgs> RaiseClientConnectedEvent;
        public EventHandler<TextReceivedEventArgs> RaiseTextReceivedEvent;
        public bool KeepRunning { get; set; }

        public SocketServer()
        {
            mClients = new List<TcpClient>();
        }

        protected virtual void OnRaiseClientConnectedEvent(ClientConnectedEventArgs e)
        {
            EventHandler<ClientConnectedEventArgs> handler = RaiseClientConnectedEvent;
            if(handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnRaiseTextReceivedEvent(TextReceivedEventArgs trea)
        {
            EventHandler<TextReceivedEventArgs> handler = RaiseTextReceivedEvent;
            if (handler != null)
            {
                handler(this, trea);
            }
        }
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
                        RemoveClient(parentClient);
                        Debug.WriteLine("Socket disconnected!");
                        break;
                    }
                    string receivedText = new string(buff);
                    Debug.WriteLine("***Received: " + receivedText);
                    OnRaiseTextReceivedEvent(new TextReceivedEventArgs(
                        parentClient.Client.RemoteEndPoint.ToString(),receivedText
                        ));
                    Array.Clear(buff, 0, buff.Length);
                }
            }
            catch (Exception exc)
            {
                RemoveClient(parentClient);
                System.Diagnostics.Debug.WriteLine(exc.ToString());
            }
        }

        public void StopServer()
        {
            try
            {
                if(mTCPListener != null)
                {
                    mTCPListener.Stop();
                }
                foreach(TcpClient c in mClients)
                {
                    c.Close();
                }

                mClients.Clear();
                
            }
            catch (Exception exc)
            {

                Debug.WriteLine(exc.ToString());
            }
        }

        private void RemoveClient(TcpClient parentClient)
        {
            if (mClients.Contains(parentClient))
            {
                mClients.Remove(parentClient);
                Debug.WriteLine(String.Format("Client removed,count: {0}", mClients.Count));
            }
        }

        public async void SendToAll(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return;
            }
            try
            {
                byte[] buffer = Encoding.ASCII.GetBytes(message);
                foreach(TcpClient t in mClients)
                {
                    t.GetStream().WriteAsync(buffer, 0, buffer.Length);
                }
            }
            catch(Exception exc)
            {
                Debug.WriteLine(exc.ToString());
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
                    mClients.Add(returnedByAccept);
                    Debug.WriteLine(string.Format("Client connected successfully.Count: {0} - {1} "
                        ,mClients.Count, returnedByAccept.Client.RemoteEndPoint));
                    TakeCareOfTCPClient(returnedByAccept);
                    ClientConnectedEventArgs eaClientConnected;
                    eaClientConnected = new ClientConnectedEventArgs(returnedByAccept.Client.RemoteEndPoint.ToString());
                    OnRaiseClientConnectedEvent(eaClientConnected);
                }
                
            }
            catch(Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.ToString());
            }
        }
    }
}
