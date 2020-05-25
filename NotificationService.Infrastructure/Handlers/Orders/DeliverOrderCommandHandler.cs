using AutoMapper;
using MediatR;
using NotificationService.Application;
using NotificationService.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NotificationService.Infrastructure.Handlers
{
    public class DeliverOrderCommandHandler : IRequestHandler<DeliverOrderCommand, Unit>
    {
        readonly ApplicationDbContext _dbContext;
        readonly IMapper _mapper;

        public DeliverOrderCommandHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeliverOrderCommand command, CancellationToken cancellationToken)
        {
            var order = await _dbContext.Orders.FindAsync(command.Id);
            if (order == null)
                throw new OrderNotFoundException();

            order.Deliver();
            await _dbContext.SaveEntitiesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}

