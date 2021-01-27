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
            CreateMap<Cart, CartDto>();
            
            CreateMap<Carty, CartyDto>();
            
        }
    }
}