using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQChat
{
    class Sender
    {
        private string _user;
        private IModel _channel;

        public string User => _user;
        public IModel Channel => _channel;

        public Sender(string user)
        {
            _channel = RabbitMQUtility.CreateConnection();
            _user = user;
            _channel.QueueDeclare(
                queue: _user,
                durable: false,
                autoDelete: false,
                exclusive: false,
                arguments: null
                );
        }

        public void SendMessage(string text, string receiver)
        {
            Message message = new Message()
            {
                Author = _user,
                Text = RabbitMQUtility.EncodeMessage(text)
            };
            string serializedMessage = JsonConvert.SerializeObject(message);
            byte[] body = RabbitMQUtility.EncodeMessage(serializedMessage);

            _channel.BasicPublish(
                exchange: receiver,
                routingKey: _user,
                basicProperties: null,
                body: body
                );
            myDBConnection.SaveMessageToDB(receiver, serializedMessage);
        }

    }
}
