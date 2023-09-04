using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RabbitMQ
{
    public class RabbitMQWrapper
    {
        private string RabbitMQUri { get; set; }

        public RabbitMQWrapper(IConfiguration configuration)
        {
            RabbitMQUri = configuration.GetConnectionString("RabbitMQConnectionString");
        }

        public void initRabbit()
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri(RabbitMQUri);
            factory.ClientProvidedName = "Rabbit API Sender";

            IConnection cnn = factory.CreateConnection();
            IModel channel = cnn.CreateModel();
            string exchangeName = "DemoExchange";
            string routingKey = "DemoroutingKey";
            string queueName = "DemoQueue";

            channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
            channel.QueueDeclare(queueName, false, false, false, null);
            channel.QueueBind(queueName, exchangeName, routingKey, null);

            byte[] messageBodyBytes = Encoding.UTF8.GetBytes("Hello  world");

            channel.BasicPublish(exchangeName, routingKey, null, messageBodyBytes);

            channel.Close();
            cnn.Close();
        }

        public void initRabbit1()
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri(RabbitMQUri);
            factory.ClientProvidedName = "Rabbit API Sender";

            IConnection cnn = factory.CreateConnection();
            IModel channel = cnn.CreateModel();
            string exchangeName = "DemoExchange1";
            string routingKey = "DemoroutingKey1";
            string queueName = "DemoQueue1";

            channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
            channel.QueueDeclare(queueName, false, false, false, null);
            channel.QueueBind(queueName, exchangeName, routingKey, null);

            byte[] messageBodyBytes = Encoding.UTF8.GetBytes("Hello  world");

            channel.BasicPublish(exchangeName, routingKey, null, messageBodyBytes);

            channel.Close();
            cnn.Close();
        }

        public void initRabbit2()
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri(RabbitMQUri);
            factory.ClientProvidedName = "Rabbit API Sender";

            IConnection cnn = factory.CreateConnection();
            IModel channel = cnn.CreateModel();
            string exchangeName = "DemoExchange2";
            string routingKey = "DemoroutingKey1";
            string queueName = "DemoQueue1";

            channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
            channel.QueueDeclare(queueName, false, false, false, null);
            channel.QueueBind(queueName, exchangeName, routingKey, null);

            byte[] messageBodyBytes = Encoding.UTF8.GetBytes("Hello  world");

            channel.BasicPublish(exchangeName, routingKey, null, messageBodyBytes);

            channel.Close();
            cnn.Close();
        }
    }
}