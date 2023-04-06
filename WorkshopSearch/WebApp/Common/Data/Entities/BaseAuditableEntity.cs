namespace WebApp.Common.Data.Entities;

public abstract class BaseAuditableEntity<TKey> : BaseEntity<TKey>, IAuditableEntity
{
    public DateTime Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }
}
