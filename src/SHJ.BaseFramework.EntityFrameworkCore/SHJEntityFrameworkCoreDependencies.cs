using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SHJ.BaseFramework.Repository;

namespace SHJ.BaseFramework.EntityFrameworkCore;

public static class SHJEntityFrameworkCoreDependencies
{
    public static IServiceCollection AddSHJEntityFramework<TDbContext>(this IServiceCollection services)
        where TDbContext : DbContext
    {
        services.AddTransient<IBaseCommandUnitOfWork, BaseEFUnitOfWork<TDbContext>>();
        return services;
    }
}
