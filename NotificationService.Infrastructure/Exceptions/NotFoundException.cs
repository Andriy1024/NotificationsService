using System;

namespace NotificationService.Infrastructure
{
    public class NotFoundException : Exception
    {
    }

    public class OrderNotFoundException : Exception
    {
        public OrderNotFoundException()
            : base("Order not found.")
        {

        }
    }
}
