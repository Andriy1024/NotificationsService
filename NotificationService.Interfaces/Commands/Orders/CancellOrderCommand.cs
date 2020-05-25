namespace NotificationService.Application
{
    public class CancellOrderCommand : ICommand
    {
        public long Id { get; }

        public CancellOrderCommand(long id)
            => Id = id;
    }
}
