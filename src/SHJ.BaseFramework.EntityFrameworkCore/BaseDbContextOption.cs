namespace SHJ.BaseFramework.EntityFrameworkCore;

public class BaseDbContextOption
{
    public string ConnectionString { get; private set; } = string.Empty;
    public string DatabaseName { get; set; } = "dbCMS";
    public string SchemaName { get; set; } = "dbo";
    public string DataSource { get; set; } = ".";
    public string IntegratedSecurity { get; set; } = "True";
    public string MultipleActiveResultSets { get; set; } = "True";
    public bool UseInMemoryDatabase { get; set; } = false;
    public string LogFileUrl { get; set; } = "";
    public string LogFileName { get; set; } = "";
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
    Firebird
}