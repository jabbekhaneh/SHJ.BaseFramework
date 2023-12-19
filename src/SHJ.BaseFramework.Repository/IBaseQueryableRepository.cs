using SHJ.BaseFramework.DependencyInjection.Contracts;
using System.Linq.Expressions;

namespace SHJ.BaseFramework.Repository;

public interface IBaseQueryableRepository<TEntity> : IScopedDependency
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
