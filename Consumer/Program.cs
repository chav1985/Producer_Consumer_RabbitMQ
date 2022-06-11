using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Consumer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    //cria a fila RabbitMQ
                    channel.QueueDeclare(queue: "mensagem_1",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                    //consumindo a mensagem e aretirando da fila
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine(message);
                    };
                    channel.BasicConsume(queue: "mensagem_1",
                        autoAck: true,
                        consumer: consumer);

                    Console.WriteLine("Mensagem consumida.");
                }
                //Console.ReadKey();
            }
        }
    }
}
