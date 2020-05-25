using AutoMapper;
using NotificationService.Domain;

namespace NotificationService.Application
{
    public class OrderMapper : Profile
    {
        public OrderMapper()
        {
            CreateMap<OrderEntity, OrderDto>();
            CreateMap<CreateOrderCommand, OrderEntity>();
            CreateMap<OrderEntity, OrderModel>()
                .ForMember(model => model.ProductName, value => value.MapFrom(entity => entity.Product.Name));
        }
    }
}
