using Microsoft.EntityFrameworkCore;

namespace SHJ.BaseFramework.EntityFrameworkCore;

public class BaseDbContext<TDbContext> : DbContext
     where TDbContext : DbContext
{
    protected BaseDbContext(DbContextOptions<TDbContext> options)
       : base(options)
    {

    }

    
}
