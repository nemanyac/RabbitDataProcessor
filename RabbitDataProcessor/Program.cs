namespace RabbitDataProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            using var log = SerilogHelper.BuildSerilog();

            log.Information("Starting processor");
            var amqpUrl = args[0];

            var publisher = new MassTransitListener(amqpUrl);

            while (true)
            {
            }
        }
    }
}
