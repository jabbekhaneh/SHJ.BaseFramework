using Autofac;
using SHJ.BaseFramework.DependencyInjection.Contracts;

namespace SHJ.BaseFramework.DependencyInjection.Modules;
public class AutofacModule : Autofac.Module
{
    protected override void Load(ContainerBuilder containerBuilder)
    {

        containerBuilder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                 .AssignableTo<IScopedDependency>()
                 .AsImplementedInterfaces()
                 .InstancePerLifetimeScope();

        containerBuilder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
            .AssignableTo<ITransientDependency>()
            .AsImplementedInterfaces()
            .InstancePerDependency();

        containerBuilder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
            .AssignableTo<ISingletonDependency>()
            .AsImplementedInterfaces()
            .SingleInstance();
    }
}