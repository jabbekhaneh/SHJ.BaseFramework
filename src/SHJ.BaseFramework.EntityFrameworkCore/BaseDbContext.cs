using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;
using SHJ.BaseFramework.Domain;
using SHJ.BaseFramework.Shared;
using System.Reflection;

namespace SHJ.BaseFramework.EntityFrameworkCore;

public abstract class BaseDbContext<TDbContext> : DbContext
     where TDbContext : DbContext
{
    protected IOptions<BaseOptions> Options;
    protected BaseClaimService _claimService;
    public BaseDbContext(BaseClaimService claimService, IOptions<BaseOptions> options)
    {
        _claimService = claimService;
        Options = options;
    }
    protected BaseDbContext(DbContextOptions<TDbContext> options)
       : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (Options.Value.UseInMemoryDatabase)
        {
            optionsBuilder.UseInMemoryDatabase("dbInMemory");
            optionsBuilder.ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
        }
        else
        {
            optionsBuilder.UseSqlServer(Options.Value.ConnectionString);
        }

        base.OnConfiguring(optionsBuilder);
    }

    public new async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        if (_claimService.IsAuthenticated())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreateOn(_claimService.GetUserId());
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdateOn(_claimService.GetUserId());
                        break;
                }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }


}
