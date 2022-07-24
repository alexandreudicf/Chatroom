using Chatroom.Infrastructure;
using Chatroom.Service.Services;
using Chatroom.Service.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Chatroom.Service.Tests
{
    [TestClass]
    public class MessageQueueServiceTests
    {
        private readonly IStockCatalogService stockCatalogService = Mock.Of<IStockCatalogService>();
        private readonly IMessageBroker messageBroker = Mock.Of<IMessageBroker>();

        [TestMethod]
        public void TestMessageQueueService()
        {
            var service = new MessageQueueService(messageBroker, stockCatalogService);
            Assert.IsNotNull(service);
        }


        [TestMethod]
        public void TestPublishInvalidParam()
        {
            var service = new MessageQueueService(messageBroker, stockCatalogService);
            Assert.ThrowsException<ArgumentNullException>(() => service.Publish(It.IsAny<string>()));
        }

        [TestMethod]
        public void TestConnect()
        {
            var service = new MessageQueueService(messageBroker, stockCatalogService);
            service.Connect((s) => Assert.IsNotNull(s));
        }
    }
}
