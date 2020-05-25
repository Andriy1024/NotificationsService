using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NotificationService.Application;
using NotificationService.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace NotificationService.Infrastructure.Handlers
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
    {
        readonly IMapper _mapper;
        readonly ApplicationDbContext _dbContext;

        public GetOrderByIdQueryHandler(IMapper mapper, ApplicationDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<OrderDto> Handle(GetOrderByIdQuery query, CancellationToken cancellationToken)
        {
            var orderDto = await _dbContext.Orders.ProjectTo<OrderDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(t => t.Id == query.Id, cancellationToken);
            if (orderDto == null)
                throw new OrderNotFoundException();

            return orderDto;
        }
    }
}
