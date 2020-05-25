using System;

namespace NotificationService.Infrastructure
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message)
            : base(message)
        {
        }
    }

    public class OrderNotFoundException : NotFoundException
    {
        public OrderNotFoundException()
            : base("Order not found.")
        {

        }
    }

    public class ProductNotFoundException : NotFoundException
    {
        public ProductNotFoundException()
            : base("Product not found.")
        {

        }
    }
}
