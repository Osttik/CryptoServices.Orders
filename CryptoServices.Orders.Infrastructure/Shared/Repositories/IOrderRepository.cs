using CryptoServices.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoServices.Orders.Infrastructure.Shared.Repositories
{
    public interface IOrderRepository
    {
        public Task<List<Order>> GetAllOrdersByUserId(Guid id);
        public Task<Order> UpdateOrder(Order order);
        public Task<Order> AddOrder(Order order);
        public Task<bool> RemoveOrder(Guid id);
        public Order GetOrderById(Guid id);
    }
}
