using Microsoft.Extensions.Configuration;
using PurchaseService.DTOs;
using RabbitMQ.Client;
using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Unicode;

namespace PurchaseService.RabbitMqClient
{
    public class RabbitMqClient : IRabbitMqClient
    {
        private readonly IConfiguration _configuration;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private int a;
        public RabbitMqClient(IConfiguration configuration)
        {
            _configuration = configuration;

            _connection = new ConnectionFactory()
            {
                HostName = "localhost",
                Port = 5672,
            }.CreateConnection();

            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare("trigger", ExchangeType.Fanout);
        }

        public async void PublishOrder(ProductDTO productDto)
        {
            var message = JsonSerializer.Serialize(productDto);
            var bytesMessage = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish("trigger", "", null, bytesMessage);
        }
    }
}
