using System.Linq;
using NorthWaveConsole.Application.Interfaces;
using NorthWaveConsole.Domain.Entities;
using NorthWaveConsole.Infrastructure.Persistence;

namespace NorthWaveConsole.Infrastructure.Services
{
   
    public class OrderRepository : IOrderRepository
    {
        private readonly NorthWaveDbContext _context;

        public OrderRepository(NorthWaveDbContext context)
        {
            _context = context;
        }

        public void Add(Order order)
        {
            
            _context.Orders.Add(order);
        }

        public Order GetById(int id)
        {
            
            return _context.Orders.FirstOrDefault(o => o.Id == id);
        }
    }
}
