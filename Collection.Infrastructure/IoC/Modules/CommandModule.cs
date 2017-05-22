using System.Reflection;
using Autofac;
using Collection.Infrastructure.Commands;

namespace Collection.Infrastructure.IoC.Modules
{
    public class CommandModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder build)
        {
            var assembly = typeof(CommandModule)
                .GetTypeInfo()
                .Assembly;

            build.RegisterAssemblyTypes(assembly)
                .AsClosedTypesOf(typeof(ICommandHandler<>))
                .InstancePerLifetimeScope();

            build.RegisterType<CommandDispatcher>()
                .As<ICommandDispatcher>()
                .InstancePerMatchingLifetimeScope();
        }
    }
}
