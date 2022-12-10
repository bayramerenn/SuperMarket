using Microsoft.EntityFrameworkCore;
using SuperMarket.DataAccess.Context;
using SuperMarket.DataAccess.Repositories.Abstract;
using SuperMarket.Entities.Models;

namespace SuperMarket.DataAccess.Repositories.Concrete
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}