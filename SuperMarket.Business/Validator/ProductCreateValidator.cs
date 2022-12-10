using FluentValidation;
using SuperMarket.Core.Dtos;

namespace SuperMarket.Business.Validator
{
    public class ProductCreateValidator : AbstractValidator<ProductCreateDto>
    {
        public ProductCreateValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name bos olamaz");
            RuleFor(p => p.ProductType).NotEmpty().WithMessage("Urun tipi bos olamaz");
            RuleFor(p => p.Stock).GreaterThan(0).WithMessage("Stok miktari 0 dan buyuk olmali");
            RuleFor(p => p.Price).GreaterThan(0).WithMessage("fiyat 0 dan buyuk olmali");
        }
    }
}