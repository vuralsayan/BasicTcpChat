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

        //Stabil çalışır halde
        SimpleTcpServer server = new SimpleTcpServer("10.67.49.50", 9000);

        private List<string> connectedClients = new List<string>();
        public string username;

        public class ClientInfo  // Diğer istemci bilgileri buraya eklenebilir
        {
            public string IpPort { get; set; }
        }

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
                // Serverdan gelen mesajı chat penceresine ekleyin
                string message = $"{e.IpPort}: {Encoding.UTF8.GetString(e.Data)} {Environment.NewLine}";

                // Kendi mesajınızı gönderdiyseniz, göndermeyin
                if (!IsMessageFromMe(message))
                {
                    TxtInfo.Text += message;

                    // Serverdan gelen mesajı tüm clientlere gönderin
                    foreach (var clientIp in connectedClients)
                    {
                        // İlgili client'ın bağlı olduğunu doğrulayın
                        if (clientIp != e.IpPort)
                        {
                            server.Send(clientIp, message);
                        }
                    }
                }
            });
        }




        private bool IsMessageFromMe(string message)
        {
            // Mesajın "Me:" ile başlayıp başlamadığını kontrol ederek, kendi mesajınızı tespit edin
            return message.StartsWith("Me:");
        }


        private void Events_ClientDisconnected(object? sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                TxtInfo.Text += $"{e.IpPort} disconnected. {Environment.NewLine}";

                // Bağlantı kesilen istemciyi listeden kaldırın
                if (connectedClients.Contains(e.IpPort))
                {
                    connectedClients.Remove(e.IpPort);

                    // Client listesini güncelleyin
                    UpdateClientList();

                    // Güncellenmiş bağlı istemci listesini tüm istemcilere gönderin
                    foreach (var client in connectedClients)
                    {
                        server.Send(client, $"ConnectedClients:{string.Join(",", connectedClients)}");
                    }
                }
            });
        }



        private void Events_ClientConnected(object? sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                TxtInfo.Text += $"{e.IpPort} connected. {Environment.NewLine}";

                // Yeni bir istemci bağlandığında ClientInfo nesnesini oluşturun ve bağlantı bilgilerini kaydedin.
                connectedClients.Add(e.IpPort);

                // Client listesini güncelleyin
                UpdateClientList();

                // Güncellenmiş bağlı istemci listesini tüm istemcilere gönderin
                server.Send(e.IpPort, $"ConnectedClients:{string.Join(",", connectedClients)}");

            });
        }

        private void UpdateClientList()
        {
            // ListBox gibi bir kontrolü temizleyin
            LstClientIP.Items.Clear();

            // Bağlı olan tüm istemcilerin IP'lerini listeye ekleyin
            foreach (var clientIp in connectedClients)
            {
                LstClientIP.Items.Add(clientIp);
            }
        }


        private void UpdateConnectedClientsList(string connectedClientsList)
        {
            string[] clients = connectedClientsList.Split(',');

            // Bağlı istemci IP listesini temizleyin ve yeni IP'leri ekleyin
            connectedClients.Clear();
            connectedClients.AddRange(clients);

            // Bağlı istemci IP listesini güncelleyin
            UpdateClientList();
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
