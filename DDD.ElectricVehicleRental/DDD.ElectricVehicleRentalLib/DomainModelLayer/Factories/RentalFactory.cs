using DDD.Base.DomainModelLayer.Events;
using DDD.ElectricVehicleRentalLib.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.ElectricVehicleRentalLib.DomainModelLayer.Factories
{
    public class RentalFactory
    {
        private IDomainEventPublisher _domainEventPublisher;

        public RentalFactory(IDomainEventPublisher domainEventPublisher)
        {
            this._domainEventPublisher = domainEventPublisher;
        }

        public Rental Create(Guid rentalId, Vehicle vehicle, Driver driver, DateTime start)
        {
            CheckIfVehicleIsFree(vehicle);

            return new Rental(rentalId, vehicle.Id, vehicle._VehicleType, driver.Id, start,this._domainEventPublisher);
        }

        private void CheckIfVehicleIsFree(Vehicle vehicle)
        {
            if (vehicle._Status != Status.Free) throw new Exception($"Vehicle '{vehicle.Id}' is not available");
        }
    }
}
