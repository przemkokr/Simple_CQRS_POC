using MediatR;

namespace Simple_CQRS_POC.Application.Configuration.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
    { }
}
