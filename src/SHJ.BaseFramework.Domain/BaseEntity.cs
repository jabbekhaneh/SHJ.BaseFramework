using SHJ.BaseFramework.Domain.Contracts;

namespace SHJ.BaseFramework.Domain;

public abstract class BaseEntity<TKey> : IBaseEntity<TKey> 
{
    public TKey Id { get; set; }
    public DateTime? CreatedTime { get; private set; }
    public string? CreatedBy { get; private set; }
    public DateTime? DeletedTime { get; private set; }
    public string? DeletedBy { get; private set; }
    public bool IsDeleted { get; private set; } = false;
    public DateTime? UpdateTime { get; private set; }
    public string? UpdateBy { get; private set; }
    public string? IP { get; set; } = string.Empty;

    public virtual void CreateOn(string createdBy)
    {
        if (string.IsNullOrEmpty(createdBy))
            throw new ArgumentNullException(nameof(createdBy));
        CreatedBy = createdBy;
        CreatedTime = DateTime.Now;
    }
    public virtual void UpdateOn(string updateBy)
    {
        if (string.IsNullOrEmpty(updateBy))
            throw new ArgumentNullException(nameof(updateBy));
        UpdateBy = updateBy;
        UpdateTime = DateTime.Now;
    }
    public virtual void DeleteOn(string deletedBy)
    {
        if (string.IsNullOrEmpty(deletedBy))
            throw new ArgumentNullException(nameof(deletedBy));
        DeletedBy = deletedBy;
        DeletedTime = DateTime.Now;
        IsDeleted = true;
    }

}




public abstract class BaseEntity : BaseEntity<Guid>
{   
}