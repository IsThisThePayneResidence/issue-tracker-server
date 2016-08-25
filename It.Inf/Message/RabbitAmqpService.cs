using System;
using System.Configuration;
using System.Text;
using It.Model.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace It.Inf.Message
{
    internal class RabbitAmqpService : IAmqpService
    {
        private readonly IModel _channel;

        public RabbitAmqpService()
        {
            var factory = new ConnectionFactory
            {
                Uri = ConfigurationManager.ConnectionStrings["RabbitSettings"].ConnectionString
            };

            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();
        }

        public void Listen(ListenCriteria criteria, Func<IRequest, IResponse> callback)
        {
            var queueName = _channel.QueueDeclare();
            SetListenerForQueue(queueName, criteria, callback);
        }

        public void Listen(string listeningPointName, ListenCriteria criteria, Func<IRequest, IResponse> callback)
        {
            _channel.QueueDeclare(listeningPointName, true, true, false, null);
            SetListenerForQueue(listeningPointName, criteria, callback);
        }

        public void Send(string message, string destination, string filteringTag)
        {
            _channel.ExchangeDeclare(destination, "fanout");

            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(destination, filteringTag, null, body);
        }

        private void SetListenerForQueue(string queueName, ListenCriteria criteria,
            Func<IRequest, IResponse> callback)
        {
            _channel.ExchangeDeclare(criteria.Source, "fanout");
            _channel.QueueBind(queueName, criteria.Source, criteria.FilteringTag);


            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);

                var response = callback(new JsonRequestParser<object>(message));

                var replyProps = _channel.CreateBasicProperties();
                replyProps.CorrelationId = ea.BasicProperties.CorrelationId;

                _channel.BasicPublish("", ea.BasicProperties.ReplyTo, replyProps, Encoding.UTF8.GetBytes(response.GetResponse()));

                Console.WriteLine(" [x] {0}", message);
            };
            _channel.BasicConsume(queueName, true, consumer);
        }
    }
}