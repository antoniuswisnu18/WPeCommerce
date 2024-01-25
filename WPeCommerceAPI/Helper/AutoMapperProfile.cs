using AutoMapper;
using WPeCommerceAPI.DataLayer.DTO;
using WPeCommerceAPI.DataLayer.Models;

namespace WPeCommerceAPI.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>();
        }
    }
}
