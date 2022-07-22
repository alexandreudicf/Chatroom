using Chatroom.Domain.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatroom.Infrastructure
{
    public class MessageBroker : IMessageBroker
    {
        private readonly string QueueName = "TestQueue";

        protected readonly ConnectionFactory _factory;
        protected readonly IConnection _connection;
        protected readonly IModel _channel;

        protected readonly IServiceProvider _serviceProvider;

        public MessageBroker(IServiceProvider serviceProvider)
        {
            // Opens the connections to RabbitMQ
            _factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();

            _serviceProvider = serviceProvider;
        }

        public void Publish(string message)
        {
            _channel.QueueDeclare(queue: this.QueueName, durable: true, exclusive: false, autoDelete: false,
                                 arguments: null);

            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(exchange: "",
                                 routingKey: this.QueueName,
                                 basicProperties: null,
                                 body: body);
        }

        public void Connect(EventHandler<BasicDeliverEventArgs> received)
        {
            // Declare a RabbitMQ Queue
            _channel.QueueDeclare(queue: this.QueueName, durable: true, exclusive: false, autoDelete: false);

            var consumer = new EventingBasicConsumer(_channel);

            // When we receive a message from SignalR
            consumer.Received += received;

            // Consume a RabbitMQ Queue
            _channel.BasicConsume(queue: this.QueueName, autoAck: true, consumer: consumer);
        }
    }
}
