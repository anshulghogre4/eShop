
using MediatR;

namespace Ordering.Domain.Abstractions
{
    public interface IDomainEvent : INotification
    {
        //The => (expression-bodied member) syntax is used to define a default interface member implementation in C# 8.0 and later.
        Guid EventId => Guid.NewGuid(); //expression-bodied member. means it's aread only  or get only properties 
        public DateTime OccurredOn  => DateTime.UtcNow;
        public string EventType => GetType().AssemblyQualifiedName;
    }
}
