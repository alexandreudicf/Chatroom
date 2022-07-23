namespace Chatroom.Service.Services.Interfaces
{
    public interface IMessageQueue
    {
        void Connect(Action<string> success);
        void Publish(string stockCode);
    }
}
