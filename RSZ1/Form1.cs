using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSZ1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty || textBox2.Text == string.Empty || textBox3.Text == string.Empty)
            {
                throw new Exception("Not all data has been entered!");
            }
            else
            {

                UdpClient client = new UdpClient();

                string x = textBox1.Text;
                string y = textBox3.Text;
                string b = textBox2.Text;
                string a = textBox6.Text;
                double x_new = Convert.ToDouble(x, CultureInfo.InvariantCulture);
                double y_new = Convert.ToDouble(y, CultureInfo.InvariantCulture);
                double b_new = Convert.ToDouble(b, CultureInfo.InvariantCulture) * Math.PI;
                double a_new = Convert.ToDouble(a, CultureInfo.InvariantCulture) * Math.PI;
                IPCONF.IPAddress = textBox4.Text;
                IPCONF.Port = Convert.ToInt32(textBox5.Text);

                Solution solution = new Solution(x_new, y_new, b_new, a_new);

                // Serialize the object to JSON
                string json = JsonConvert.SerializeObject(solution);

                string host = IPCONF.IPAddress;
                int port = IPCONF.Port;
                IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(host), port);

                byte[] data = Encoding.UTF8.GetBytes(json);
                client.Send(data, data.Length, remoteEP);

                // Receive a response from the remote endpoint
                IPEndPoint senderEP = new IPEndPoint(IPAddress.Any, 0);
                byte[] response = client.Receive(ref senderEP);
                string reply = Encoding.UTF8.GetString(response);

                // Close the socket
                client.Close();

                label7.Text += reply;

            }
        }
    }
}
