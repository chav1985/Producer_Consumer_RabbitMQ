using RabbitMQ.Client;
using System;
using System.Text;

namespace Producer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var factory = new ConnectionFactory() { HostName = "localhost" };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    //criar mensagem RabbitMQ
                    channel.QueueDeclare(queue: "mensagem_2",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                    string message = "Teste de mensagem RabbitMQ";
                    var body = Encoding.UTF8.GetBytes(message);
                    Console.WriteLine("Mensagem criada");

                    //enviar mensagem
                    channel.BasicPublish(exchange: "",
                        routingKey: "mensagem_2",
                        basicProperties: null,
                        body: body);
                    Console.WriteLine("Mensagem enviada");
                }
                Console.ReadKey();
            }
        }
    }
}
