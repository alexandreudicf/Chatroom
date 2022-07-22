using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatroom.Infrastructure
{
    public interface IMessageBroker
    {
        void Connect(EventHandler<BasicDeliverEventArgs> received);
        void Publish(string message);
    }
}
