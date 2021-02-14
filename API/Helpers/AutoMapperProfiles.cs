using API.DTOs;
using API.Entities;
using AutoMapper;
using System.Linq;

namespace API.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<ProductType, ProductTypeDto>();

            CreateMap<Seller, SellerDto>();
            
            CreateMap<Product, ProductDto>();

            CreateMap<Cart, CartDto>();
            
            CreateMap<Carty, CartyDto>();
            
        }
    }
}