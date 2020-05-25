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
    public class OrderCompletedDomainEventHandler : INotificationHandler<OrderCompletedDomainEvent>
    {
        readonly IFluentEmailFactory _emailFactory;
        readonly IRazorViewToStringRenderer _razorView;
        readonly IMapper _mapper;

        public OrderCompletedDomainEventHandler(IFluentEmailFactory emailFactory, IRazorViewToStringRenderer razorView, IMapper mapper)
        {
            _emailFactory = emailFactory;
            _razorView = razorView;
            _mapper = mapper;
        }

        public async Task Handle(OrderCompletedDomainEvent domainEvent, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<OrderModel>(domainEvent.Order);
            var view = await _razorView.RenderViewToStringAsync(Path.Combine("Views", "Orders", "OrderCompletedView.cshtml"), model);

            await _emailFactory.Create()
                .To(domainEvent.Order.BuyerEmail, domainEvent.Order.BuyerName)
                .Subject("Order completed")
                .Body(view, isHtml: true)
                .SendAsync();
        }
    }
}
