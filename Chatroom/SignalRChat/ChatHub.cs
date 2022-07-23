using System.Text;
using Chatroom.Domain.Models;
using Chatroom.Service.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;
using RabbitMQ.Client;

namespace Chatroom.SignalRChat
{
    public class ChatHub : Hub
    {
        private readonly IMemoryCache cache;
        private readonly IMessageQueue mqService;

        public ChatHub(IMessageQueue mqService, IMemoryCache cache)
        {
            this.mqService = mqService;
            this.cache = cache;
        }

        public async Task SendMessage(string user, string message)
        {
            if (message.StartsWith("/stock="))
            {
                mqService.Publish(message.Split("=")[1]);
            } else
            {
                var chatMessage = new ChatMessage
                {
                   User = user,
                   Message = message,
                   CreateDate = DateTime.Now,
                };

                cache.Add(chatMessage);
                await Clients.All.SendAsync("ReceiveMessage", chatMessage);
            }
        }
    }
}
