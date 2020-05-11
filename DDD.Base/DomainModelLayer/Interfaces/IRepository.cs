using DDD.Base.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DDD.Base.DomainModelLayer.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : AggregateRoot
    {
        TEntity Get(Guid id);
        IList<TEntity> GetAll();
        IList<TEntity> Find(Expression<Func<TEntity, bool>> expression);
        void Insert(TEntity entity);
        void Delete(TEntity entity);
    }
}
