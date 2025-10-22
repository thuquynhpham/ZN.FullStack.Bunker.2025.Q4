using MediatR;

namespace Bunker.Api.Handlers._Shared
{
    public interface IQuery<T> : IRequest<T> where T : QueryApiResponse<T>, new() { }

    public interface ICommand : IRequest<CommandApiResponse> { }
}
