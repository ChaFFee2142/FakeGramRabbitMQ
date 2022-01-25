using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace RabbitMQChat
{
    public static class RabbitMQUtility
    {
        public static IModel CreateConnection()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory() { HostName = "localhost"};
            IConnection connection = connectionFactory.CreateConnection();
            return connection.CreateModel();
        }

        public static byte[] EncodeMessage(string message)
        {
            return Encoding.UTF8.GetBytes(message);
        }

        public static Message DecodeMessage(byte[] message)
        {
            string decodedMessage = Encoding.UTF8.GetString(message, 0, message.Length);
            return JsonConvert.DeserializeObject<Message>(decodedMessage);
        }

        public static void DeclareQueueExchange(IModel channel, string exchangeName, string type)
        {
            channel.ExchangeDeclare(exchangeName, type, false, false, null);
        }

        public static void BindExchangeToQueue(IModel channel, string exchangeName, string queueName)
        {
            channel.QueueBind(queueName, exchangeName, "", null);
        }
    }
}
