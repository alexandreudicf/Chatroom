using Chatroom.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatroom.Domain.Tests
{
    [TestClass]
    public class PricesTests
    {

        [TestMethod]
        public void TestPricesIsNotEmpty()
        {
            var message = new Prices
            {
                Symbols = new List<SharePrice>(),

            };
            Assert.IsNotNull(message.Symbols);
            Assert.AreEqual(0, message.Symbols.Count);
        }
    }
}
