using MediatR;

namespace NotificationService.Application
{
    public interface IQuery<TResult> : IRequest<TResult>
    {
    }
}
