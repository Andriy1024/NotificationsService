namespace NotificationService.Application
{
    public class CompleteOrderCommand : ICommand
    {
        public long Id { get; }

        public CompleteOrderCommand(long id)
            => Id = id;
    }
}
