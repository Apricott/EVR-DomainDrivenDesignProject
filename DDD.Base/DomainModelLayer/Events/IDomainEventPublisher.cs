namespace DDD.Base.DomainModelLayer.Events
{
    public interface IDomainEventPublisher
    {
        void Publish<T>(T domainEvent) where T : IDomainEvent;
        void Subscribe<T>(IEventListener<T> listener) where T : IDomainEvent;
        void Unsubscribe<T>(IEventListener<T> listener) where T : IDomainEvent;
    }
}
