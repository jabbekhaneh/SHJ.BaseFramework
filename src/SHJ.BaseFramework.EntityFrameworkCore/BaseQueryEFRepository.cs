using Microsoft.EntityFrameworkCore;
using SHJ.BaseFramework.Domain;
using SHJ.BaseFramework.Repository;
using System.Linq.Expressions;

namespace SHJ.BaseFramework.EntityFrameworkCore;

public class BaseQueryEFRepository<TDbContext, TEntity> : IBaseQueryableRepository<TEntity>, IBaseQueryRepository<TEntity> 
    where TEntity : BaseEntity where TDbContext : DbContext
{
    protected readonly TDbContext Context;
    protected readonly DbSet<TEntity> DbSet;
    public BaseQueryEFRepository(TDbContext context)
    {
        Context = context;
        DbSet = context.Set<TEntity>();
    }
    public async Task<ICollection<TEntity>> GetListAsync()
    {
        return await DbSet.ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(Guid id)
    {
        var entity = await DbSet.Where(_ => _.Id.Equals(id)).SingleOrDefaultAsync();
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));
        return entity;
    }

    public async Task<int> GetCountAsync()
    {
        return await DbSet.CountAsync();
    }

    public IQueryable<TEntity> GetQueryable()
    {
        return DbSet.AsQueryable();
    }

    public IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> filter)
    {
        return DbSet.Where(filter).AsQueryable();
    }
}
