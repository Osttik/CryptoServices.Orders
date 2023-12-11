using CryptoServices.Data;
using CryptoServices.Data.Models;
using CryptoServices.Orders.Infrastructure.Shared.Repositories;
using MassTransit.Transports;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoServices.Orders.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        protected readonly DBContext _context;

        public OrderRepository(DBContext context)
        {
            _context = context;
        }

        public Task<List<Order>> GetAllOrdersByUserId(Guid id)
        {
            return _context.Orders.Where(o => o.UserId == id).ToListAsync();
        }

        public Order GetOrderById(Guid id)
        {
            return _context.Orders.First(o => o.Id == id);
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            _context.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> AddOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<bool> RemoveOrder(Guid id)
        {
            var order = _context.Orders.First(u => u.Id == id);
            if (order == null) return false;

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
