using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;

namespace SHJ.BaseFramework.EntityFrameworkCore;

public abstract class BaseDbContext<TDbContext> : DbContext
     where TDbContext : DbContext
{
   
    protected BaseDbContext(DbContextOptions<TDbContext> options)
        : base(options)
    {
    }
    protected static DbContextOptions<T> ChangeOptionsType<T>(DbContextOptions options) where T : DbContext
    {
        var sqlExt = options.Extensions.FirstOrDefault(e => e is SqlServerOptionsExtension);

        if (sqlExt == null)
            throw (new Exception("Failed to retrieve SQL connection string for base Context"));

        return new DbContextOptionsBuilder<T>()
                    .UseSqlServer(((SqlServerOptionsExtension)sqlExt).ConnectionString)
                    .Options;
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }
}


