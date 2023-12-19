using Lesson3_5.Models;
using System.Net;

namespace Lesson3_5.Abstracts
{
    public interface IMessageSource
    {
        Task SendAsync(NetMessage message , IPEndPoint ep);

        NetMessage Receive(ref IPEndPoint ep);
    }
}
