using Microsoft.Extensions.Configuration;
using Collection.Infrastructure.IoC.Modules;
using Collection.Infrastructure.IoC.Modules.Repositories;
using Autofac;
using Collection.Infrastructure.Mappers;

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
            // Register Instance
            builder.RegisterInstance(AutoMapperConfig.Initialize());

            // Register Modules
            builder.RegisterModule<CommandModule>();
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule(new SettingModule(_configuration));

            builder.RegisterModule<EntityRepositoryModule>();

        }
    }
}
