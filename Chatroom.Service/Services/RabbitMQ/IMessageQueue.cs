namespace Chatroom.Service.Services.RabbitMQ
{
    public interface IMessageQueue
    {
        void Connect(Action<string> success);
        void Publish(string stockCode);
    }
}
