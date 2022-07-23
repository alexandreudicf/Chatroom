using Chatroom.Domain.Models;
using Chatroom.Domain.Settings;
using Chatroom.Service.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace Chatroom.Service.Services
{
    /// <summary>
    /// This service is created to provide data stored in the memory.
    /// TODO: Create a better way to store and get it. Redis service is a suggestion.
    /// </summary>
    public class MemoryCache : IMemoryCache
    {
        private readonly AppSettings settings;
        private Queue<ChatMessage> Messages { get; set; }

        public MemoryCache(IOptions<AppSettings> options)
        {
            this.settings = options?.Value;
            Messages = new Queue<ChatMessage>();
        }

        /// <summary>
        /// Add new message on the queue. If limit is reached out dequeue it.
        /// </summary>
        /// <param name="message"></param>
        public void Add(ChatMessage message)
        {
            int limit = this.settings?.MaxMessagesDisplayed ?? 50;
            if (Messages.Count >= limit)
                Messages.Dequeue();

            Messages.Enqueue(message);
        }

        /// <summary>
        /// Get every message ordered by date.
        /// </summary>
        /// <returns>Returns <see cref="ChatMessage"/>.</returns>
        public List<ChatMessage> GetMessagesOrderedByDate()
        {
            return Messages.OrderBy(m => m.CreateDate).ToList();
        }
    }
}
