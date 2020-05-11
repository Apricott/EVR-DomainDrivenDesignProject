using DDD.Base.DomainModelLayer.Events;
using DDD.ElectricVehicleRentalLib.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.ElectricVehicleRentalLib.DomainModelLayer.Events
{
    public class DriverCreatedEvent : IDomainEvent
    {
        public Guid DriverId { get; private set; }
        public string LicenseNumber { get; private set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public int FreeMinutes { get; protected set; }

        public DriverCreatedEvent(Guid id, string licenseNumber, string firstName, string lastName, int freeMinutes)
        {
            this.DriverId = id;
            this.LicenseNumber = licenseNumber;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FreeMinutes = freeMinutes;
        }
    }

    public class RentalStartedEvent : IDomainEvent
    {
        public Guid RentalId { get; private set; }
        public Guid VehicleId { get; private set; }
        public VehicleType VehicleType { get; private set; }
        public Guid DriverId { get; private set; }

        public RentalStartedEvent(Guid rentalId, Guid vehicleId, VehicleType vehicleType,  Guid driverId)
        {
            this.RentalId = rentalId;
            this.VehicleId = vehicleId;
            this.VehicleType = vehicleType;
            this.DriverId = driverId;
        }
    }

    public class RentalFinishedEvent : IDomainEvent
    {
        public Guid RentalId { get; private set; }
        public Guid VehicleId { get; private set; }
        public VehicleType VehicleType { get; private set; }
        public Guid DriverId { get; private set; }

        public RentalFinishedEvent(Guid rentalId, Guid vehicleId, VehicleType vehicleType, Guid driverId)
        {
            this.RentalId = rentalId;
            this.VehicleId = vehicleId;
            this.VehicleType = vehicleType;
            this.DriverId = driverId;
        }
    }
}
