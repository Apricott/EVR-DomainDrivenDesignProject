using DDD.Base.DomainModelLayer.Events;
using DDD.ElectricVehicleRentalLib.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.ElectricVehicleRentalLib.DomainModelLayer.Factories
{
    public class ScooterFactory
    {
        private IDomainEventPublisher _domainEventPublisher;

        public ScooterFactory(IDomainEventPublisher domainEventPublisher)
        {
            this._domainEventPublisher = domainEventPublisher;
        }

        public Scooter Create(Guid scooterId, string registrationNumber, Position currentPosition, Distance currentDistance, Distance totalDistance, Money unitPrice)
        {
            return new Scooter(scooterId, registrationNumber, currentPosition, currentDistance, totalDistance, unitPrice, this._domainEventPublisher);
        }
    }
}
