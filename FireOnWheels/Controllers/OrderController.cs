using System;
using System.Threading.Tasks;
using FireOnWheels.Messaging;
using FireOnWheels.Registration.ViewModels;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace FireOnWheels.Registration.Controllers
{
    [ApiController]
    public class OrderController : ControllerBase
    {
        #region Constructor
        private readonly IPublishEndpoint publisher;

        public OrderController(IPublishEndpoint publisher)
        {
            this.publisher = publisher;
        }

        #endregion

        [HttpPost]
        public async Task<IActionResult> RegisterOrder(OrderInputModel model)
        {
            await publisher.Publish<IRegisterOrderCommand>(model);

            return Created("", model);
        }
    }
}
