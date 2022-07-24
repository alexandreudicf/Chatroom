using Chatroom.Areas.Identity.Data;
using Chatroom.Service.Services.Interfaces;
using Chatroom.SignalRChat;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Chatroom.Tests
{
    [TestClass]
    public class ChatHubTests
    {

        private readonly UserManager<ChatroomUser> _signInManager = Mock.Of<UserManager<ChatroomUser>>();
        private readonly IHttpContextAccessor _httpContextAccessor = Mock.Of<IHttpContextAccessor>();

        private readonly IMemoryCache cache = Mock.Of<IMemoryCache>();
        private readonly IMessageQueue mqService = Mock.Of<IMessageQueue>();


        [TestMethod]
        public void TestChatHub()
        {
            var chatHub = new ChatHub(mqService, cache, null, _httpContextAccessor);
            Assert.IsNotNull(chatHub);
        }
    }
}