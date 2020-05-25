namespace NotificationService.Domain
{
    public class OrderCompletedDomainEvent : IDomainEvent
    {
        public OrderCompletedDomainEvent(OrderEntity order)
        {
            Order = order;
        }

        public OrderEntity Order { get; }
    }
}
