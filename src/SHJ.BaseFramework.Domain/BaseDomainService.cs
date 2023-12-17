using SHJ.BaseFramework.Repository;

namespace SHJ.BaseFramework.Domain;
public abstract class BaseDomainService<TEntity>
{

    protected IBaseCommandRepository<TEntity> CommandRepository;
    protected IBaseQueryRepository<TEntity> QueryRepository;
    protected IBaseQueryableRepository<TEntity> QueryableRepository;
    protected IQueryable<TEntity> Queryable  ()=>  QueryableRepository.GetQueryable();

}

