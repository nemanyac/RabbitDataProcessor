using MassTransit;
using RabbitDataShared;

namespace RabbitDataPublisher
{
    public class MassTransitPublisher
    {
        private readonly IBusControl _busControl;
        private readonly string _sender;

        public MassTransitPublisher(string url, string sender)
        {
            _sender = sender;

            _busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host(url);
                }
            );

            _busControl.Start();
            _busControl.Publish<RabbitMessage>(new RabbitMessage
            {
                Sender = _sender,
                Content = "Starting publisher for " + _sender
            });
        }

        public void Publish(string message)
        {
            _busControl.Publish<RabbitMessage>(new RabbitMessage
            {
                Sender = _sender,
                Content = message
            });
        }

      }
}