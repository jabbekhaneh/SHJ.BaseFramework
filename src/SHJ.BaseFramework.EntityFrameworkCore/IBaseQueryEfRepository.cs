using System.Linq.Expressions;

namespace SHJ.BaseFramework.EntityFrameworkCore;

public interface IBaseQueryEfRepository<TEntity>
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IQueryable<TEntity> GetQueryable();
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <param name="filter"></param>
    /// <returns></returns>
    IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> filter);
}
