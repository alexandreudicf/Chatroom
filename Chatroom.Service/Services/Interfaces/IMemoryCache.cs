using Chatroom.Domain.Models;

namespace Chatroom.Service.Services.Interfaces
{
    public interface IMemoryCache
    {
        void Add(ChatMessage message);
        List<ChatMessage> GetMessagesOrderedByDate();
    }
}
