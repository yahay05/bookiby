namespace Bookiby.Domain.Abstractions;

public abstract class Entity
{
    protected Entity(string id)
    {
        Id = id;
    }
    protected Entity()
    {
    }
    private readonly List<IDomainEvent> _domainEvents = new();
    public string Id { get; set; }

    public IReadOnlyList<IDomainEvent> GetDomainEvents()
    {
        return _domainEvents.ToList();
    }
    public void ClearDomainEvents() => _domainEvents.Clear();
    protected void RaiseDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
}