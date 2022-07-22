using Microsoft.Extensions.DependencyInjection;

namespace Chatroom.Infrastructure.Extensions
{
    public static class InfrastructureCollectionExtensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddSingleton<IMessageBroker, MessageBroker>();
        }
    }
}
