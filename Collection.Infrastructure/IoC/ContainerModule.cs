using Microsoft.Extensions.Configuration;
using Collection.Infrastructure.IoC.Modules;
using Autofac;

namespace Collection.Infrastructure.IoC
{
    public class ContainerModule : Module
    {
        private readonly IConfiguration _configuration;
  
        public ContainerModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            // Register Modules
            builder.RegisterModule<CommandModule>();
            builder.RegisterModule<ServiceModule>();

        }
    }
}
