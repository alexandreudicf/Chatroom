using Chatroom.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chatroom.Domain.Tests
{
    [TestClass]
    public class ChatMessageTests
    {
        [TestMethod]
        public void TestChatMessageModelIsSame()
        {
            var dateTime = System.DateTime.Now;
            var message = new ChatMessage
            {
                CreateDate = dateTime,
                Message = "Message",
                User = "User"
            };
            Assert.AreEqual("Message", message.Message);
            Assert.AreEqual(@"User", message.User);
            Assert.AreEqual(dateTime, message.CreateDate);
        }
    }
}