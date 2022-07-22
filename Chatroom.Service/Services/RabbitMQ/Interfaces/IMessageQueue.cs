namespace Chatroom.Service.Services.RabbitMQ.Interfaces
{
    public interface IMessageQueue
    {
        void Connect(Action<string> success);
        void Publish(string stockCode);
    }
}
