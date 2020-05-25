namespace NotificationService.Domain
{
    public class OrderDeliveredDomainEvent : IDomainEvent
    {
        public OrderDeliveredDomainEvent(OrderEntity order)
        {
            Order = order;
        }

        public OrderEntity Order { get; }
    }
}
