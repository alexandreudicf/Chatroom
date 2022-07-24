using Chatroom.Domain.Models;
using Chatroom.Service.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chatroom.Service.Tests
{
    [TestClass]
    public class StockCatalogServiceTests
    {
        private HttpClient client = Mock.Of<HttpClient>();

        [TestMethod]
        public void TestStockCatalogService()
        {
            var obj = new StockCatalogService(client);
            Assert.IsNotNull(obj);
        }

        //[TestMethod]
        //public void TestGetStockByAPIAsync()
        //{
        //    var expected = new Prices();
        //    var obj = new StockCatalogService(client);
        //    Mock.Get(client).Setup(a => a.GetFromJsonAsync<Prices>("sdfds", It.IsAny<CancellationToken>())).ReturnsAsync(expected);
        //    var result = obj.GetStockByAPIAsync<Prices>("API");
        //    Assert.IsInstanceOfType(result, typeof(Prices));
        //}
    }
}
