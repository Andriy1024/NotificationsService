namespace NotificationService.Application
{
    public class OrderDto
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public long Payment { get; set; }
        public long BuyerName { get; set; }
        public long BuyerEmail { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
    }
}
