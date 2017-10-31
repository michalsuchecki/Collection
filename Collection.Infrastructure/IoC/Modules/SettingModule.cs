using Autofac;
using Collection.Infrastructure.Extensions;
using Collection.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;

namespace Collection.Infrastructure.IoC.Modules
{
    public class SettingModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public SettingModule(IConfiguration configuration)
        {

            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration.GetSettings<LocalImagesSettings>())
                   .SingleInstance();

            builder.RegisterInstance(_configuration.GetSettings<GeneralSettings>())
                   .SingleInstance();

            //builder.RegisterInstance(_configuration.GetSettings<DatabaseSettings>())
            //       .SingleInstance();
        }


    }
}