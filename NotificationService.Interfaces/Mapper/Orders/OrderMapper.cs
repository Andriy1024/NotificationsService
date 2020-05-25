using AutoMapper;
using NotificationService.Domain;

namespace NotificationService.Application
{
    public class OrderMapper : Profile
    {
        public OrderMapper()
        {
            CreateMap<OrderEntity, OrderDto>();
        }
    }
}
