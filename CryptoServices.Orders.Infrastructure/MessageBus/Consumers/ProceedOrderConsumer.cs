using CryptoServices.Orders.Infrastructure.Shared.Services;
using CryptoServices.Shared.MessageBus.Messages;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoServices.Orders.Infrastructure.MessageBus.Consumers
{
    public class ProceedOrderConsumer: IConsumer<ResponceOrderMessage>
    {
        protected readonly IOrderService _service;

        public ProceedOrderConsumer(IOrderService service)
        {
            _service = service;
        }

        public Task Consume(ConsumeContext<ResponceOrderMessage> context)
        {
            return _service.UpdateOrder(new Models.UpdateOrderModel()
            {
                Id = context.Message.OrderId,
                NewState = context.Message.State
            });
        }
    }
}
