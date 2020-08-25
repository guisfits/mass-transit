using System;
using MassTransit;
using MassTransit.RabbitMqTransport;

namespace FireOnWheels.Messaging
{
    public static class BusConfigurator
    {
        public static IBusControl ConfigureBus(Action<IRabbitMqHostConfigurator> hostConfigurator = null)
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(RabbitMqConstants.RabbitMqUri, hostConfigurator);
            });
        }
    }
}
