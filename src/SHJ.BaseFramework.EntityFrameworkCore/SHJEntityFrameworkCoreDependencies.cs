using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SHJ.BaseFramework.Repository;

namespace SHJ.BaseFramework.EntityFrameworkCore;

public static class SHJEntityFrameworkCoreDependencies
{
    public static IServiceCollection AddShjEntityFramework<TDbContext>(this IServiceCollection services)
        where TDbContext : DbContext
    {
        services.AddTransient<BaseCommandUnitOfWork, BaseEFUnitOfWork<TDbContext>>();
        return services;
    }
}
