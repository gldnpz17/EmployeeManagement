using System.Threading.Tasks;

namespace Application.Common.Mediator
{
    public interface IApplicationMediator
    {
        Task<TReturn> SendAsync<TReturn>(IRequest<TReturn> request);
    }
}