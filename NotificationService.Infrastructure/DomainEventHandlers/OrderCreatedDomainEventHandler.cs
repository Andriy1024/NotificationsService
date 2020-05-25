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
    public class OrderCreatedDomainEventHandler : INotificationHandler<OrderCreatedDomainEvent>
    {
        readonly IFluentEmailFactory _emailFactory;
        readonly IRazorViewToStringRenderer _razorView;
        readonly IMapper _mapper;

        public OrderCreatedDomainEventHandler(IFluentEmailFactory emailFactory, IRazorViewToStringRenderer razorView, IMapper mapper)
        {
            _emailFactory = emailFactory;
            _razorView = razorView;
            _mapper = mapper;
        }

        public async Task Handle(OrderCreatedDomainEvent domainEvent, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<OrderModel>(domainEvent.Order);
            var view = await _razorView.RenderViewToStringAsync(Path.Combine("Views", "Orders", "OrderCreatedView.cshtml"), model);

            await _emailFactory.Create()
                .To(domainEvent.Order.BuyerEmail, domainEvent.Order.BuyerName)
                .Subject("Order created")
                .Body(view, isHtml: true)
                .SendAsync();
        }
    }
}
