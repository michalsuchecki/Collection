using System.Reflection;
using Autofac;
using Collection.Infrastructure.Services;

namespace Collection.Infrastructure.IoC.Modules
{
    class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(ServiceModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<IServices>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterModule<ImageModule>();
        }
    }
}
