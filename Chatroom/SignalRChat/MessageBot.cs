using Chatroom.Domain.Models;
using Chatroom.Service.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Chatroom.SignalRChat
{
    public class MessageBot
    {
        private readonly IMessageQueue mqService;
        private readonly IHubContext<ChatHub> chatHub;

        public MessageBot(IMessageQueue mqService, IHubContext<ChatHub> chatHub)
        {
            this.mqService = mqService;
            this.chatHub = chatHub;
        }

        /// <summary>
        /// Handles messages coming from different channels.
        /// </summary>
        public void Connect()
        {
            mqService.Connect(async (string message) =>
            {
                var chatMessage = new ChatMessage
                {
                    User = "Bot",
                    Message = message,
                    CreateDate = DateTime.Now,
                };

                // Send message to all users in SignalR
                await chatHub.Clients.All.SendAsync("ReceiveMessage", chatMessage);
            });
        }


    }
}
