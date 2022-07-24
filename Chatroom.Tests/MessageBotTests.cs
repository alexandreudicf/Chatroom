using Chatroom.Service.Services.Interfaces;
using Chatroom.SignalRChat;
using Microsoft.AspNetCore.SignalR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatroom.Tests
{
    [TestClass]
    public class MessageBotTests
    {
        private readonly IMessageQueue mqService = Mock.Of<IMessageQueue>();
        private readonly IHubContext<ChatHub> chatHub = Mock.Of<IHubContext<ChatHub>>();

        [TestMethod]
        public void TestMessageBot()
        {
            var obj = new MessageBot(mqService, chatHub);
            Assert.IsNotNull(obj);
        }

        [TestMethod]
        public void TestConnect()
        {
            var obj = new MessageBot(mqService, chatHub);
            obj.Connect();
            Assert.IsNotNull(obj);
        }
    }
}
