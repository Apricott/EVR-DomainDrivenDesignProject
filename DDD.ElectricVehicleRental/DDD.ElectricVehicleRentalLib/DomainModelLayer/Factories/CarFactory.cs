using DDD.Base.DomainModelLayer.Events;
using DDD.ElectricVehicleRentalLib.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.ElectricVehicleRentalLib.DomainModelLayer.Factories
{
    public class CarFactory
    {
        private IDomainEventPublisher _domainEventPublisher;

        public CarFactory(IDomainEventPublisher domainEventPublisher)
        {
            this._domainEventPublisher = domainEventPublisher;
        }
        
        public Car Create(Guid carId, string registrationNumber, Position currentPosition, Distance currentDistance, Distance totalDistance, Money unitPrice)
        {
            return new Car(carId, registrationNumber, currentPosition, currentDistance, totalDistance, unitPrice ,this._domainEventPublisher);
        }


    }
}
