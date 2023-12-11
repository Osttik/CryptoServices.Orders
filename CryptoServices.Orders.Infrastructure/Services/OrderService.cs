using CryptoServices.Data;
using CryptoServices.Data.Models;
using CryptoServices.Orders.Infrastructure.Models;
using CryptoServices.Orders.Infrastructure.Shared.Repositories;
using CryptoServices.Orders.Infrastructure.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoServices.Orders.Infrastructure.Services
{
    public class OrderService: IOrderService
    {
        protected readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Order>> GetAllOrdersByUserId(Guid id)
        {
            return _repository.GetAllOrdersByUserId(id);
        }

        public Task<Order> UpdateOrder(UpdateOrderModel updateOrder)
        {
            var order = _repository.GetOrderById(updateOrder.Id);

            if (updateOrder.NewState != string.Empty) order.CurrentState = updateOrder.NewState;

            return _repository.UpdateOrder(order);
        }

        public Task<Order> AddOrder(AddOrderModel newOrder)
        {
            var orderEntity = new Order()
            {
                CurrentState = "Standalone",
                UserId = newOrder.UserId
            };

            return _repository.AddOrder(orderEntity);
        }

        public Task<bool> RemoveOrder(Guid id)
        {
            return _repository.RemoveOrder(id);
        }
    }
}
