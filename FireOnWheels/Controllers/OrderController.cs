using System;
using System.Threading.Tasks;
using FireOnWheels.Messaging;
using FireOnWheels.Registration.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FireOnWheels.Registration.Controllers
{
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> RegisterOrder(OrderInputModel model)
        {
            var bus = BusConfigurator.ConfigureBus();

            var sendToUri = new Uri(RabbitMqConstants.RabbitMqUri + RabbitMqConstants.RegisterOrderServiceQueue);
            var endPoint = await bus.GetSendEndpoint(sendToUri);
            await endPoint.Send<IRegisterOrderCommand>(model);

            return Created("", model);
        }
    }
}
