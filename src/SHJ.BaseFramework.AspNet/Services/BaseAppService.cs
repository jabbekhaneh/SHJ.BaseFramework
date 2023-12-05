﻿using Microsoft.Extensions.Configuration;
using SHJ.BaseFramework.AspNet.Mvc;
using SHJ.BaseFramework.Domain;
using SHJ.BaseFramework.Shared;

namespace SHJ.BaseFramework.AspNet.Services;

public abstract class BaseAppService<TEntity>  : BaseApiController where TEntity : BaseEntity
{
    private readonly BaseResult _result = new();
    protected BaseClaimService ClaimService => HttpContext.GetBaseClaims();
    protected IConfiguration Configuration => HttpContext.GetBaseConfiguration();
    protected BaseHttpContextInfo ClientInfo => HttpContext.GetBaseClientInfo();
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
    protected virtual BaseResult Result(object response)
    {
        _result.SetData(response);
        _result.SetStatus(BaseStatusCodes.OK);
        _result.IsValid();
        return _result;
    }
    //protected virtual void ThrowException(int status)
    //{
    //    throw new BaseException(status);
    //}
    protected void AddMessage(string message)
    {
        _result.AddMessage(message);
    }
}