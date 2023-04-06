namespace WebApp.Common.Data.Entities;

public abstract class BaseEntity<TKey> : IKeyedEntity<TKey>
{
    public TKey Id { get; set; } = default!;
}
