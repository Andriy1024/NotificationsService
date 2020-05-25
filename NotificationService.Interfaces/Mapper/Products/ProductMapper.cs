using AutoMapper;
using NotificationService.Domain;

namespace NotificationService.Application
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<ProductEntity, ProductDto>();
        }
    }
}
