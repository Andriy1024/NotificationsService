namespace NotificationService.Application
{
    public class GetOrderByIdQuery : IQuery<OrderDto>
    {
        public long Id { get; }

        public GetOrderByIdQuery(long id)
        {
            Id = id;
        }
    }
}
