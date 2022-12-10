using SuperMarket.DataAccess.Context;
using SuperMarket.DataAccess.Repositories.Abstract;

namespace SuperMarket.DataAccess.Repositories.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private ProductRepository _productRepository;
        private BasketRepository _basketRepository;
        private InvoiceRepository _invoiceRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IProductRepository Products => _productRepository ??= new ProductRepository(_context);
        public IBasketRepository Baskets => _basketRepository ??= new BasketRepository(_context);

        public IInvoiceRepository Invoices => _invoiceRepository ??= new InvoiceRepository(_context);

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}