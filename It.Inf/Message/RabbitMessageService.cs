using It.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using System.Configuration;
using RabbitMQ.Client.Events;
using It.Inf.Helpers;

namespace It.Inf.Message
{
    class RabbitMessageService : IMessageService
    {
        IModel _channel;

        public RabbitMessageService()
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = ConfigurationManager.ConnectionStrings["RabbitSettings"].ConnectionString;

            IConnection connection = factory.CreateConnection();
            _channel = connection.CreateModel();
        }

        public void Listen(ListenCriteria criteria, Func<Model.Interfaces.Message, bool> callback)
        {
            var queueName = _channel.QueueDeclare();
            SetListenerForQueue(queueName, criteria, callback);
        }

        public void Listen(string listeningPointName, ListenCriteria criteria, Func<Model.Interfaces.Message, bool> callback)
        {
            var queueName = _channel.QueueDeclare(queue: listeningPointName, durable: true,
                                                    exclusive: true, autoDelete: false,
                                                    arguments: null);
            SetListenerForQueue(queueName, criteria, callback);
        }

        private void SetListenerForQueue(string queueName, ListenCriteria criteria, Func<Model.Interfaces.Message, bool> callback)
        {
            _channel.ExchangeDeclare(exchange: criteria.Source, type: "fanout");
            _channel.QueueBind(queue: queueName,
                                exchange: criteria.Source,
                                routingKey: criteria.FilteringTag);


            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);

                callback(new Model.Interfaces.Message
                {
                    Body = message
                });

                Console.WriteLine(" [x] {0}", message);
            };
            _channel.BasicConsume(queue: queueName,
                                    noAck: true,
                                    consumer: consumer);
        }

        public void Send(Model.Interfaces.Message message, String destination, String filteringTag)
        {
            _channel.ExchangeDeclare(exchange: destination, type: "fanout");
            
            var body = Encoding.UTF8.GetBytes(message.Body);
            _channel.BasicPublish(exchange: destination, routingKey: filteringTag, 
                                    basicProperties: null, body: body);
        }
    }
}
