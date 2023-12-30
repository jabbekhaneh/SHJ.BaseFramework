using Microsoft.EntityFrameworkCore;
using SHJ.BaseFramework.Domain;
using SHJ.BaseFramework.Repository;

namespace SHJ.BaseFramework.EntityFrameworkCore;


public class BaseCommandEFRepository<TDbContext, TEntity> : IBaseCommandRepository<TEntity> where TEntity : BaseEntity where TDbContext : DbContext
{
    protected readonly TDbContext Context;
    protected readonly DbSet<TEntity> DbSet;
    public BaseCommandEFRepository(TDbContext context)
    {
        Context = context;
        DbSet = context.Set<TEntity>();
    }
    public async Task<TEntity> InsertAsync(TEntity entity)
    {
        var addedEntity = (await DbSet.AddAsync(entity)).Entity;

        return addedEntity;
    }
    public TEntity Insert(TEntity entity)
    {
        var addedEntity = (DbSet.Add(entity)).Entity;

        return addedEntity;
    }

    public void Delete(TEntity entity)
    {
        DbSet.Remove(entity);

    }

    public TEntity Update(TEntity entity)
    {
        var updateEntity = (DbSet.Update(entity)).Entity;
        return updateEntity;
    }

    public async Task InsertBulk(List<TEntity> entities)
    {
        await DbSet.AddRangeAsync(entities);
    }

    public async Task DeleteById(Guid id)
    {
        var entity = await DbSet.Where(_ => _.Id.Equals(id)).FirstOrDefaultAsync();
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));
        DbSet.Remove(entity);
    }

    public async Task<TEntity> FindByIdAsync(Guid id)
    {
        var entity = await DbSet.FindAsync(id);
        return entity;
    }
}