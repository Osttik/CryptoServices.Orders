using CryptoServices.Orders.Infrastructure.Models;
using CryptoServices.Orders.Infrastructure.Shared.Services;
using CryptoServices.Shared.MessageBus.Messages;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CryptoServices.Orders.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        protected readonly IOrderService _service;
        protected readonly IPublishEndpoint _publishEndpoint;

        public OrdersController(IOrderService service, IPublishEndpoint publishEndpoint)
        {
            _service = service;
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost("proceed")]
        public async Task<IActionResult> ProceedOrder(Guid orderId)
        {
            await _publishEndpoint.Publish(new ProceedOrderMessage() { OrderId = orderId });
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _service.GetAllOrdersByUserId(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(AddOrderModel order)
        {
            return Ok(await _service.AddOrder(order));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _service.RemoveOrder(id));
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateUser(UpdateOrderModel order)
        {
            return Ok(await _service.UpdateOrder(order));
        }
    }
}
