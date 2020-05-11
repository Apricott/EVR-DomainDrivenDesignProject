using DDD.Base.DomainModelLayer.Interfaces;
using DDD.Base.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DDD.ElectricVehicleRentalLib.InfrastructureLayer
{
    public class MemoryRepository<TEntity> : IRepository<TEntity>
       where TEntity : AggregateRoot
    {
        protected static List<TEntity> _entities = new List<TEntity>();

        public TEntity Get(Guid id)
        {
            return _entities
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public IList<TEntity> GetAll()
        {
            return _entities;
        }
        public IList<TEntity> Find(Expression<Func<TEntity, bool>> expression)
        {
            return _entities
                .AsQueryable()
                .Where(expression)
                .ToList();
        }
        public void Insert(TEntity entity)
        {
            _entities.Add(entity);
        }
        public void Delete(TEntity entity)
        {
            _entities.Remove(entity);
        }
    }
}
