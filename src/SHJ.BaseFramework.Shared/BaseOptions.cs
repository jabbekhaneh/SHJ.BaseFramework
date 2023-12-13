namespace SHJ.BaseFramework.Shared;

public class BaseOptions
{
    /// <summary>
    /// It is set automatically
    /// </summary>
    public string ConnectionString { get; set; } = string.Empty;
    /// <summary>
    /// It is set manual 
    /// </summary>
    public string ManualConnectionString { get; set; } = string.Empty;
    /// <summary>
    /// It is set automatically provided that DatabaseType is manual 
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
    /// <summary>
    /// ASPNET CORE ENVIRONMENT
    /// </summary>
    public ASPNET_ENVIRONMENT Environment { get; set; }



}
public enum DatabaseType
{
    MsSql,
    Oracle,
    PostgreSql,
    Sqlite,
    InMemory,
    Cosmos,
    Firebird,
    Manual,
}
public enum ASPNET_ENVIRONMENT
{
    Development,
    Production,
}