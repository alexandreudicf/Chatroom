using Chatroom.Areas.Identity.Data;
using Chatroom.Domain.Models;
using Chatroom.Service.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace Chatroom.SignalRChat
{
    public class ChatHub : Hub
    {
        private readonly UserManager<ChatroomUser> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IMemoryCache cache;
        private readonly IMessageQueue mqService;

        public ChatHub(IMessageQueue mqService, IMemoryCache cache, UserManager<ChatroomUser> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            this.mqService = mqService;
            this.cache = cache;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Publish messages to signalR.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendMessage(string message)
        {
            // Get logged user from session.
            var context = _httpContextAccessor.HttpContext?.User;
            var chatroomUser = await _signInManager.GetUserAsync(context);

            // Verify is valid command.
            if (message.StartsWith("/stock="))
            {
                string stockCode = message.Split("=")[1];
                if (string.IsNullOrEmpty(stockCode))
                {
                    await InvalidCommandAsync("Please provide a valid stock code.");
                } else
                {
                    // Get stock code and publish it to RabbitMQ. 
                    mqService.Publish(message.Split("=")[1]);
                }
            }
            else
            {
                var chatMessage = new ChatMessage
                {
                    User = chatroomUser.Email,
                    Message = message,
                    CreateDate = DateTime.Now,
                };

                cache.Add(chatMessage);
                await Clients.All.SendAsync("ReceiveMessage", chatMessage);
            }
        }

        public async Task InvalidCommandAsync(string warningMessage)
        {
            var chatMessage = new ChatMessage
            {
                User = ChatMessage.BotName,
                Message = warningMessage,
                CreateDate = DateTime.Now,
            };
            await Clients.All.SendAsync("ReceiveMessage", chatMessage);
        }
    }
}
