using RabbitMQ.Client.Events;

namespace Chatroom.Infrastructure
{
    public interface IMessageBroker
    {
        void Connect(EventHandler<BasicDeliverEventArgs> received);
        void Publish(string message);
    }
}
