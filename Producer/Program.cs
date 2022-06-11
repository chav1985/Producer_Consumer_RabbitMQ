using RabbitMQ.Client;
using System;
using System.Text;

namespace Producer
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
                    //cria a fila RabbitMQ e a mensagem
                    channel.QueueDeclare(queue: "mensagem_1",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                    string message = "{\"Id\":1, \"Nome\":\"Teste\"}";
                    var body = Encoding.UTF8.GetBytes(message);
                    Console.WriteLine("Mensagem criada");

                    //enviar mensagem
                    channel.BasicPublish(exchange: "",
                        routingKey: "mensagem_1",
                        basicProperties: null,
                        body: body);
                    Console.WriteLine("Mensagem enviada");
                }
            }
        }
    }
}
