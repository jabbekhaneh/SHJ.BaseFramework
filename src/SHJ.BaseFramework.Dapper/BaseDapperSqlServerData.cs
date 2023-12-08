using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Options;
using SHJ.BaseFramework.Repository;
using SHJ.BaseFramework.Shared;
using System.Data;
using System.Reflection;

namespace SHJ.BaseFramework.Dapper;


public class BaseDapperSqlServerData<TEntity> : BaseQueryRepository<TEntity>
{
    protected IOptions<BaseOptions> Options;
    protected IDbConnection? Connection { get; set; }
    public BaseDapperSqlServerData(IOptions<BaseOptions> options)
    {
        Options = options;
        SetOption(options);
    }

    private void SetOption(IOptions<BaseOptions> options)
    {
        if (string.IsNullOrEmpty(options.Value.ConnectionString))
            throw new ArgumentNullException($"{nameof(options.Value.ConnectionString)}");

        switch (options.Value.DatabaseType)
        {
            case DatabaseType.MsSql:
                Connection = new SqlConnection(options.Value.ConnectionString);
                break;
            case DatabaseType.TestContainer:
                Connection = new SqlConnection(options.Value.ConnectionStringTestContainer);
                break;
        }
        
    }
    

    /// <summary>
    /// Get All Entities
    /// </summary>
    /// <returns></returns>
    public async Task<ICollection<TEntity>> GetAll()
    {
        var query = $"select * from {typeof(TEntity).Name}s";
        var entities = await Connection.QueryAsync<TEntity>(query);
        return entities.ToList();
    }

    /// <summary>
    /// Get Entity By Key
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<TEntity> GetById(long id)
    {
        var query = $"select * from {typeof(TEntity).Name}s where Id=@Id";
        var entity = await Connection.QueryAsync<TEntity>(query, new { Id = id });
        return entity.SingleOrDefault();
    }
    /// <summary>
    /// Get Count of Entities
    /// </summary>
    /// <returns></returns>
    public async Task<int> GetCount()
    {
        var query = $"select count(*) from {typeof(TEntity).Name}s";
        var count = await Connection.ExecuteScalarAsync<int>(query);
        return count;
    }

    protected IEnumerable<string> GetColumns()
    {
        return typeof(TEntity)
                .GetProperties()
                .Where(e => e.Name != "Id" && !e.PropertyType.GetTypeInfo().IsGenericType)
                .Select(e => e.Name);
    }
}
