using System.Collections.Generic;

namespace NotificationService.Domain
{
    public abstract class Entity
    {
        public long Id { get; set; }

        private List<IDomainEvent> _domainEvents = new List<IDomainEvent>();

        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
        public void ClearDomainEvents() => _domainEvents.Clear();
        public void AddDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
        public void DeleteDomainEvent(IDomainEvent domainEvent) => _domainEvents.Remove(domainEvent);
    }
}
