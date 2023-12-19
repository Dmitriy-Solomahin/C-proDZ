﻿using Lesson3_5.Abstracts;
using Lesson3_5.Models;
using System.Net;
using System.Net.Sockets;
using System.Text;


namespace Lesson3_5.Services
{
    internal class UdpMessageSouce : IMessageSource
    {
        private readonly UdpClient _udpClient;
        public UdpMessageSouce()
        {
            _udpClient = new UdpClient(12345);
        }
        public  NetMessage Receive(ref IPEndPoint ep)
        {
            byte[] data = _udpClient.Receive(ref ep);
            string str = Encoding.UTF8.GetString(data);
            return NetMessage.DeserializeMessgeFromJSON(str) ?? new NetMessage();
        }

        public async Task SendAsync(NetMessage message, IPEndPoint ep)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message.SerialazeMessageToJSON());

            await   _udpClient.SendAsync(buffer, buffer.Length, ep);
        }
    }
}
