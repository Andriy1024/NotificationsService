using FluentEmail.Core;
using MediatR;
using NotificationService.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace NotificationService.Infrastructure.DomainEventHandlers
{
    public class OrderCancelledDomainEventHandler : INotificationHandler<OrderCancelledDomainEvent>
    {
        readonly IFluentEmailFactory _emailFactory;

        public OrderCancelledDomainEventHandler(IFluentEmailFactory emailFactory)
        {
            _emailFactory = emailFactory;
        }

        public async Task Handle(OrderCancelledDomainEvent domainEvent, CancellationToken cancellationToken)
        {
            await _emailFactory.Create()
                .To(domainEvent.Order.BuyerEmail)
                .Subject("Order cancelled")
                .Body("", isHtml: true)
                .SendAsync();
        }
    }
}
