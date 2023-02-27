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

            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();

            CreateMap<Cart, CartViewModel>();
            CreateMap<CartViewModel, Cart>();

            CreateMap<CartProduct, Product>();
            CreateMap<Cart, CartProduct>();

        }
    }
}
