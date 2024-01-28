using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SHJ.BaseFramework.Shared;

namespace Microsoft.AspNetCore.Mvc;

public static class HttpContextExtensions
{
    
    public static IConfiguration GetBaseConfiguration(this HttpContext httpContext) =>
    (IConfiguration)httpContext.RequestServices.GetService(typeof(IConfiguration));
    public static IBaseClaimService GetBaseClaims(this HttpContext httpContext) =>
         (IBaseClaimService)httpContext.RequestServices.GetService(typeof(IBaseClaimService));
    public static string GetBaseIpAddress(this HttpContext httpContext) =>
        httpContext.Connection.RemoteIpAddress.ToString();
    public static string GetBaseLocalIpAddress(this HttpContext httpContext) =>
        httpContext.Connection.LocalIpAddress.ToString();
    
    
    public static BaseHttpContextInfo GetBaseClientInfo(this HttpContext httpContext)
    {
        return new BaseHttpContextInfo(httpContext.GetBaseLocalIpAddress(), httpContext.GetBaseIpAddress());
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

