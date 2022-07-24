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

        /// <summary>
        /// Call API(Base Address coming from appsetting) with a specific path param.
        /// </summary>
        /// <typeparam name="T">Generic Type to parse.</typeparam>
        /// <param name="API">Path param</param>
        /// <returns>Returns a Task of determined type.</returns>
        public async Task<T> GetStockByAPIAsync<T>(string API)
        {
            var resp = await _client.GetFromJsonAsync<T>(API);
            return resp;
        }
    }
}
