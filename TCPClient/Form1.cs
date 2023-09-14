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
using System.Net;

namespace TCPClient
{
    public partial class Form1 : Form
    {
        private SimpleTcpClient client;

        public Form1()
        {
            InitializeComponent();

            //Stabil çalışır halde
            client = new SimpleTcpClient("10.67.49.50", 9000);
        }


        IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());

        //SimpleTcpClient client = new SimpleTcpClient("10.67.49.50", 7777);


        public string username;
        public List<ClientInfo> connectedClientIPs = new List<ClientInfo>();


        public class ClientInfo   // İstemciye özgü diğer bilgiler
        {
            public string IpPort { get; set; }
            public bool IsConnected { get; set; }

        }

        private bool isMessageFromMe = false; // Kendi mesajınızı gönderip göndermediğinizi takip etmek için 

        private void BtnSend_Click(object sender, EventArgs e)
        {
            if (client.IsConnected)
            {
                if (!string.IsNullOrEmpty(TxtMessage.Text))
                {
                    // Kendi mesajınızı gönderiyorsanız, göndermeyin
                    if (!isMessageFromMe)
                    {
                        client.Send(TxtMessage.Text);
                    }

                    // Chat penceresine mesajı ekleyin
                    TxtInfo.Text += $"Me: {TxtMessage.Text} {Environment.NewLine}";
                    TxtMessage.Text = string.Empty;

                    // Kendi mesajınızı gönderdiğinizi sıfırlayın
                    isMessageFromMe = false;
                }
            }
        }

        public string clientIP = "";
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


        private void Form1_Load(object sender, EventArgs e)
        {
            TxtIP.Text = client.ServerIpPort;
            client.Events.Connected += Events_Connected;
            client.Events.Disconnected += Events_Disconnected;
            client.Events.DataReceived += Events_DataReceived;
            BtnSend.Enabled = false;
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

                // Yeni bir istemci bağlandığında ClientInfo nesnesini oluşur ve bağlantı bilgilerini kaydeder.
                var clientInfo = new ClientInfo
                {
                    IpPort = e.IpPort,
                    IsConnected = true // İstemci bağlandığında true olur
                };
                connectedClientIPs.Add(clientInfo);

                // Client listesini güncelleyin
                UpdateClientList();
            });
        }
        private void UpdateConnectedClientsList(string connectedClientsList)
        {
            string[] connectedClients = connectedClientsList.Split(',');

            // Listeyi temizle
            connectedClientIPs.Clear();

            foreach (var connectedClient in connectedClients)
            {
                if (!string.IsNullOrEmpty(connectedClient))
                {
                    connectedClientIPs.Add(new ClientInfo { IpPort = connectedClient });
                }
            }

        }


        private void Events_Disconnected(object? sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                TxtInfo.Text += $"Server disconnected. {Environment.NewLine}";

                // Bağlantı kesilen istemciyi listeden kaldırın
                var disconnectedClient = connectedClientIPs.FirstOrDefault(client => client.IpPort == e.IpPort);
                if (disconnectedClient != null)
                {
                    disconnectedClient.IsConnected = false;
                    // Client listesini güncelleyin
                    UpdateClientList();
                }
            });
        }

        private void UpdateClientList()
        {
            // ListBox gibi bir kontrolü temizleyin
            LstCllientIP.Items.Clear();

            // Bağlı olan tüm istemcileri listeye ekleyin
            foreach (var clientInfo in connectedClientIPs)
            {
                LstCllientIP.Items.Add(clientInfo.IpPort + (clientInfo.IsConnected ? " (Connected)" : " (Disconnected)"));
            }
        }


    }
}
