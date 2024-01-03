namespace SHJ.BaseFramework.Repository;

public static class PaginationToolser
{
    public static PaginationDto<T> Pagination<T>(this IQueryable<T> source, int take, int pageId)
    {
        var query = source;
        int TotalItemCount = query.Count();
        int pageSize = (int)Math.Ceiling((double)TotalItemCount / take);
        pageId = pageId > pageSize || pageId < 1 ? 1 : pageId;
        var skiped = (pageId - 1) * take;
        return new PaginationDto<T>
        {
            Query = query.Skip(skiped).Take(take),
            PageSize = pageSize,
        };
    }

}
public class PaginationDto<T>
{
    public IQueryable<T>? Query { get; set; }
    public int PageSize { get; set; }

}