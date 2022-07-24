using Chatroom.Domain.Models;
using Chatroom.Domain.Settings;
using Chatroom.Service.Services;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Chatroom.Service.Tests
{
    [TestClass]
    public class MemoryCacheTests
    {
        [TestMethod]
        public void TestMemoryCache()
        {
            IOptions<AppSettings> options = Options.Create(new AppSettings());
            var cache = new MemoryCache(options);
            Assert.IsNotNull(cache);
        }


        [TestMethod]
        public void TestInvalidLimit()
        {
            IOptions<AppSettings> options = Options.Create(new AppSettings());
            var cache = new MemoryCache(options);

            Assert.ThrowsException<InvalidOperationException>(() => cache.Add(new ChatMessage()));
        }

        [TestMethod]
        public void TestAddMessage()
        {
            IOptions<AppSettings> options = Options.Create(new AppSettings { MaxMessagesDisplayed = 50 });
            var cache = new MemoryCache(options);
            cache.Add(new ChatMessage());
            Assert.IsNotNull(cache);
        }


        [TestMethod]
        public void TestGetMessagesOrderedByDate()
        {
            IOptions<AppSettings> options = Options.Create(new AppSettings { MaxMessagesDisplayed = 50 });
            var cache = new MemoryCache(options);
            cache.Add(new ChatMessage());
            var messages = cache.GetMessagesOrderedByDate();
            Assert.AreEqual(messages.Count, 1);
        }



        [TestMethod]
        public void TestAddMessageNullMessages()
        {
            IOptions<AppSettings> options = Options.Create(new AppSettings { MaxMessagesDisplayed = 50 });
            var cache = new MemoryCache(options);
            Assert.ThrowsException<ArgumentNullException>(() => cache.Add(null));
        }
    }
}