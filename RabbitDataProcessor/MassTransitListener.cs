using MassTransit;
using RabbitDataShared;

namespace RabbitDataProcessor
{
    public class MassTransitListener
    {
        private readonly IBusControl _busControl;

        public MassTransitListener(string url)
        {
            _busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(url);

                cfg.ReceiveEndpoint("MassTransitListener", e =>
                {
                    e.Consumer<RabbitMessageConsumer>();
                });
            });

            _busControl.Start();
        }
    }
}