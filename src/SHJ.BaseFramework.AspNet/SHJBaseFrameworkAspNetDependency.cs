using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SHJ.BaseFramework.AspNet.Attributes;
using SHJ.BaseFramework.AspNet.Mvc;
using SHJ.BaseFramework.Shared;

namespace SHJ.BaseFramework.AspNet;

public static class SHJBaseFrameworkAspNetDependency
{
    /// <summary>
    /// config and set option application
    /// builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacModule()));
    /// </summary>
    /// <param name="option"> option application</param>
    /// <returns></returns>
    public static IServiceCollection AddSHJBaseFrameworkAspNet(this IServiceCollection services, Action<BaseOptions> option)
    {
        services.Configure<BaseOptions>(option);
        services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<BaseClaimService, ClaimService>();

        services.AddMvc(mvc =>
        {
            mvc.Conventions.Add(new ControllerNameAttributeConvention());
        });

        return services;
    }

    
    /// <summary>
    /// use baseframework
    /// </summary>
    /// <returns></returns>
    public static IApplicationBuilder UseSHJBaseFrameworkAspNet(this IApplicationBuilder app)
    {
        return app;
    }
}
