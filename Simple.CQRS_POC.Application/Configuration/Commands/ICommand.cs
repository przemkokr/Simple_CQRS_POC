using MediatR;

namespace Simple_CQRS_POC.Application.Configuration.Commands
{
    public interface ICommand : IRequest
    {
        Guid Id { get; }
    }

    public interface ICommand<TResult> : IRequest<TResult>
    {
        Guid Id { get; }
    }
}
