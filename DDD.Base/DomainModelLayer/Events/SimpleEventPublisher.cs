using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Base.DomainModelLayer.Events
{
    public class SimpleEventPublisher : IDomainEventPublisher
    {
        private Dictionary<string, HashSet<IEventListener>> _eventHandlers = new Dictionary<string, HashSet<IEventListener>>();

        public void Subscribe<T>(IEventListener<T> listener) where T : IDomainEvent
        {
            if (listener == null) throw new ArgumentNullException(nameof(listener));

            string key = typeof(T).ToString();
            if (_eventHandlers.ContainsKey(key))
            {
                var hashSet = _eventHandlers[key];
                hashSet.Add(listener);
            }
            else
            {
                var hashSet = new HashSet<IEventListener>();
                hashSet.Add(listener);
                _eventHandlers.Add(key, hashSet);

            }
        }

        public void Unsubscribe<T>(IEventListener<T> listener) where T : IDomainEvent
        {
            if (listener == null) throw new ArgumentNullException(nameof(listener));

            string key = typeof(T).ToString();
            if (_eventHandlers.ContainsKey(key))
            {
                var hashSet = _eventHandlers[key];
                if (hashSet.Contains(listener))
                {
                    hashSet.Remove(listener);
                    if (hashSet.Count == 0)
                    {
                        _eventHandlers.Remove(key);
                    }
                }
            }
        }

        public void Publish<T>(T domainEvent) where T : IDomainEvent
        {
            foreach (var kvp in _eventHandlers)
            {
                if (kvp.Key == typeof(T).ToString())
                {
                    foreach (IEventListener handler in kvp.Value)
                    {
                        ((IEventListener<T>)handler).Handle(domainEvent);
                    }
                }
            }
        }
    }
}
