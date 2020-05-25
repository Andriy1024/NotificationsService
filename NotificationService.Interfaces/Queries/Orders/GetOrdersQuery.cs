namespace NotificationService.Application
{
    public class GetOrdersQuery : IQuery<OrderDto>
    {
        public long ProductId { get; set; }
        public long Email { get; set; }
        public string City { get; set; }
    }
}
