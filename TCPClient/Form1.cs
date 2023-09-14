﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperSimpleTcp;
using System.Net;

namespace TCPClient
{
    public partial class Form1 : Form
    {
        private SimpleTcpClient client;


        private List<string> connectedClients = new List<string>();

        public Form1()
        {
            InitializeComponent();
            client = new SimpleTcpClient("10.67.49.50", 9000);
            client.Events.Connected += Events_Connected;
            client.Events.Disconnected += Events_Disconnected;
            client.Events.DataReceived += Events_DataReceived;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TxtIP.Text = client.ServerIpPort;
            UpdateClientList();
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            if (client.IsConnected)
            {
                if (!string.IsNullOrEmpty(TxtMessage.Text))
                {
                    client.Send(TxtMessage.Text);
                    TxtInfo.Text += $"Me: {TxtMessage.Text} {Environment.NewLine}";
                    TxtMessage.Text = string.Empty;
                }
            }
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                client.Connect();
                BtnSend.Enabled = true;
                BtnConnect.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Events_DataReceived(object? sender, DataReceivedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                string message = Encoding.UTF8.GetString(e.Data);

                if (message.StartsWith("ConnectedClients:"))
                {
                    // Sunucudan gelen bağlantı bilgilerini işle
                    string connectedClientsList = message.Replace("ConnectedClients:", "");
                    UpdateConnectedClientsList(connectedClientsList);
                    UpdateClientList();
                }
                else
                {
                    // Diğer mesajları işle
                    TxtInfo.Text += $"Server: {message} {Environment.NewLine}";
                }
            });
        }

        private void Events_Connected(object? sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                TxtInfo.Text += $"Server connected. {Environment.NewLine}";
            });
        }

        private void Events_Disconnected(object? sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                TxtInfo.Text += $"Server disconnected. {Environment.NewLine}";
            });
        }

        private void UpdateConnectedClientsList(string connectedClientsList)
        {
            // Serverdan gelen bağlantı bilgilerini işleyebilirsiniz, ancak şu anlık kullanmıyorsunuz gibi görünüyor.
        }

        private void UpdateClientList()
        {
            // ListBox gibi bir kontrolü temizleyin
            LstCllientIP.Items.Clear();

            // Bağlı olan tüm istemcileri listeye ekleyin
            foreach (var clientIp in connectedClients)
            {
                LstCllientIP.Items.Add(clientIp);
            }
        }








    }
}
