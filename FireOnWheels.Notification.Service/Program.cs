using System;
using System.Threading.Tasks;
using FireOnWheels.Messaging;
using MassTransit;

namespace FireOnWheels.Notification.Service
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.Title = "Notification";

            var bus = Bus.Factory.CreateUsingRabbitMq(config =>
            {
                config.ReceiveEndpoint(RabbitMqConstants.NotificationServiceQueue, e =>
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
