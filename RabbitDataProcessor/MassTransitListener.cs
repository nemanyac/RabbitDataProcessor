using System;
using MassTransit;

namespace RabbitDataProcessor
{
    public class MassTransitListener
    {
        private readonly IBusControl _busControl;

        public MassTransitListener(string url)
        {
            var guid = Guid.NewGuid();
            Console.WriteLine($"Processor constructor: {guid}");
            _busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(url);

                cfg.ReceiveEndpoint($"MassTransitListener_{guid}", e =>
                {
                    e.Consumer<RabbitMessageConsumer>();
                });
            });

            _busControl.Start();
            Console.WriteLine("Processor started");
        }
    }
}