using MediatR;
using NotificationService.Application;
using NotificationService.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace NotificationService.Infrastructure.Handlers
{
    public class CancellOrderCommandHandler : IRequestHandler<CancellOrderCommand, Unit>
    {
        readonly ApplicationDbContext _dbContext;

        public CancellOrderCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(CancellOrderCommand command, CancellationToken cancellationToken)
        {
            var order = await _dbContext.Orders.FindAsync(command.Id);
            if (order == null)
                throw new OrderNotFoundException();

            order.Cancell();
            await _dbContext.SaveEntitiesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
