using System;

namespace NotificationService.Domain
{
    public class OrderEntity : Entity
    {
        public OrderEntity()
        {
        }

        public OrderEntity(string buyerName, string buyerEmail, string city, string adress, long payment, long productId, long cost)
        {
            BuyerName = buyerName;
            BuyerEmail = buyerEmail;
            City = city;
            Adress = adress;
            Payment = payment;
            ProductId = productId;
            Status = OrderStatus.InProgress;
            Payment = cost;
            AddDomainEvent(new OrderCreatedDomainEvent(this));
        }

        public DateTime CreatedAt { get; set; }
        public string BuyerName { get; set; }
        public string BuyerEmail { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public long Payment { get; set; }
        public long ProductId { get; set; }
        public ProductEntity Product { get; set; }
        public OrderStatus Status { get; set; }

        public void Complete()
        {
            Status = OrderStatus.Completed;
            AddDomainEvent(new OrderCompletedDomainEvent(this));
        }

        public void Cancell()
        {
            Status = OrderStatus.Cancelled;
            AddDomainEvent(new OrderCancelledDomainEvent(this));
        }
    }
}
