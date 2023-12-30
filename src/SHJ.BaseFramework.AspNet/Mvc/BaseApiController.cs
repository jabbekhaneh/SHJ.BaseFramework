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
}
