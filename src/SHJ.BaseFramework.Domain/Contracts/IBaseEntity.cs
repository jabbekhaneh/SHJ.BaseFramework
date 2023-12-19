namespace SHJ.BaseFramework.Domain.Contracts;

public interface IBaseEntity
{

}
public interface IBaseEntity<TKey> : IBaseEntity
{
    TKey Id { get; set; }
}
