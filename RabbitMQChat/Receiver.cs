using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQChat
{
    class Receiver
    {

        public event EventHandler<Message> onMessageReceived;
        private IModel channel = null;
        private EventingBasicConsumer consumer = null;

        public Receiver(string receivingUser)
        {
            channel = RabbitMQUtility.CreateConnection();
            consumer = new EventingBasicConsumer(channel);
            consumer.Received += HandleMessageReceived;
            channel.BasicConsume(receivingUser, false, consumer);
        }

        private void HandleMessageReceived(object sender, BasicDeliverEventArgs deliverArgs)
        {
            byte[] body = deliverArgs.Body.ToArray();
            Message message = RabbitMQUtility.DecodeMessage(body);
            onMessageReceived?.Invoke(this, message);

            

        }
    }
}
