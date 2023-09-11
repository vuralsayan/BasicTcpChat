using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

        SimpleTcpServer server = new SimpleTcpServer("0.0.0.0", 7777);
        Dictionary<string, SimpleTcpClient> connectedClients = new Dictionary<string, SimpleTcpClient>();
        public string username;

        private void BtnStart_Click(object sender, EventArgs e)
        {
            server.Start();
            TxtInfo.Text += $"Starting... {Environment.NewLine}";
            BtnStart.Enabled = false;
            BtnSend.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BtnSend.Enabled = false;
            TxtIP.Text = server.IpAddress.ToString();
            server.Events.ClientConnected += Events_ClientConnected;
            server.Events.ClientDisconnected += Events_ClientDisconnected;
            server.Events.DataReceived += Events_DataReceived;
        }

        private void Events_DataReceived(object? sender, DataReceivedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                TxtInfo.Text += $"{e.IpPort}: {Encoding.UTF8.GetString(e.Data)} {Environment.NewLine}";
            });

            foreach (var client in connectedClients)
            {
                server.Send(client.Key, $"{e.IpPort}: {Encoding.UTF8.GetString(e.Data)}");
            }

        }

        private void Events_ClientDisconnected(object? sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                TxtInfo.Text += $"{e.IpPort} disconnected. {Environment.NewLine}";
                LstClientIP.Items.Remove(e.IpPort);

            });
        }

        private void Events_ClientConnected(object? sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                TxtInfo.Text += $"{e.IpPort} connected. {Environment.NewLine}";
                LstClientIP.Items.Add(e.IpPort);

                // Sunucu tarafında istemci bağlantısını takip etmek için
                // 'sender' bir 'SimpleTcpServer' nesnesi yerine 'SimpleTcpClient' olmalı
                if (sender is SimpleTcpClient client)
                {
                    connectedClients[e.IpPort] = client;
                }
            });
        }


        private string selectedIP = null; // ListBox'ta seçili olan IP adresini tutacak değişken

        private void LstClientIP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LstClientIP.SelectedItem != null)
            {
                string currentSelectedIP = LstClientIP.SelectedItem.ToString();

                if (currentSelectedIP == selectedIP)
                {
                    // Seçili IP'yi tekrar tıkladığınızda seçimi kaldır
                    LstClientIP.ClearSelected();
                    selectedIP = null;
                }
                else
                {
                    selectedIP = currentSelectedIP;
                }
            }
        }


        private void BtnSend_Click(object sender, EventArgs e)
        {
            if (server.IsListening)
            {
                if (!String.IsNullOrEmpty(TxtMessage.Text))
                {
                    if (selectedIP == null)
                    {
                        // Tüm clientlere mesaj gönder
                        foreach (var item in LstClientIP.Items)
                        {
                            server.Send(item.ToString(), TxtMessage.Text);
                        }
                        TxtInfo.Text += $"Server (to all clients): {TxtMessage.Text} {Environment.NewLine}";
                        TxtMessage.Text = String.Empty;
                    }
                    else
                    {
                        // Sadece seçili olan IP adresine mesaj gönder
                        server.Send(selectedIP, TxtMessage.Text);
                        TxtInfo.Text += $"Server (to {selectedIP}): {TxtMessage.Text} {Environment.NewLine}";
                        TxtMessage.Text = String.Empty;
                    }
                }
            }
        }



    }
}
