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
            var localImages = new LocalImages();
            _configuration.GetSection("images:local").Bind(localImages);

            builder.RegisterInstance(localImages)
                    .SingleInstance();

        }

    }
}