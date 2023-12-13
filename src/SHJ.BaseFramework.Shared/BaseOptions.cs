namespace SHJ.BaseFramework.Shared;
/// <summary>
/// 
/// </summary>
public class BaseOptions
{
    public BaseSqlServerOptions? SqlOptions { get; set; } 
    /// <summary>
    /// 
    /// </summary>
    public DatabaseType DatabaseType { get; set; }
    /// <summary>
    /// ASPNET CORE ENVIRONMENT
    /// </summary>
    public ASPNET_EnvironmentType Environment { get; set; }

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
}
public enum ASPNET_EnvironmentType
{
    Development,
    Production,
}

