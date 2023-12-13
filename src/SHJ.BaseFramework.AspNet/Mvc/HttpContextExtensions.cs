using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SHJ.BaseFramework.Shared;

namespace SHJ.BaseFramework.AspNet.Mvc;

public static class HttpContextExtensions
{
    public static string GetTenantId(this HttpContext httpContext)
    {
        httpContext.Request.Headers.TryGetValue("tenantId", out var tenantId);
        if (!string.IsNullOrEmpty(tenantId))
        {
            return tenantId;
        }
        return string.Empty;
    }

    public static IConfiguration GetBaseConfiguration(this HttpContext httpContext) =>
    (IConfiguration)httpContext.RequestServices.GetService(typeof(IConfiguration));
    public static BaseClaimService GetBaseClaims(this HttpContext httpContext) =>
         (BaseClaimService)httpContext.RequestServices.GetService(typeof(BaseClaimService));
    public static string GetBaseIpAddress(this HttpContext httpContext) =>
        httpContext.Connection.RemoteIpAddress.ToString();
    public static string GetBaseLocalIpAddress(this HttpContext httpContext) =>
        httpContext.Connection.LocalIpAddress.ToString();
    public static BaseHttpContextInfo GetBaseClientInfo(this HttpContext httpContext)
    {
        return new BaseHttpContextInfo(httpContext.GetTenantId(),
            httpContext.GetBaseLocalIpAddress(), httpContext.GetBaseIpAddress());
    }
    public static BaseOptions GetValueBaseOptions(this IConfiguration configuration)
    {
        return configuration.GetSection("Options").Get<BaseOptions>();
    }
    public static BaseSqlServerOptions GetValueBaseSqlOptions(this IConfiguration configuration)
    {
        return configuration.GetSection("SqlOptions").Get<BaseSqlServerOptions>();
    }
    
}

