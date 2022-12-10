using Microsoft.EntityFrameworkCore;
using SuperMarket.DataAccess.Context;
using SuperMarket.DataAccess.Repositories.Abstract;
using SuperMarket.Entities.Models;

namespace SuperMarket.DataAccess.Repositories.Concrete
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}