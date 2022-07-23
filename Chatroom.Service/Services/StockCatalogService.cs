using Chatroom.Service.Services.Interfaces;
using System.Net.Http.Json;

namespace Chatroom.Service.Services
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
