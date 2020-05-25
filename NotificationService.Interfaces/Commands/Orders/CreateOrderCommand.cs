namespace NotificationService.Application
{
    public class CreateOrderCommand : ICommand<long>
    {
        public long ProductId { get; set; }
        public string BuyerName { get; set; }
        public string BuyerEmail { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
    }
}
