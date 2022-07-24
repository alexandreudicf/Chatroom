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
    public class SharePriceTests
    {
        [TestMethod]
        public void TestSharePricelAreSameValues()
        {
            var dateTime = System.DateTime.Now;
            var sharePrice = new SharePrice
            {
                Close = 0,
                Date = dateTime,
                High = 0,
                Low = 0,
                Open = 0,
                Symbol = "Symbol",
                Time = "10:10",
                Volume = 0

            };
            Assert.AreEqual(0, sharePrice.Close);
            Assert.AreEqual(dateTime, sharePrice.Date);
            Assert.AreEqual(0, sharePrice.High);
            Assert.AreEqual(0, sharePrice.Low);
            Assert.AreEqual(0, sharePrice.Open);
            Assert.AreEqual("Symbol", sharePrice.Symbol);
            Assert.AreEqual(0, sharePrice.Volume);
        }
    }
}
