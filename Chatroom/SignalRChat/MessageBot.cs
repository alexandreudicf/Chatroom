using Chatroom.Service.Services.RabbitMQ;
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

        public void Connect()
        {
            mqService.Connect(async (string message) =>
            {
                // Send message to all users in SignalR
                await chatHub.Clients.All.SendAsync("ReceiveMessage", "bot", message);
            });
        }


    }
}
