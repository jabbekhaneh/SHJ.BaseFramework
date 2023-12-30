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


    protected virtual Task<BaseResult> OkAsync()
    {
        return Task.FromResult(_result);
    }

    protected virtual Task<BaseResult> ResultAsync(object response)
    {
        _result.SetData(response);
        _result.SetStatus(BaseStatusCodes.OK);
        _result.IsValid();
        return Task.FromResult(_result);
    }
    protected virtual BaseResult Result(object response)
    {
        _result.SetData(response);
        _result.SetStatus(BaseStatusCodes.OK);
        _result.IsValid();
        return _result;
    }
    protected void AddMessage(string message)
    {
        _result.AddMessage(message);
    }
    public BaseDto CastToDerivedClass(IMapper mapper, BaseDto baseInstance)
    {
        return mapper.Map<BaseDto>(baseInstance);
    }

}


public abstract class BaseAppService : BaseApiController
{
    private readonly BaseResult _result = new();

    protected virtual Task<BaseResult> OkAsync()
    {
        return Task.FromResult(_result);
    }

    protected virtual Task<BaseResult> ResultAsync(object response)
    {
        _result.SetData(response);
        _result.SetStatus(BaseStatusCodes.OK);
        _result.IsValid();
        return Task.FromResult(_result);
    }
    protected virtual BaseResult Result(object response)
    {
        _result.SetData(response);
        _result.SetStatus(BaseStatusCodes.OK);
        _result.IsValid();
        return _result;
    }
    protected void AddMessage(string message)
    {
        _result.AddMessage(message);
    }
    public BaseDto CastToDerivedClass(IMapper mapper, BaseDto baseInstance)
    {
        return mapper.Map<BaseDto>(baseInstance);
    }
}