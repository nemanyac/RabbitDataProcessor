using MassTransit;

namespace RabbitDataProcessor
{
    public class MassTransitListener
    {
        private readonly IBusControl _busControl;

        public MassTransitListener(string url)
        {
            using var log = SerilogHelper.BuildSerilog();

            var guid = System.Environment.MachineName;
            log.Debug("Processor constructor: {guid}", guid);

            _busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(url);

                cfg.ReceiveEndpoint($"Listener_{guid}", e =>
                {
                    e.Consumer<RabbitMessageConsumer>();
                });
            });

            _busControl.Start();
            log.Debug("Processor started");
        }
    }
}