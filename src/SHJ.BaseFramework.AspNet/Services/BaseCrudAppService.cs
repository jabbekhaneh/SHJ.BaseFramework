using AutoMapper;
using AutoMapper.QueryableExtensions;
using SHJ.BaseFramework.Domain;
using SHJ.BaseFramework.Repository;
using SHJ.BaseFramework.Shared;

namespace SHJ.BaseFramework.AspNet.Services;

public class BaseCrudAppService<TEntity, TSelectDto, TCreateDto, TUpdateDto> : BaseApiController
    where TEntity : BaseEntity
    where TSelectDto : BaseDto<Guid>
    where TCreateDto : BaseDto
    where TUpdateDto : BaseDto
{
    protected IBaseCommandRepository<TEntity> CommandRepository;
    protected IBaseQueryableRepository<TEntity> QueryableRepository;
    protected IBaseCommandUnitOfWork UnitOfWork;
    protected IQueryable<TEntity> Query;
    protected IMapper Mapper;

    protected BaseCrudAppService(IBaseCommandRepository<TEntity> commandRepository, IBaseQueryableRepository<TEntity> queryableRepository, IBaseCommandUnitOfWork unitOfWork, IMapper mapper)
    {
        CommandRepository = commandRepository;
        QueryableRepository = queryableRepository;
        Query = QueryableRepository.GetQueryable();
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    [HttpGet]
    public virtual async Task<BaseResult> Get(BaseFilterDto filter)
    {
        var source = Query.ProjectTo<TSelectDto>(Mapper.ConfigurationProvider)
            .Pagination<TSelectDto>(filter.Take ?? 40, filter.PageId ?? 1);

        return await ReturnResultAsync(source);
    }

    [HttpGet("{id}")]
    public virtual BaseResult<TSelectDto> Get(Guid id)

    {
        var dto = Query.ProjectTo<TSelectDto>(Mapper.ConfigurationProvider)
            .SingleOrDefault(_ => _.Id.Equals(id));

        if (dto == null)
            throw new ArgumentNullException(nameof(id));

        return BaseResult<TSelectDto>.Build(dto);
    }

    [HttpPut]
    public virtual async Task<BaseResult> Update(TUpdateDto input)
    {
        var model = Mapper.Map<TEntity>(CastToDerivedClass(Mapper, input));
        CommandRepository.Update(model);
        await UnitOfWork.CommitAsync();
        return await OkAsync();
    }

    [HttpPost]
    public virtual async Task<BaseResult<Guid>> Create(TCreateDto input)
    {
        var model = Mapper.Map<TEntity>(CastToDerivedClass(Mapper, input));
        await CommandRepository.InsertAsync(model);
        await UnitOfWork.CommitAsync();
        return BaseResult<Guid>.Build(model.Id);
    }

    [HttpDelete]
    public virtual async Task<BaseResult> Delete(Guid id)
    {
        var model = Query.FirstOrDefault(_ => _.Id == id);
        if (model == null)
            throw new ArgumentNullException(nameof(TEntity));
        CommandRepository.Delete(model);
        await UnitOfWork.CommitAsync();
        return await OkAsync();
    }


}


