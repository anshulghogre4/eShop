


namespace Ordering.Domain.Abstractions
{
    public abstract class Aggregate<TId> : Entity<TId>, IAggregate<TId>
    {
        private readonly List<IDomainEvent> _domainEvents = new(); //= new(); – This is a shorthand way of writing new List<IDomainEvent>(); introduced in C# 9.0.
        IReadOnlyList<IDomainEvent> IAggregate.DomainEvents => throw new NotImplementedException();

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        IDomainEvent[] IAggregate.ClearDomainEvents()
        {
            IDomainEvent[] dequeuedEvents = _domainEvents.ToArray();
            _domainEvents.Clear();
            return dequeuedEvents;
        }
    }
}
