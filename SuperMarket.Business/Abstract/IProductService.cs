using SuperMarket.Core.Dtos;
using SuperMarket.Core.Utilities.Results;
using SuperMarket.Entities.Models;

namespace SuperMarket.Business.Abstract
{
    public interface IProductService
    {
        Task<IDataResult<Product>> GetByIdAsync(int id);
        Task<IDataResult<Product>> SaveAsync(ProductCreateDto productCreateDto);
    }
}