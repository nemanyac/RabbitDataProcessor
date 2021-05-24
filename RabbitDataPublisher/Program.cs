using System;

namespace RabbitDataPublisher
{
    class Program
    {
        static void Main(string[] args)
        {
            var amqpUrl = args[0];
            var amqpSender = args[1];

            var publisher = new MassTransitPublisher(amqpUrl, amqpSender);
            var content = "";

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter message to send, " + amqpSender);
                content = Console.ReadLine();
                publisher.Publish(content);
            }
        }
    }
}
