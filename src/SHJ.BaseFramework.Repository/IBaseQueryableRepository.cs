using System.Linq.Expressions;

namespace SHJ.BaseFramework.Repository;

public interface IBaseQueryableRepository<TEntity>
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>IBaseQueryableRepository
    IQueryable<TEntity> GetQueryable();
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <param name="filter"></param>
    /// <returns></returns>
    IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> filter);
}
