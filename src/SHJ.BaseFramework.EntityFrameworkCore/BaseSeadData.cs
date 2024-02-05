namespace SHJ.BaseFramework.EntityFrameworkCore;

public interface BaseSeadData
{
    void Initialize();
    Task InitializeAsync();
    void SeedData();
    Task SeedDataAsync();
}
