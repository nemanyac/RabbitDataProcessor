using MassTransit;
using RabbitDataShared;
using System.Threading.Tasks;

namespace RabbitDataProcessor
{
    public class RabbitMessageConsumer : IConsumer<RabbitMessage>
    {
        public async Task Consume(ConsumeContext<RabbitMessage> context)
        {
            using var log = SerilogHelper.BuildSerilog();
            log.Information("{Sender}: {Content}", context.Message.Sender, context.Message.Content);
        }
    }
}