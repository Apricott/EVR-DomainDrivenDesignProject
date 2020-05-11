using DDD.Base.DomainModelLayer.Events;
using System;

namespace DDD.Base.DomainModelLayer.Models
{
    public abstract class AggregateRoot : Entity
    {
        protected IDomainEventPublisher DomainEventPublisher { get; set; }
        
        public AggregateRoot(Guid id, IDomainEventPublisher domainEventPublisher)
            :base(id)
        {
            if (domainEventPublisher == null)
                throw new ArgumentNullException("EventPublisher is not initialized");

            this.DomainEventPublisher = domainEventPublisher;
        }
    }
}
