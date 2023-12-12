namespace SHJ.BaseFramework.Shared;

public interface BaseClaimService
{
    string GetUserId();
    string GetClaim(string key);
    bool IsAuthenticated();
}
