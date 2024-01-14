using OrderTest.Domain.Models;
using OrderTest.Domain.UnitOfWork.GenericRepository;

namespace OrderTest.Domain.UnitOfWork
{
    public class UnitOfWork(ApplicationDbContext context) : IDisposable
    {
        private readonly ApplicationDbContext _context = context;
        private GenericRepository<Order>? _orderRepository;

        public GenericRepository<Order> OrderRepository {
            get 
            {
                _orderRepository ??= new GenericRepository<Order>(_context);
                return _orderRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing) 
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
