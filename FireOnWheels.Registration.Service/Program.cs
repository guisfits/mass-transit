using System;
using System.Threading.Tasks;
using FireOnWheels.Messaging;
using MassTransit;

namespace FireOnWheels.Registration.Service
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.Title = "Registration";

            var bus = BusConfigurator.ConfigureBus(cfg =>
            {
                cfg.ReceiveEndpoint(RabbitMqConstants.RegisterOrderServiceQueue, e =>
                {
                    e.Consumer<RegisterOrderCommandConsumer>();
                });
            });

            await bus.StartAsync();

            Console.WriteLine("Listening for Register order commands.. Press enter to exit");
            Console.ReadLine();

            await bus.StopAsync();
        }
    }
}
