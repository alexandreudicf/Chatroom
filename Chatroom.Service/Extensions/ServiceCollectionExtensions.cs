

using Chatroom.Infrastructure.Extensions;
using Chatroom.Service.Services;
using Chatroom.Service.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chatroom.Service.Extensions
{
    /// <summary>
    /// Extension to instantiate required for this package.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services, IConfiguration config)
        {
            //Get URI from settings.
            string sharePriceUri = config.GetSection("AppSettings")["SharePriceUri"];

            // Configure HttpClientFactory.
            services.AddHttpClient<IStockCatalogService, StockCatalogService>().ConfigureHttpClient(client =>
            {
                client.BaseAddress = new Uri(sharePriceUri);
            });

            // Inject Services.
            services.AddSingleton<IMessageQueue, MessageQueueService>();
            services.AddSingleton<IMemoryCache, MemoryCache>();

            // DI for Infra.
            services.AddInfrastructureServices();
        }
    }
}
