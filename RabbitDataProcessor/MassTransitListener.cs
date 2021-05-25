using System;
using MassTransit;

namespace RabbitDataProcessor
{
    public class MassTransitListener
    {
        private readonly IBusControl _busControl;

        public MassTransitListener(string url)
        {
            Console.WriteLine($"Processor constructor: {url}");
            _busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(url);

                cfg.ReceiveEndpoint("MassTransitListener", e =>
                {
                    e.Consumer<RabbitMessageConsumer>();
                });
            });

            _busControl.Start();
            Console.WriteLine("Processor started");
        }
    }
}