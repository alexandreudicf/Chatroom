using Chatroom.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatroom.Service.Services.Interfaces
{
    public interface IMemoryCache
    {
        void Add(ChatMessage message);
        List<ChatMessage> GetMessagesOrderedByDate();
    }
}
