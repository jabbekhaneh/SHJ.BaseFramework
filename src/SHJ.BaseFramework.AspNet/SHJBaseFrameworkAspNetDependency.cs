using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SHJ.BaseFramework.AspNet.Mvc;
using SHJ.BaseFramework.Shared;

namespace SHJ.BaseFramework.AspNet;

public static class SHJBaseFrameworkAspNetDependency
{

    public static IServiceCollection AddSHJBaseFrameworkAspNet(IServiceCollection services)
    {
        services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<BaseClaimService, ClaimService>();
        return services;
    }
}
