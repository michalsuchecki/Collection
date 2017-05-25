﻿using System.Reflection;
using Collection.Repository.Entity.DAL;
using Collection.Core.Repositories;
using Autofac;

namespace Collection.Infrastructure.IoC.Modules.Repositories
{
    public class EntityRepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(EntityDBContext)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<IRepository>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<EntityDBContext>()
                .As<IDBContext>()
                .InstancePerLifetimeScope();
        }
    }
}
