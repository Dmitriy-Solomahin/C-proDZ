using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Network
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await Task.Run(() => Server());
            
            //Server();
        }

        public void task1()
        {
            Message msg = new Message() { Text = "Hello", DateTime = DateTime.Now, NicknameFrom = "Artem", NicknameTo = "All" };
            string json = msg.SerializeMessageToJson();
            Console.WriteLine(json);
            Message? msgDeserialized = Message.DeserializeFromJson(json);
        }


        // List<Task> tasks = new List<Task>();
        public static async Task  Server()
        {

            UdpClient udpClient = new UdpClient(12345);
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 0);

            Console.WriteLine("Сервер ждет сообщение от клиента");
            var clt = new CancellationTokenSource();
            var token = clt.Token;
            
            while (!clt.IsCancellationRequested)
            {
                try
                {
                    
                    await Task.Run(() =>
                    {
                        byte[] buffer = udpClient.Receive(ref iPEndPoint);
                        var messageText = Encoding.UTF8.GetString(buffer);
                        Message message = Message.DeserializeFromJson(messageText);

                        if (message.Text.ToLower().Equals("exit"))
                        {
                            clt.Cancel();
                        }
                        if (token.IsCancellationRequested) { token.ThrowIfCancellationRequested(); }

                        
                        message.Print();

                        byte[] reply = Encoding.UTF8.GetBytes("Cообщение доставлено");
                        udpClient.Send(reply, reply.Length, iPEndPoint);
                    }, token);
                    
                    //await Task.Delay(1000);
                    
                }
                catch (AggregateException ae)
                {
                    foreach (Exception e in ae.InnerExceptions)
                    {
                        if(e is TaskCanceledException)
                        {
                            Console.WriteLine("сервер завершает работу");
                            break;
                        }
                        else Console.WriteLine(e.Message);
                    }
                }
                catch (OperationCanceledException e)
                {
                    Console.WriteLine("сервер завершает работу 2");
                    break;
                }
                
                
            }
            clt.Dispose();


        }

    }
}