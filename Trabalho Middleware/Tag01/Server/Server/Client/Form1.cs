using SimpleTCP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Form1_Load();
        }

        SimpleTcpClient client;

        public void Form1_Load()
        {
            client = new SimpleTcpClient();
            client.StringEncoder = Encoding.UTF8;
            client.DataReceived += Client_DataReceived;
        }

        private void Client_DataReceived(object sender, SimpleTCP.Message e)
        {
            //Update message to txtStatus
            textBox3.Invoke((MethodInvoker)delegate ()
            {
                textBox3.Text += e.MessageString;
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            client.Connect(textBox1.Text, Convert.ToInt32(textBox2.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            client.Connect(textBox1.Text, Convert.ToInt32(textBox2.Text));
            client.WriteLineAndGetReply(textBox3.Text, TimeSpan.FromSeconds(3));
        }
    }
}
