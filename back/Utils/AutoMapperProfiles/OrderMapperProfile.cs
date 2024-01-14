using AutoMapper;
using OrderTest.Domain.Models;
using OrderTest.Models;

namespace OrderTest.Utils.AutoMapperProfiles
{
    public class OrderMapperProfile : Profile
    {
        public OrderMapperProfile() 
        {
            CreateMap<Order, OrderModel>().ReverseMap();
        }
    }
}
