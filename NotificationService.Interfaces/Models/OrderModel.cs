using System;

namespace NotificationService.Application
{
    public class OrderModel
    {
        public string Icon { get; set; } = "http://32d94bad36e3.ngrok.io";
        public string BuyerName { get; set; }
        public string ProductName { get; set; }
        public long Payment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
