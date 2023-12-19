using Autofac;

namespace SHJ.BaseFramework.DependencyInjection.Modules;

public abstract class BaseFrameworkModule : Autofac.Module
{
    protected abstract override void Load(ContainerBuilder containerBuilder);
}
