using System;
using System.Windows.Forms;
using SocketAsync2;

namespace AsyncSocketServer
{
    public partial class Form1 : Form
    {
        SocketServer server;
        public Form1()
        {
            InitializeComponent();
            server = new SocketServer();
            server.RaiseClientConnectedEvent += HandleClientConnected;
            server.RaiseTextReceivedEvent += HandleTextReceived;
        }

        private void AcceptConnection_Click(object sender, EventArgs e)
        {
            server.StartListeningForIncomingCOnnection();
        }

        private void sendAllBtn_Click(object sender, EventArgs e)
        {
            server.SendToAll(msgBox.Text.Trim());
        }

        private void btnStopServer_Click(object sender, EventArgs e)
        {
            server.StopServer();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.StopServer();
        }

        void HandleClientConnected(object sender,ClientConnectedEventArgs ccea)
        {
            txtConsole.AppendText(string.Format("{0} - New client connected {1}{2}", DateTime.Now, ccea.NewClient, Environment.NewLine));
        }

        void HandleTextReceived(object sender,TextReceivedEventArgs trea)
        {
            txtConsole.AppendText(string.Format("{0} - Text received: {1}{2}", DateTime.Now, trea.TextReceived, Environment.NewLine,trea.ClientWhoSentText));
        }
    }
}
