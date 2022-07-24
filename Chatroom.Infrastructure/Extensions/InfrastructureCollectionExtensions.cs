using Microsoft.Extensions.DependencyInjection;

namespace Chatroom.Infrastructure.Extensions
{
    /// <summary>
    /// Extension to instantiate required for this package.
    /// </summary>
    public static class InfrastructureCollectionExtensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            // One time instantation for MessageBroker.
            services.AddSingleton<IMessageBroker, MessageBroker>();
        }
    }
}
