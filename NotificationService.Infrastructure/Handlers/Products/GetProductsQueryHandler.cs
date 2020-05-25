using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NotificationService.Application;
using NotificationService.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NotificationService.Infrastructure.Handlers.Orders
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductDto>>
    {
        readonly ApplicationDbContext _dbContext;
        readonly IMapper _mapper;

        public GetProductsQueryHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _dbContext.Produts.ToListAsync();
            var response = _mapper.Map<IEnumerable<ProductDto>>(products);
            return response;
        }
    }
}
