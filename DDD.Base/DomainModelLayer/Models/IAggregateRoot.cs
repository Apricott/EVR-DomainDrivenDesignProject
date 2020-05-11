using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Base.DomainModelLayer.Models
{
    public interface IAggregateRoot
    {
        Guid Id { get; }
    }
}
