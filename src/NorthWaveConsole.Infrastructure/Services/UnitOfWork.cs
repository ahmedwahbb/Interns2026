using NorthWaveConsole.Application.Interfaces;
using NorthWaveConsole.Infrastructure.Persistence;

namespace NorthWaveConsole.Infrastructure.Services
{
   
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NorthWaveDbContext _context;
        private readonly OrderRepository _orderRepository;

        public IOrderRepository Orders => _orderRepository;

        public UnitOfWork(NorthWaveDbContext context)
        {
            _context = context;
            _orderRepository = new OrderRepository(context);
        }

        
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            // y2taber => garbage collector
        }
    }
}
