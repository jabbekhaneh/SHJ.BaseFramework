using Microsoft.EntityFrameworkCore;
using SHJ.BaseFramework.Repository;

namespace SHJ.BaseFramework.EntityFrameworkCore;

public class BaseEFUnitOfWork<TDbContext> : BaseCommandUnitOfWork where TDbContext : DbContext
{
    private readonly TDbContext _dbContext;
    public BaseEFUnitOfWork(TDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void BeginTransaction()
    {
        throw new NotImplementedException();
    }

    public int Commit()
    {
        return _dbContext.SaveChanges();
    }

    public async Task<int> CommitAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }

    public void CommitTransaction()
    {
        throw new NotImplementedException();
    }

    public void RollbackTransaction()
    {
        throw new NotImplementedException();
    }
}

