namespace SHJ.BaseFramework.Dapper;

public class SHJBaseFrameworkDapperException : Exception
{

    public SHJBaseFrameworkDapperException(string message) : base(message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("SHJ.BaseFramework.Dapper");
        Console.WriteLine(message);
    }
}
