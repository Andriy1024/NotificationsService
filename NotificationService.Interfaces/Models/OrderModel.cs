using System;

namespace NotificationService.Application
{
    public class OrderModel
    {
        public string BuyerName { get; set; }
        public string ProductName { get; set; }
        public long Payment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
