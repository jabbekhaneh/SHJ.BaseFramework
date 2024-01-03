using AutoMapper;
using SHJ.BaseFramework.Domain;
using SHJ.BaseFramework.Repository;
using SHJ.BaseFramework.Shared;


namespace SHJ.BaseFramework.AspNet.Services;

public abstract class BaseAppService<TEntity> : BaseApiController where TEntity : BaseEntity
{
    private readonly BaseResult _result = new();

    protected IBaseCommandRepository<TEntity> CommandRepository;
    protected IBaseQueryableRepository<TEntity> QueryableRepository;
    protected IBaseCommandUnitOfWork UnitOfWork;
    protected IQueryable<TEntity> Query;
    protected readonly IMapper Mapper;
    protected BaseAppService(IBaseCommandRepository<TEntity> commandRepository, IBaseQueryableRepository<TEntity> queryableRepository, IMapper mapper, IBaseCommandUnitOfWork unitOfWork)
    {
        CommandRepository = commandRepository;
        QueryableRepository = queryableRepository;
        Query = QueryableRepository.GetQueryable();
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }
}

public abstract class BaseAppService : BaseApiController
{

}

