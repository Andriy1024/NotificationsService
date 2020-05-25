namespace NotificationService.Domain
{
    public class OrderAcceptedDomainEvent : IDomainEvent
    {
        public OrderAcceptedDomainEvent(OrderEntity order)
        {
            Order = order;
        }

        public OrderEntity Order { get; }
    }
}
