﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SHJ.BaseFramework.Shared;

namespace Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public abstract class BaseApiController : Controller
{
    protected IBaseClaimService ClaimService => HttpContext.GetBaseClaims();
    protected IConfiguration Configuration => HttpContext.GetBaseConfiguration();
    protected BaseHttpContextInfo ClientInfo => HttpContext.GetBaseClientInfo();
    protected bool IsAuthenticated => HttpContext.GetBaseClaims().IsAuthenticated();

    private readonly BaseResult _result = new();

    protected virtual Task<BaseResult> OkAsync()
    {
        return Task.FromResult(_result);
    }

    protected virtual Task<BaseResult> ResultAsync(object response)
    {
        _result.SetData(response);
        _result.SetStatus(BaseStatusCodes.OK);
        _result.IsValid();
        return Task.FromResult(_result);
    }
    protected virtual BaseResult ReturnResult(object response)
    {
        _result.SetData(response);
        _result.SetStatus(BaseStatusCodes.OK);
        _result.IsValid();
        return _result;
    }
    protected void AddMessage(string message)
    {
        _result.AddMessage(message);
    }
    public BaseDto CastToDerivedClass(IMapper mapper, BaseDto baseInstance)
    {
        return mapper.Map<BaseDto>(baseInstance);
    }
}
