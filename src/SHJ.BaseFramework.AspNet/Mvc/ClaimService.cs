using Microsoft.AspNetCore.Http;
using SHJ.BaseFramework.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SHJ.BaseFramework.AspNet.Mvc;


public class ClaimService : BaseClaimService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public ClaimService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public string GetUserId()
    {
        return GetClaim(ClaimTypes.NameIdentifier);
    }

    public string GetClaim(string key)
    {

        return _httpContextAccessor.HttpContext?.User?.FindFirst(key)?.Value ?? "";
    }

    public bool IsAuthenticated()
    {
        return _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
    }
}
