using Autofac;
using Collection.Core.Repositories;
using Collection.Infrastructure.Services;
using Collection.Repository.Entity.Repositories;

namespace Collection.Infrastructure.IoC.Modules
{
    public class ImageModule : Autofac.Module
    {

        protected override void Load(ContainerBuilder builder)
        { 
            builder.RegisterType<ImageRepository>()
                    .As<IImageRepository>()
                    .InstancePerLifetimeScope();

            builder.RegisterType<LocalImageProvider>()
                    .As<IImageProvider>()
                    .SingleInstance();

            builder.RegisterType<ImageService>()
                    .As<IImageService>()
                    .SingleInstance();
        }
    }
}