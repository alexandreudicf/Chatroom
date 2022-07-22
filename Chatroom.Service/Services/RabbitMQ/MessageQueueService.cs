
using Chatroom.Infrastructure;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.SignalR;
using RabbitMQ.Client.Events;
using System.Globalization;
using System.Net.Http.Headers;
using System.Text;

namespace Chatroom.Service.Services.RabbitMQ
{
    public class MessageQueueService : IMessageQueue
    {
        private readonly HttpClient _client;
        private readonly IMessageBroker _messageQueue;

        public MessageQueueService(IMessageBroker messageQueue, HttpClient client)
        {
            _messageQueue = messageQueue;
            _client = client;
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
                await this.ParseCSVFileAsync(message);
                success?.Invoke("Success");
            });
        }

        public async Task ParseCSVFileAsync(string stockCode)
        {
            var url = $"https://stooq.com/q/l/?s=${stockCode}&f=sd2t2ohlcv&h&e=csv";

            using (var msg = new HttpRequestMessage(HttpMethod.Get, new Uri(url)))
            {
                msg.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/csv"));
                using (var resp = await _client.SendAsync(msg))
                {
                    resp.EnsureSuccessStatusCode();

                    var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        NewLine = Environment.NewLine,
                        DetectDelimiter = true
                    };

                    using (var s = await resp.Content.ReadAsStreamAsync())
                    using (var sr = new StreamReader(s))
                    using (var futureoptionsreader = new CsvReader(sr, config))
                    {
                        //futureoptionsreader.Configuration.RegisterClassMap<MappingNSEIndexes>();
                        //var list = futureoptionsreader.GetRecords<RawNSEIndexes>();
                        //var number = list.Count();
                    }
                }
            }
        }
    }
}
