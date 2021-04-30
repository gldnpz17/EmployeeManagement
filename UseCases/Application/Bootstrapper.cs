using Application.Common.Configuration;
using Autofac;
using DomainModel.Services;
using DomainServiceImplementation;
using EFCoreInMemory;
using MediatR;
using MediatR.Extensions.Autofac.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class Bootstrapper
    {
        public IMediator Mediator { get; }

        private readonly ILifetimeScope _scope;

        private readonly ApplicationConfig _config;

        public Bootstrapper(ApplicationConfig config)
        {
            _config = config;

            var container = RegisterDependencies();
            _scope = container.BeginLifetimeScope();

            Mediator = _scope.Resolve<IMediator>();
        }

        private IContainer RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            // Register mediator.
            builder.RegisterMediatR(Assembly.GetExecutingAssembly());

            // Register global configuration.
            builder.RegisterInstance(_config).As<ApplicationConfig>().SingleInstance();

            // Register database.
            if (_config.Environment == TypeOfEnvironment.Development)
            {
                builder.Register(context => new EmployeeManagementDbContext("DevelopmentDatabase")).AsSelf();
            }

            // Register DateTime service.
            builder.RegisterInstance(new UtcDateTimeService()).As<IDateTimeService>().SingleInstance();

            return builder.Build();
        }
    }
}
