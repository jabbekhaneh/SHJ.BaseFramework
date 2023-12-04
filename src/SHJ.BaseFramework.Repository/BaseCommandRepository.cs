namespace SHJ.BaseFramework.Repository;


/// <summary>
/// 
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface BaseCommandRepository<TEntity>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<TEntity> InsertAsync(TEntity entity);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    TEntity Insert(TEntity entity);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>
    Task InsertBulk(List<TEntity> entities);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    TEntity Update(TEntity entity);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    void Delete(TEntity entity);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteById(long id);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<TEntity> FindById(long id);
}