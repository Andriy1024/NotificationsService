using MediatR;
using Microsoft.EntityFrameworkCore;
using NotificationService.Application;
using NotificationService.Domain;
using NotificationService.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace NotificationService.Infrastructure.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, long>
    {
        readonly ApplicationDbContext _dbContext;

        public CreateOrderCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<long> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Produts.FirstOrDefaultAsync(t => t.Id == command.ProductId, cancellationToken);
            if (product == null)
                throw new ProductNotFoundException();

            var newOrder = new OrderEntity(command.BuyerName, command.BuyerEmail, command.City, command.Adress, product.Cost, command.ProductId);
            newOrder.Payment = product.Cost;
            newOrder.AddDomainEvent(new OrderCreatedDomainEvent(newOrder));
            _dbContext.Orders.Add(newOrder);
            await _dbContext.SaveEntitiesAsync();
            return newOrder.Id;
        }
    }
}
