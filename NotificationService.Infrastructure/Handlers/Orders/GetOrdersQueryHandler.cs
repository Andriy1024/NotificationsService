using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NotificationService.Application;
using NotificationService.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NotificationService.Infrastructure.Handlers
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, OrderDto[]>
    {
        readonly IMapper _mapper;
        readonly ApplicationDbContext _dbContext;

        public GetOrdersQueryHandler(IMapper mapper, ApplicationDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public Task<OrderDto[]> Handle(GetOrdersQuery query, CancellationToken cancellationToken)
            =>  _dbContext.Orders
                .Where(t => (string.IsNullOrEmpty(query.City) || t.City == query.City &&
                             string.IsNullOrEmpty(query.Email) || t.BuyerEmail == query.Email &&
                             !query.ProductId.HasValue || t.ProductId == query.ProductId.Value))
                .ProjectTo<OrderDto>(_mapper.ConfigurationProvider)
                .ToArrayAsync(cancellationToken);
    }
}
