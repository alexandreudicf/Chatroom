using Chatroom.Domain.Settings;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RabbitMQ.Client.Events;
using System;

namespace Chatroom.Infrastructure.Tests
{
    [TestClass]
    public class MessageBrokerTests
    {
        [TestMethod]
        public void TestCanCreateNewMessageBroker()
        {
            IOptions<AppSettings> options = Options.Create(new AppSettings());
            var messageBroker = new MessageBroker(options);
            Assert.IsNotNull(messageBroker);
        }


        [TestMethod]
        public void TestPublishNullReference()
        {
            IOptions<AppSettings> options = Options.Create(new AppSettings());
            var messageBroker = new MessageBroker(options);

            Assert.ThrowsException<ArgumentNullException>(() => messageBroker.Publish(It.IsAny<string>()));
        }

        [TestMethod]
        public void TestPublish()
        {
            IOptions<AppSettings> options = Options.Create(new AppSettings());
            var messageBroker = new MessageBroker(options);
            // Calling method, expecting not throwing any exception.
            messageBroker.Publish("Message");

            //Didnt' throw error. So, it's expected this statement be completed.
            Assert.IsTrue(true);
        }


        [TestMethod]
        public void TestConnect()
        {
            IOptions<AppSettings> options = Options.Create(new AppSettings());
            var messageBroker = new MessageBroker(options);

            // Calling method, expecting not throwing any exception.
            messageBroker.Connect(It.IsAny<EventHandler<BasicDeliverEventArgs>>());

            //Didnt' throw error. So, it's expected this statement be completed.
            Assert.IsTrue(true);
        }
    }
}