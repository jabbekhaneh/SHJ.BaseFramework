using SHJ.BaseFramework.DependencyInjection.Contracts;

namespace SHJ.BaseFramework.Repository;

/// <summary>
///  
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface IBaseQueryRepository<TEntity>  : IScopedDependency
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<TEntity> GetByIdAsync(Guid id);
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<ICollection<TEntity>> GetListAsync();
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<int> GetCountAsync();
   


}
