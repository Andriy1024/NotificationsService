namespace NotificationService.Application
{
    public class CreateOrderCommand : ICommand<long>
    {
        public long ProductId { get; }
        public string BuyerName { get; }
        public string BuyerEmail { get; }
        public string City { get; }
        public string Adress { get; }

        public CreateOrderCommand(long productId, string buyerName, string buyerEmail, string city, string adress)
        {
            ProductId = productId;
            BuyerName = buyerName;
            BuyerEmail = buyerEmail;
            City = city;
            Adress = adress;
        }        
    }
}
