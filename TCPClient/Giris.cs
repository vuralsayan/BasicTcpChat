using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCPClient
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        public string userName { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                userName = textBox1.Text;
                Client frm = new Client();
                //frm.username = userName;
                frm.Show();
            }
            else
            {
                MessageBox.Show("Lütfen bir kullanıcı adı giriniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
