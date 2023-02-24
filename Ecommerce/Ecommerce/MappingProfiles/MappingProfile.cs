using AutoMapper;
using Ecommerce.Models;
using Ecommerce.ViewModels;

namespace Ecommerce.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductViewModel, Product>();
        }
    }
}
