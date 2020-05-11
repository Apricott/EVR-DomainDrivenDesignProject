using System;

namespace DDD.Base.DomainModelLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void RejectChanges();
    }
}
