﻿namespace NotificationService.Domain
{
    public class OrderCreatedDomainEvent : IDomainEvent
    {
        public OrderCreatedDomainEvent(OrderEntity order)
        {
            Order = order;
        }

        public OrderEntity Order { get; }
    }
}
