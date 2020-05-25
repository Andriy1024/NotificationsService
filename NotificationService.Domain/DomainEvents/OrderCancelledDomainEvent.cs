namespace NotificationService.Domain
{
    public class OrderCancelledDomainEvent : IDomainEvent
    {
        public OrderCancelledDomainEvent(OrderEntity order)
        {
            Order = order;
        }

        public OrderEntity Order { get; }
    }
}
