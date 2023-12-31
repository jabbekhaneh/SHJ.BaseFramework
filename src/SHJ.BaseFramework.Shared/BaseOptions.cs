﻿namespace SHJ.BaseFramework.Shared;
/// <summary>
///  set all of project option
/// </summary>
public class BaseOptions
{
    /// <summary>
    /// database config and set option all of project
    /// </summary>
    public BaseSqlServerOptions? SqlOptions { get; set; }
    /// <summary>
    /// Manual set  connectionString
    /// </summary>
    public string ManualConnectionString { get; set; } = string.Empty;
    /// <summary>
    /// type of database
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
    Manual,
}
public enum ASPNET_EnvironmentType
{
    Development,
    Production,
}

