using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SHJ.BaseFramework.Shared;

namespace SHJ.BaseFramework.AspNet.Mvc;

[ApiController]
[Route("[controller]")]
public abstract class BaseApiController : Controller
{
    protected BaseClaimService ClaimService => HttpContext.GetBaseClaims();
    protected IConfiguration Configuration => HttpContext.GetBaseConfiguration();
    protected BaseHttpContextInfo ClientInfo => HttpContext.GetBaseClientInfo();
    protected bool IsAuthenticated => HttpContext.GetBaseClaims().IsAuthenticated();
}
