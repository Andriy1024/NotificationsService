using FluentEmail.Core;
using MediatR;
using NotificationService.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace NotificationService.Infrastructure.DomainEventHandlers
{
    public class OrderDeliveredDomainEventHandler : INotificationHandler<OrderDeliveredDomainEvent>
    {
        readonly IFluentEmailFactory _emailFactory;

        public OrderDeliveredDomainEventHandler(IFluentEmailFactory emailFactory)
        {
            _emailFactory = emailFactory;
        }

        public async Task Handle(OrderDeliveredDomainEvent domainEvent, CancellationToken cancellationToken)
        {
            await _emailFactory.Create()
                .To(domainEvent.Order.BuyerEmail, domainEvent.Order.BuyerName)
                .Subject("Order delivered")
                .SendAsync();
        }
    }
}
