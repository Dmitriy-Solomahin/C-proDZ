using System.Net;
using Lesson3_5.Abstracts;
using Lesson3_5.Models;
using Lesson3_5.Services;

namespace ServerTest
{
    internal class MockMessageSource : IMessageSource
    {
        private Queue<NetMessage> _messages = new ();
        private Server _server;
        private IPEndPoint _endPoint = new IPEndPoint(IPAddress.Any, 0);

        public MockMessageSource()
        {
            _messages.Enqueue(new NetMessage { Command = Command.Register, NickNameFrom = "Вася" });
            _messages.Enqueue(new NetMessage { Command = Command.Register, NickNameFrom = "Юля" });
            _messages.Enqueue(new NetMessage { Command = Command.Message, NickNameFrom = "Юля", NickNameTo = "Вася", Text = "Привет от Юли" });
            _messages.Enqueue(new NetMessage { Command = Command.Message, NickNameFrom = "Вася", NickNameTo = "Юля", Text = "Привет от Васи" });
        }
        public void AddServer(Server srv)
        {
            _server = srv;
        }
        public NetMessage Receive(ref IPEndPoint ep)
        {
            ep = _endPoint;

            if (_messages.Count == 0)
            {
                _server.Stop();
                return null;
            }

            var msg = _messages.Dequeue();

            return msg;
        }

        public async Task SendAsync(NetMessage message, IPEndPoint ep)
        {
            //throw new NotImplementedException();
        }
    }
}
