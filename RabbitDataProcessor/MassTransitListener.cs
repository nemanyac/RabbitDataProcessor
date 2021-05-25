using System;
using MassTransit;

namespace RabbitDataProcessor
{
    public class MassTransitListener
    {
        private readonly IBusControl _busControl;

        public MassTransitListener(string url)
        {
            var guid = System.Environment.MachineName;
            Console.WriteLine($"Processor constructor: {guid}");
            _busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(url);

                cfg.ReceiveEndpoint($"Listener_{guid}", e =>
                {
                    e.Consumer<RabbitMessageConsumer>();
                });
            });

            _busControl.Start();
            Console.WriteLine("Processor started");
        }
    }
}
