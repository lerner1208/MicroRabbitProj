using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace RabbitUtil
{
    public class RabbitService
    {
        public static void SendMessage(object data , string sendQueueName)
        {
            var factory = new ConnectionFactory() { HostName = "LocalHost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(sendQueueName, false, false, false, null);

                var serializedData = JsonConvert.SerializeObject(data);

                var body = Encoding.UTF8.GetBytes(serializedData);

                channel.BasicPublish("", "BasicTest", null, body);

                Console.WriteLine($"The message was Sent successfully!");
            }
        }

        public static void RecieveMessage<T>(string recieveQueueName , Action<T> doSomething)
        {
            var factory = new ConnectionFactory() { HostName = "LocalHost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(recieveQueueName, false, false, false, null);

                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var deserializedData = JsonConvert.DeserializeObject<T>(message);
                    doSomething(deserializedData);
                    Console.WriteLine("New item was recieved:\n{0}", message);
                };

                channel.BasicConsume("BasicTest", true, consumer);
            }
        }
    }
}
