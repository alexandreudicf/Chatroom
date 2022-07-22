

using Chatroom.Domain.Settings;
using Chatroom.Infrastructure.Extensions;
using Chatroom.Service.Services.RabbitMQ;
using Chatroom.Service.Services.RabbitMQ.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chatroom.Service.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services, IConfiguration config)
        {
            string sharePriceUri = config.GetSection("AppSettings")["SharePriceUri"];
            services.AddHttpClient<IStockCatalogService, StockCatalogService>().ConfigureHttpClient(client => {
                client.BaseAddress = new Uri(sharePriceUri);
            });
            services.AddSingleton<IMessageQueue, MessageQueueService>();
            services.AddInfrastructureServices();
        }
    }
}
