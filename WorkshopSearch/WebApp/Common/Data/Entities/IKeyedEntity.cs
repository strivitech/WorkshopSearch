namespace WebApp.Common.Data.Entities;

public interface IKeyedEntity<TKey> : IEntity
{
    public TKey Id { get; set; }
}
