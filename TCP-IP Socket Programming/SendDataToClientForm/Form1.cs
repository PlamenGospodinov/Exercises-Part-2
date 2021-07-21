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
        }

        private void AcceptConnection_Click(object sender, EventArgs e)
        {
            server.StartListeningForIncomingCOnnection();
        }

        private void sendAllBtn_Click(object sender, EventArgs e)
        {
            server.SendToAll(msgBox.Text.Trim());
        }
    }
}
