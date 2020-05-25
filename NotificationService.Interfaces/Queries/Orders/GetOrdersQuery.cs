namespace NotificationService.Application
{
    public class GetOrdersQuery : IQuery<OrderDto[]>
    {
        public long? ProductId { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
    }
}
