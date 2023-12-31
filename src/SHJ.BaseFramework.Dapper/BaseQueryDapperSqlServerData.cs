﻿using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Options;
using SHJ.BaseFramework.Repository;
using SHJ.BaseFramework.Shared;
using System.Data;
using System.Reflection;

namespace SHJ.BaseFramework.Dapper;


public class BaseQueryDapperSqlServerData<TEntity> : IBaseQueryRepository<TEntity>
{
    protected IOptions<BaseOptions> Options;
    protected IDbConnection? Connection { get; set; }
    public BaseQueryDapperSqlServerData(IOptions<BaseOptions> options)
    {
        Options = options;
        SetOption(options);
    }

    private void SetOption(IOptions<BaseOptions> options)
    {
        switch (options.Value.DatabaseType)
        {
            case DatabaseType.MsSql:
                string connectionString = ConnectionString();
                Connection = new SqlConnection(connectionString);
                break;
            case DatabaseType.Manual:
                Connection = new SqlConnection(options.Value.ManualConnectionString);
                break;
            case DatabaseType.InMemory:
                throw new SHJBaseFrameworkDapperException("can not use DatabaseInMemory in dapper");
        }

    }


    /// <summary>
    /// Get All Entities
    /// </summary>
    /// <returns></returns>
    public async Task<ICollection<TEntity>> GetListAsync()
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
    public async Task<TEntity> GetByIdAsync(Guid id)
    {
        Console.WriteLine("Dapper GetById: " + id);
        var query = $"select * from {typeof(TEntity).Name}s where Id=@Id";
        var entity = await Connection.QueryAsync<TEntity>(query, new { Id = id });
        return entity.SingleOrDefault();
    }
    /// <summary>
    /// Get Count of Entities
    /// </summary>
    /// <returns></returns>
    public async Task<int> GetCountAsync()
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

    

    public string ConnectionString()
    {
        if (Options.Value.SqlOptions.ConnectToServer == DatabaseConnectType.WindowsAuthentication)
            return $"data source ={Options.Value.SqlOptions.DataSource};initial catalog={Options.Value.SqlOptions.DatabaseName};integrated security={Options.Value.SqlOptions.IntegratedSecurity}; MultipleActiveResultSets={Options.Value.SqlOptions.MultipleActiveResultSets}";

        else if (Options.Value.SqlOptions.ConnectToServer == DatabaseConnectType.SqlServerAuthentication)
            return $@"Data Source={Options.Value.SqlOptions.DataSource};Initial Catalog={Options.Value.SqlOptions.DatabaseName};Persist Security Info=True;MultipleActiveResultSets=True;User ID={Options.Value.SqlOptions.UserID};Password={Options.Value.SqlOptions.Password}";

        return string.Empty;
    }
}
