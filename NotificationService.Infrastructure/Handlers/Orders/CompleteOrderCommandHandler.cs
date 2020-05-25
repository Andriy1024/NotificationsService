using AutoMapper;
using MediatR;
using NotificationService.Application;
using NotificationService.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace NotificationService.Infrastructure.Handlers
{
    public class CompleteOrderCommandHandler : IRequestHandler<CompleteOrderCommand, Unit>
    {
        readonly ApplicationDbContext _dbContext;
        readonly IMapper _mapper;

        public CompleteOrderCommandHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CompleteOrderCommand command, CancellationToken cancellationToken)
        {
            var order = await _dbContext.Orders.FindAsync(command.Id);
            if (order == null)
                throw new OrderNotFoundException();

            order.Complete();
            await _dbContext.SaveEntitiesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}

