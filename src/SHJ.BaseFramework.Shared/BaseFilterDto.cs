namespace SHJ.BaseFramework.Shared;

public class BaseFilterDto
{
    public string Search { get; set; } = string.Empty;
    public int PageId { get; set; } = 1;
    public int Take { get; set; } = 40;
}
