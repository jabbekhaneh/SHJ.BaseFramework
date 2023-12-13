namespace SHJ.BaseFramework.Shared;

public class BaseSqlServerOptions
{
  
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
    public string UserID { get; set; } = string.Empty;
    /// <summary>
    /// 
    /// </summary>
    public string Password { get; set; } = string.Empty;
    /// <summary>
    /// 
    /// </summary>
    public DatabaseConnectType ConnectToServer { get; set; }
    
}
public enum DatabaseConnectType
{
    WindowsAuthentication,
    SqlServerAuthentication,
    AzureActive,
}