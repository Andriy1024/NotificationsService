namespace NotificationService.Application
{
    public class DeliverOrderCommand : ICommand
    {
        public long Id { get; }

        public DeliverOrderCommand(long id)
            => Id = id;
    }
}
