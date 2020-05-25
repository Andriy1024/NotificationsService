using FluentEmail.Core;
using MediatR;
using NotificationService.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace NotificationService.Infrastructure.DomainEventHandlers
{
    public class OrderCreatedDomainEventHandler : INotificationHandler<OrderCreatedDomainEvent>
    {
        readonly IFluentEmailFactory _emailFactory;

        public OrderCreatedDomainEventHandler(IFluentEmailFactory emailFactory)
        {
            _emailFactory = emailFactory;
        }

        public async Task Handle(OrderCreatedDomainEvent domainEvent, CancellationToken cancellationToken)
        {
            await _emailFactory.Create()
                .To(domainEvent.Order.BuyerEmail, domainEvent.Order.BuyerName)
                .Subject("Order created")
                .Body("", isHtml: true)
                .SendAsync();
        }
    }
}
