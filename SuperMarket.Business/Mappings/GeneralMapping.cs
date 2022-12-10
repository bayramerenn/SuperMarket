using AutoMapper;
using SuperMarket.Core.Dtos;
using SuperMarket.Entities.Models;

namespace SuperMarket.Business.Mappings
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Product, ProductCreateDto>().ReverseMap();
        }
    }
}