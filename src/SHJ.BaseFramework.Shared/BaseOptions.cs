namespace SHJ.BaseFramework.Shared;

public class BaseOptions
{
    public BaseOptions()
    {
    }
    public string ConnectionString { get { return GetConnectionString(); }  }
    /// <summary>
    /// The amount of DatabaseType should be equal to DbTest
    /// </summary>
    public string DefualtConnectionString { get; set; } = string.Empty;
    /// <summary>
    /// 
    /// </summary>
    public string DatabaseName { get; set; } = string.Empty;
    /// <summary>
    /// 
    /// </summary>
    public string SchemaName { get; set; } = "dbo";
    /// <summary>
    /// 
    /// </summary>
    public string DataSource { get; set; } = ".";
    /// <summary>
    /// 
    /// </summary>
    public string IntegratedSecurity { get; set; } = "True";
    /// <summary>
    /// 
    /// </summary>
    public string MultipleActiveResultSets { get; set; } = "True";
    /// <summary>
    /// 
    /// </summary>
    public DatabaseType DatabaseType { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string UserID { get; set; } = string.Empty;
    /// <summary>
    /// 
    /// </summary>
    public string Password { get; set; } = string.Empty;
    /// <summary>
    /// 
    /// </summary>
    public string InMemoryDatabaseConnection { get; private set; } = @"Data Source=app.db";


    private string GetConnectionString()
    {
        if (string.IsNullOrEmpty(UserID))
             return $"data source ={DataSource};initial catalog={DatabaseName};integrated security={IntegratedSecurity}; MultipleActiveResultSets={MultipleActiveResultSets}";
        else
            return  $@"Data Source={DataSource};Initial Catalog={DatabaseName};Persist Security Info=True;MultipleActiveResultSets=True;User ID={UserID};Password={Password}";
    }
}
public enum DatabaseType : byte
{
    MsSql,
    Oracle,
    PostgreSql,
    Sqlite,
    InMemory,
    Cosmos,
    Firebird,
    DbTest,
}