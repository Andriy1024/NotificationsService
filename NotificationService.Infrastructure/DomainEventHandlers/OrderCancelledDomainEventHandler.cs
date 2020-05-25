using AutoMapper;
using FluentEmail.Core;
using MediatR;
using NotificationService.Application;
using NotificationService.Domain;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace NotificationService.Infrastructure.DomainEventHandlers
{
    public class OrderCancelledDomainEventHandler : INotificationHandler<OrderCancelledDomainEvent>
    {
        readonly IFluentEmailFactory _emailFactory;
        readonly IRazorViewToStringRenderer _razorView;
        readonly IMapper _mapper;

        public OrderCancelledDomainEventHandler(IFluentEmailFactory emailFactory, IRazorViewToStringRenderer razorView, IMapper mapper)
        {
            _emailFactory = emailFactory;
            _razorView = razorView;
            _mapper = mapper;
        }

        public async Task Handle(OrderCancelledDomainEvent domainEvent, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<OrderModel>(domainEvent.Order);
            var view = await _razorView.RenderViewToStringAsync(Path.Combine("Views", "Orders", "OrderCancelledView.cshtml"), model);

            await _emailFactory.Create()
                .To(domainEvent.Order.BuyerEmail)
                .Subject("Order cancelled")
                .Body(view, isHtml: true)
                .SendAsync();
        }
    }
}
