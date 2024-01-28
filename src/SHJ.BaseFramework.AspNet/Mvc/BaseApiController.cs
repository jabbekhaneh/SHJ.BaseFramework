using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SHJ.BaseFramework.Shared;

namespace Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public abstract class BaseApiController : Controller
{
    protected readonly BaseResult _result = new();
    protected IBaseClaimService ClaimService => HttpContext.GetBaseClaims();
    protected IConfiguration Configuration => HttpContext.GetBaseConfiguration();
    protected BaseHttpContextInfo ClientInfo => HttpContext.GetBaseClientInfo();
    protected bool IsAuthenticated => HttpContext.GetBaseClaims().IsAuthenticated();
    protected IMapper Mapper => HttpContext.GetMapperServices();

    protected virtual BaseResult OK()
    {
        _result.SetStatus(BaseStatusCodes.OK);
        return _result;
    }
    protected virtual BaseResult<TResult> OK<TResult>(TResult result)
    {
        return BaseResult<TResult>.Build(result);
    }
    protected virtual Task<BaseResult> OkAsync()
    {
        _result.SetStatus(BaseStatusCodes.OK);
        return Task.FromResult(_result);
    }
    protected virtual Task<BaseResult<TResult>> OkAsync<TResult>(TResult result)
    {
        return Task.FromResult(BaseResult<TResult>.Build(result));
    }

    protected virtual BaseResult ReturnResult(object response, int status)
    {
        _result.SetData(response);
        _result.SetStatus(status);
        _result.IsValid();
        return _result;
    }

    protected virtual Task<BaseResult> ReturnResultAsync(object response)
    {
        _result.SetData(response);
        _result.SetStatus(BaseStatusCodes.OK);
        _result.IsValid();
        return Task.FromResult(_result);
    }



    protected virtual Task<BaseResult> ReturnResultAsync(object response, int status)
    {
        _result.SetData(response);
        _result.SetStatus(status);
        _result.IsValid();
        return Task.FromResult(_result);
    }

    protected virtual BaseResult FailRequest()
    {
        _result.SetStatus(BaseStatusCodes.BadRequest);
        _result.IsValid();
        return _result;
    }
    protected virtual BaseResult FailRequest(object response)
    {
        _result.SetData(response);
        _result.SetStatus(BaseStatusCodes.BadRequest);
        _result.IsValid();
        return _result;
    }
    protected virtual BaseResult FailRequest(int status)
    {
        _result.SetStatus(status);
        _result.IsValid();
        return _result;
    }

    protected virtual BaseResult FailRequest(object response, int status)
    {
        _result.SetData(response);
        _result.SetStatus(status);
        _result.IsValid();
        return _result;
    }
    protected virtual Task<BaseResult> FailRequestAsync()
    {
        _result.SetStatus(BaseStatusCodes.BadRequest);
        _result.IsValid();
        return Task.FromResult(_result);
    }
    protected virtual Task<BaseResult> FailRequestAsync(object response)
    {
        _result.SetData(response);
        _result.SetStatus(BaseStatusCodes.BadRequest);
        _result.IsValid();
        return Task.FromResult(_result);
    }
    protected virtual Task<BaseResult> FailRequestAsync(int status)
    {

        _result.SetStatus(status);
        _result.IsValid();
        return Task.FromResult(_result);
    }


    protected virtual Task<BaseResult> FailRequestAsync(object response, int status)
    {
        _result.SetData(response);
        _result.SetStatus(status);
        _result.IsValid();
        return Task.FromResult(_result);
    }


    protected void AddMessage(string message)
    {
        _result.AddMessage(message);
    }
    protected void AddMessages(IEnumerable<string> messages)
    {
        _result.AddMessages(messages);
    }

    protected virtual BaseDto CastToDerivedClass(IMapper mapper, BaseDto baseInstance)
    {
        return mapper.Map<BaseDto>(baseInstance);
    }

}
