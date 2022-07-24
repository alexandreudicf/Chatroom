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

        /// <summary>
        /// Send to queue a intent to get price for a specfic stock code.
        /// </summary>
        /// <param name="stockCode"></param>
        public void Publish(string stockCode)
        {
            if (stockCode == null)
                throw new ArgumentNullException(nameof(stockCode));

            _messageQueue.Publish(stockCode);
        }

        /// <summary>
        /// Connect and listen events to get payload from API.
        /// </summary>
        /// <param name="success"></param>
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
                    data = $"Share price Can't be found for {message} code";
                }
                success?.Invoke(data);
            });
        }

        /// <summary>
        /// Call API to get stock price.
        /// </summary>
        /// <param name="stockCode">Code required to get stock price.</param>
        /// <returns></returns>
        private async Task<string> GetPriceMessageAsync(string stockCode)
        {
            if (stockCode == null)
                throw new ArgumentNullException(nameof(stockCode));

            var path = $"?s={stockCode}&f=sd2t2ohlcv&h&e=json";
            var prices = await stockCatalogService.GetStockByAPIAsync<Prices>(path);

            var price = prices.Symbols.FirstOrDefault();

            return $"{price?.Symbol} quote is ${price?.High} per share";
        }
    }
}
