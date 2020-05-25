using System;

namespace NotificationService.Domain
{
    public class OrderEntity : Entity
    {
        public DateTime CreatedAt { get; set; }
        public long BuyerName { get; set; }
        public long BuyerEmail { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public long Payment { get; set; }
        public long ProductId { get; set; }
        public ProductEntity Product { get; set; }
    }
}
