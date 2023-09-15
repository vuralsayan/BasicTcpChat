using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperSimpleTcp;

namespace TCPServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            server.Events.ClientConnected += Events_ClientConnected;
            server.Events.ClientDisconnected += Events_ClientDisconnected;
            server.Events.DataReceived += Events_DataReceived;
        }

        private SimpleTcpServer server = new SimpleTcpServer("10.67.49.50", 9000);
        private List<string> connectedClients = new List<string>();


        private void Form1_Load(object sender, EventArgs e)
        {
            TxtIP.Text = server.IpAddress.ToString();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            server.Start();
            TxtInfo.Text += $"Server started... {Environment.NewLine}";
            BtnStart.Enabled = false;
            BtnSend.Enabled = true;
            ScrollToBottom(TxtInfo);
            TxtMessage.Focus();
        }

        private void Events_ClientConnected(object sender, ConnectionEventArgs e)
        {
            InvokeUI(() =>
            {
                TxtInfo.Text += $"{e.IpPort} connected. {Environment.NewLine}";
                connectedClients.Add(e.IpPort);
                UpdateClientList();
                SendConnectedClientsList();
                ScrollToBottom(TxtInfo);
                TxtMessage.Focus();
            });
        }


        private void Events_ClientDisconnected(object sender, ConnectionEventArgs e)
        {
            InvokeUI(() =>
            {
                TxtInfo.Text += $"{e.IpPort} disconnected. {Environment.NewLine}";
                connectedClients.Remove(e.IpPort);
                UpdateClientList();
                SendConnectedClientsList();
                ScrollToBottom(TxtInfo);
                TxtMessage.Focus();
            });
        }


        private void Events_DataReceived(object sender, DataReceivedEventArgs e)
        {
            InvokeUI(() =>
            {
                string message = $"{e.IpPort}: {Encoding.UTF8.GetString(e.Data)}";
                TxtInfo.Text += message + Environment.NewLine;
                SendToAllClients(message, e.IpPort);
                ScrollToBottom(TxtInfo);
                TxtMessage.Focus();
            });
        }


        private void SendToAllClients(string message, string senderIp)
        {
            foreach (var clientIp in connectedClients)
            {
                if (clientIp != senderIp)
                {
                    server.Send(clientIp, message);
                }

            }
        }

        private void SendConnectedClientsList()
        {
            string clientListMessage = $"ConnectedClients:{string.Join(",", connectedClients)}";
            foreach (var clientIp in connectedClients)
            {
                server.Send(clientIp, clientListMessage);
            }
        }

        private void UpdateClientList()
        {
            LstClientIP.DataSource = null;
            LstClientIP.DataSource = connectedClients;
        }


        private void BtnSend_Click(object sender, EventArgs e)
        {
            if (server.IsListening)
            {
                if (!string.IsNullOrEmpty(TxtMessage.Text))
                {
                    SendToAllClients($"Server: {TxtMessage.Text} {Environment.NewLine}", "");
                    // Sunucu chat penceresine de gönderilen mesajı yaz
                    TxtInfo.Text += $"Server: {TxtMessage.Text} {Environment.NewLine}";
                    TxtMessage.Clear();
                }
            }

            ScrollToBottom(TxtInfo);
            TxtMessage.Focus();
        }

        private void InvokeUI(Action action)
        {
            if (InvokeRequired)
            {
                Invoke(action);
            }
            else
            {
                action();
            }
        }


        private string selectedIP = null;

        private void LstClientIP_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIP = LstClientIP.SelectedItem as string;
        }


        private void ScrollToBottom(TextBox textBox)
        {
            textBox.Select(textBox.TextLength, 0);
            textBox.ScrollToCaret();
        }



    }
}
