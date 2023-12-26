using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using Microsoft.Extensions.Options;
using SHJ.BaseFramework.Domain;
using SHJ.BaseFramework.Shared;

namespace SHJ.BaseFramework.EntityFrameworkCore;

public abstract class BaseApplicationDbContext<TDbContext> : DbContext
     where TDbContext : DbContext
{
    protected IOptions<BaseOptions> Options;
    protected IBaseClaimService ClaimService;
    protected BaseApplicationDbContext(DbContextOptions<TDbContext> options, IOptions<BaseOptions> baseOptions, IBaseClaimService claimService)
        : base(options)
    {
        Options = baseOptions;
        ClaimService = claimService;
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


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (Options.Value.DatabaseType == DatabaseType.InMemory)
        {
            optionsBuilder.UseInMemoryDatabase("App.Db");
            optionsBuilder.ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
        }
        else if (Options.Value.DatabaseType == DatabaseType.MsSql)
        {
            string connectionString = SetConnectionString();
            optionsBuilder.UseSqlServer(connectionString);
            
        }
        else if (Options.Value.DatabaseType == DatabaseType.Manual)
        {
            optionsBuilder.UseSqlServer(Options.Value.ManualConnectionString);
        }

        base.OnConfiguring(optionsBuilder);
    }



    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        if (ClaimService.IsAuthenticated())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreateOn(ClaimService.GetUserId());
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdateOn(ClaimService.GetUserId());
                        break;
                }
        }
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        if (ClaimService.IsAuthenticated())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreateOn(ClaimService.GetUserId());
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdateOn(ClaimService.GetUserId());
                        break;
                }
        }
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }


    private string SetConnectionString()
    {
        return $@"Data Source={Options.Value.SqlOptions.DataSource};Initial Catalog={Options.Value.SqlOptions.DatabaseName};Persist Security Info=True;MultipleActiveResultSets=True;User ID={Options.Value.SqlOptions.UserID};Password={Options.Value.SqlOptions.Password}";
    }
}


