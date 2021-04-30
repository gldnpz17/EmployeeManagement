using Application.Common.Configuration;
using Application.Common.Mediator;
using Autofac;
using DomainModel.Services;
using DomainServiceImplementation;
using EFCoreInMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class Bootstrapper
    {
        public IApplicationMediator Mediator { get; }

        private readonly ILifetimeScope _scope;

        private readonly ApplicationConfig _config;

        public Bootstrapper(ApplicationConfig config)
        {
            _config = config;

            var container = RegisterDependencies();
            _scope = container.BeginLifetimeScope();

            Mediator = _scope.Resolve<IApplicationMediator>(new TypedParameter(typeof(ILifetimeScope), _scope));
        }

        private IContainer RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            // Register mediator.
            builder.RegisterType<ApplicationMediator>().As<IApplicationMediator>().SingleInstance();

            // Register request handlers.
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.IsAssignableFrom(typeof(IRequestHandler<,>)))
                .AsSelf()
                .InstancePerDependency();

            // Register global configuration.
            builder.RegisterInstance(_config).As<ApplicationConfig>().SingleInstance();

            // Register database.
            if (_config.Environment == TypeOfEnvironment.Development)
            {
                builder.Register(context => new EmployeeManagementDbContext("DevelopmentDatabase")).AsSelf();
            }

            // Register DateTime service.
            builder.RegisterInstance(new DateTimeService()).As<IDateTimeService>().SingleInstance();

            return builder.Build();
        }
    }
}
