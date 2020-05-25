using NotificationService.Domain;

namespace NotificationService.Application
{
    public class OrderDto
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public long Payment { get; set; }
        public string BuyerName { get; set; }
        public string BuyerEmail { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public OrderStatus Status { get; set; }
    }
}
