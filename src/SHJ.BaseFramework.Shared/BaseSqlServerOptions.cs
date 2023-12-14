namespace SHJ.BaseFramework.Shared;


/// <summary>
/// database config and set option all of project
/// </summary>
public class BaseSqlServerOptions
{
  
    /// <summary>
    /// db name
    /// </summary>
    public string DatabaseName { get; set; } = string.Empty;
    /// <summary>
    /// Schema database name
    /// </summary>
    public string SchemaName { get; set; } = "dbo";
    /// <summary>
    ///  server url
    /// </summary>
    public string DataSource { get; set; } = ".";
    /// <summary>
    /// Integrated security database
    /// </summary>
    public string IntegratedSecurity { get; set; } = "True";
    /// <summary>
    /// Multiple Active Result Sets
    /// </summary>
    public string MultipleActiveResultSets { get; set; } = "True";

    /// <summary>
    ///  username database (login)
    /// </summary>
    public string UserID { get; set; } = string.Empty;
    /// <summary>
    ///  password database
    /// </summary>
    public string Password { get; set; } = string.Empty;
    /// <summary>
    ///  type of login sql server
    /// </summary>
    public DatabaseConnectType ConnectToServer { get; set; }
    
}

/// <summary>
///  type of login sql server
/// </summary>
public enum DatabaseConnectType
{
    /// <summary>
    /// Windows authentication
    /// </summary>
    WindowsAuthentication,
    /// <summary>
    /// Sql server authentication
    /// </summary>
    SqlServerAuthentication,
    /// <summary>
    /// Azure login
    /// </summary>
    AzureActive,
}