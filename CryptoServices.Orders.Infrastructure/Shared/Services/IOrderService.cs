using CryptoServices.Data.Models;
using CryptoServices.Orders.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoServices.Orders.Infrastructure.Shared.Services
{
    public interface IOrderService
    {
        public Task<List<Order>> GetAllOrdersByUserId(Guid id);
        public Task<Order> UpdateOrder(UpdateOrderModel updateOrder);
        public Task<Order> AddOrder(AddOrderModel newOrder);
        public Task<bool> RemoveOrder(Guid id);
    }
}
