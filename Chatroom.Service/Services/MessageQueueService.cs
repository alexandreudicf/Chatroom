using Chatroom.Domain.Models;
using Chatroom.Infrastructure;
using Chatroom.Service.Services.Interfaces;
using RabbitMQ.Client.Events;
using System.Text;

namespace Chatroom.Service.Services
{
    public class MessageQueueService : IMessageQueue
    {
        private readonly IStockCatalogService stockCatalogService;
        private readonly IMessageBroker _messageQueue;

        public MessageQueueService(IMessageBroker messageQueue, IStockCatalogService stockCatalogService)
        {
            _messageQueue = messageQueue;
            this.stockCatalogService = stockCatalogService;
        }

        public void Publish(string stockCode)
        {
            _messageQueue.Publish(stockCode);
        }

        public void Connect(Action<string> success)
        {
            _messageQueue.Connect(async delegate (object? model, BasicDeliverEventArgs ea)
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var data = string.Empty;
                try
                {
                    data = await GetPriceMessageAsync(message);

                }
                catch (Exception)
                {
                    data = $"Can't be found price for {message} code";
                }
                success?.Invoke(data);
            });
        }

        private async Task<string> GetPriceMessageAsync(string stockCode)
        {
            var path = $"?s={stockCode}&f=sd2t2ohlcv&h&e=json";
            var prices = await stockCatalogService.GetStockByAPIAsync<Prices>(path);

            var price = prices.Symbols.FirstOrDefault();

            return $"{price?.Symbol} quote is ${price?.High} per share";
        }
    }
}
