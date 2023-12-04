namespace SHJ.BaseFramework.Repository;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface BaseQueryRepository<TEntity>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<TEntity> GetById(long id);
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<ICollection<TEntity>> GetAll();
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<int> GetCount();

}
