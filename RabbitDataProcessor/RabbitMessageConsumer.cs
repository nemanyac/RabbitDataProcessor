using System;
using MassTransit;
using RabbitDataShared;
using System.Threading.Tasks;

namespace RabbitDataProcessor
{
    public class RabbitMessageConsumer : IConsumer<RabbitMessage>
    {
        public async Task Consume(ConsumeContext<RabbitMessage> context)
        {
            Console.WriteLine($"{context.Message.TimeStamp} ({context.Message.Sender}) : {context.Message.Content}");
        }
    }
}