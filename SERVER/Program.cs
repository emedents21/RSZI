using Newtonsoft.Json;
using RSZ1;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient server = new UdpClient();

            int port = 7000;
            IPEndPoint localEP = new IPEndPoint(IPAddress.Any, port);
            server.Client.Bind(localEP);

            Console.WriteLine("Server is start working", port);
            while (true)
            {
                IPEndPoint senderEP = new IPEndPoint(IPAddress.Any, 0);
                byte[] data = server.Receive(ref senderEP);
                string message = Encoding.UTF8.GetString(data);

                Solution solution = JsonConvert.DeserializeObject<Solution>(message);
                double sum = solution.Calcucate(solution.x, solution.y, solution.b, solution.a);
                string jsonSum = JsonConvert.SerializeObject(sum);
                byte[] datSum = Encoding.UTF8.GetBytes(jsonSum);
                server.Send(datSum, datSum.Length, senderEP);
            }

        }
    }
}