using Chatroom.Infrastructure.Extensions;
using Chatroom.Service.Services.RabbitMQ;
using Microsoft.Extensions.DependencyInjection;

namespace Chatroom.Service.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddHttpClient<IMessageQueue>();
            services.AddSingleton<IMessageQueue, MessageQueueService>();
            services.AddInfrastructureServices();
        }
    }
}
