using AutoMapper;
using SuperMarket.Business.Abstract;
using SuperMarket.Core.Dtos;
using SuperMarket.Core.Utilities.Results;
using SuperMarket.DataAccess.Repositories.Abstract;
using SuperMarket.Entities.Models;

namespace SuperMarket.Business.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper = null)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<Product>> GetByIdAsync(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);

            if (product != null)
            {
                return new SuccessDataResult<Product>(product);
            }

            return new ErrorDataResult<Product>("Urun bulunamadi");
        }

        public async Task<IDataResult<Product>> SaveAsync(ProductCreateDto productCreateDto)
        {
            try
            {
                var product = _mapper.Map<Product>(productCreateDto);

                var result = await _unitOfWork.Products.AddAsync(product);
                await _unitOfWork.SaveAsync();

                return new SuccessDataResult<Product>(result);
            }
            catch
            {
                return new ErrorDataResult<Product>("Urun olusturulurken bir hata meydana geldi");
            }
        }
    }
}