using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Mediator
{
    public class ApplicationMediator : IApplicationMediator
    {
        private readonly ILifetimeScope _scope;

        public ApplicationMediator(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public async Task<TReturn> SendAsync<TReturn>(IRequest<TReturn> request)
        {
            var handler = _scope.Resolve<IRequestHandler<IRequest<TReturn>, TReturn>>();

            return await handler.HandleAsync(request);
        }
    }
}
