using DDD.Base.DomainModelLayer.Events;
using DDD.Base.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.ElectricVehicleRentalLib.DomainModelLayer.Models
{
    public enum VehicleType
    {
        Car = 0,
        Scooter = 1
    }

    public enum Status
    {
        Free = 0,
        Reserved = 1,
        Rented = 2
    }

    public abstract class Vehicle : AggregateRoot
    {
        public abstract VehicleType _VehicleType { get; protected set; }
        public abstract Status _Status { get; protected set; }
        public abstract Money UnitPrice { get; protected set; }

        public Vehicle(Guid id, IDomainEventPublisher eventPublisher)
            : base(id, eventPublisher)
        {   }

        public abstract void ReserveVehicle();

        public abstract void FreeUpVehicle();
    }
}
