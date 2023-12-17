using SHJ.BaseFramework.Repository;

namespace SHJ.BaseFramework.Domain;
public abstract class BaseDomainService<TEntity>
{

    protected IBaseCommandRepository<TEntity> CommandRepository;
    protected IBaseQueryableRepository<TEntity> QueryableRepository;
    protected IQueryable<TEntity> Query;

    protected BaseDomainService(IBaseCommandRepository<TEntity> commandRepository, IBaseQueryableRepository<TEntity> queryableRepository)
    {
        CommandRepository = commandRepository;
        QueryableRepository = queryableRepository;
        Query = QueryableRepository.GetQueryable();
    }
    
    protected IQueryable<TEntity> Queryable() => QueryableRepository.GetQueryable();

}

