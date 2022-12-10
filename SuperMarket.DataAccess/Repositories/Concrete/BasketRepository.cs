using Microsoft.EntityFrameworkCore;
using SuperMarket.DataAccess.Context;
using SuperMarket.DataAccess.Repositories.Abstract;
using SuperMarket.Entities.Models;

namespace SuperMarket.DataAccess.Repositories.Concrete
{
    public class BasketRepository : Repository<Basket>, IBasketRepository
    {
        public BasketRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}