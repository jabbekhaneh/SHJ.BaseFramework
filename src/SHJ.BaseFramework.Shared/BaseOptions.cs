namespace SHJ.BaseFramework.Shared;

public class BaseOptions
{
    public BaseOptions()
    {
        if (string.IsNullOrEmpty(UserID))
            ConnectionString = $"data source ={DataSource}; initial catalog ={DatabaseName}; integrated security = {IntegratedSecurity}; MultipleActiveResultSets={MultipleActiveResultSets}";
        else
            ConnectionString = $@"Data Source={DataSource} ;Initial Catalog={DatabaseName};Persist Security Info=True;MultipleActiveResultSets=True;User ID={UserID};Password={Password}";
    }
    public string ConnectionString { get; private set; } = string.Empty;
    public string DefualtConnectionString { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;
    public string SchemaName { get; set; } = "dbo";
    public string DataSource { get; set; } = ".";
    public string IntegratedSecurity { get; set; } = "True";
    public string MultipleActiveResultSets { get; set; } = "True";
    public DatabaseType DatabaseType { get; set; }
    public string UserID { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string InMemoryDatabaseConnection { get; private set; } = @"Data Source=app.db";

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