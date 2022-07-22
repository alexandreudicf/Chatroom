using System.Text;
using Chatroom.Service.Services.RabbitMQ;
using Microsoft.AspNetCore.SignalR;
using RabbitMQ.Client;

namespace Chatroom.SignalRChat
{
    public class ChatHub : Hub
    {
        private IMessageQueue mqService;

        public ChatHub(IMessageQueue mqService)
        {
            this.mqService = mqService;
        }

        public async Task SendMessage(string user, string message)
        {
            if (message.StartsWith("/stock="))
            {
                mqService.Publish(message.Split("=")[1]);
            } else
            {
                await Clients.All.SendAsync("ReceiveMessage", user, message);
            }
        }
    }
}
