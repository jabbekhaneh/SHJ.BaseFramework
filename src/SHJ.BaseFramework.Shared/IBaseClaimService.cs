namespace SHJ.BaseFramework.Shared;

public interface IBaseClaimService
{
    string GetUserId();
    string GetClaim(string key);
    bool IsAuthenticated();
}
