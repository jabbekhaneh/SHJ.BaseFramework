using SHJ.BaseFramework.Domain;
using SHJ.BaseFramework.Repository;


namespace SHJ.BaseFramework.AspNet.Services;

public abstract class BaseAppService<TEntity> : BaseApiController where TEntity : BaseEntity
{


    protected IBaseCommandRepository<TEntity> CommandRepository;
    protected IBaseQueryableRepository<TEntity> QueryableRepository;
    protected IBaseCommandUnitOfWork UnitOfWork;
    protected IQueryable<TEntity> Query;
    protected BaseAppService(IBaseCommandRepository<TEntity> commandRepository, IBaseQueryableRepository<TEntity> queryableRepository, IBaseCommandUnitOfWork unitOfWork)
    {
        CommandRepository = commandRepository;
        QueryableRepository = queryableRepository;
        Query = QueryableRepository.GetQueryable();
        UnitOfWork = unitOfWork;
    }
}

public abstract class BaseAppService : BaseApiController
{

}

