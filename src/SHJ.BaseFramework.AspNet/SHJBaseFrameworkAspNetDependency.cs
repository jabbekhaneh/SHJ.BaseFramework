﻿using Autofac.Extensions.DependencyInjection;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SHJ.BaseFramework.DependencyInjection.Modules;
using SHJ.BaseFramework.Shared;
using SHJ.BaseFramework.Shared.CustomMappings;

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
        services.AddScoped<IBaseClaimService, ClaimService>();
        services.InitializeAutoMapper();
        services.AddMvc(mvc =>
        {
            mvc.Conventions.Add(new BaseControllerNameAttributeConvention());
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

    /// <summary>
    /// Configuration Autofact
    /// </summary>
    /// <returns></returns>
    public static IHostBuilder UseAutofac(this IHostBuilder hostBuilder)
       => hostBuilder.UseServiceProviderFactory(new AutofacServiceProviderFactory())
                  .ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacModule()));
}
