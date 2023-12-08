using Network;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                //string num = "exit";
                //Task.Run(() =>
                SentMessage("dim");
            }

        }


        public static void SentMessage(string From,  string ip = "127.0.0.1")
        {
            UdpClient udpClient = new UdpClient();
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(ip), 12345);

            while (true)
            {
                string messageText;
                do
                {
                    //Console.Clear();
                    Console.WriteLine("Введите сообщение.");
                    messageText = Console.ReadLine();

                }
                while (string.IsNullOrEmpty(messageText));

                Message message = new Message() { Text = messageText, NicknameFrom = From, NicknameTo = "Server", DateTime = DateTime.Now };
                string json = message.SerializeMessageToJson();

                byte[] data = Encoding.UTF8.GetBytes(json);
                udpClient.Send(data, data.Length, iPEndPoint);
                //if (checker == data.Length) { Console.WriteLine("Cообщение отправлено"); }
                //else { Console.WriteLine("Сообщение потерялось"); }

                byte[] buffer = udpClient.Receive(ref iPEndPoint);
                var answer = Encoding.UTF8.GetString(buffer);

                Console.WriteLine(answer);
            }
        }
    }
}