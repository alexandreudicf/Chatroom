using Chatroom.Service.Services.RabbitMQ.Interfaces;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Net.Http.Json;

namespace Chatroom.Service.Services.RabbitMQ
{
    public class StockCatalogService : IStockCatalogService
    {
        private readonly HttpClient _client;

        public StockCatalogService(HttpClient client)
        {
            _client = client;
        }

        public async Task<T> GetStockByAPIAsync<T>(string API)
        {
            var resp = await _client.GetFromJsonAsync<T>(API);
            return resp;
        }
    }
}
