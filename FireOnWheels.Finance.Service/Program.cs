using System;
using System.Threading.Tasks;
using FireOnWheels.Messaging;
using MassTransit;

namespace FireOnWheels.Finance.Service
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.Title = "Finance";

            var bus = BusConfigurator.ConfigureBus(cfg =>
            {
                cfg.ReceiveEndpoint(RabbitMqConstants.FinanceServiceQueue, e =>
                {
                    e.Consumer<OrderRegisteredConsumer>();
                });
            });

            await bus.StartAsync();

            Console.WriteLine("Listening for Order registered events.. Press enter to exit");
            Console.ReadLine();

            await bus.StopAsync();
        }
    }
}
