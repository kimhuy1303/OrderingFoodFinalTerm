using AutoMapper;
using OrderingFoodFinalTerm.DTO;
using System.Diagnostics.Eventing.Reader;

namespace OrderingFoodFinalTerm.Helper
{
    public class MapperApplication : Profile
    {
        public MapperApplication() 
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
        }

    }
}
