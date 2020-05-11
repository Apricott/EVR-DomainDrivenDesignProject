using DDD.Base.DomainModelLayer.Events;
using DDD.Base.DomainModelLayer.Models;
using DDD.ElectricVehicleRentalLib.DomainModelLayer.Events;
using DDD.ElectricVehicleRentalLib.DomainModelLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.ElectricVehicleRentalLib.DomainModelLayer.Models
{
    public class Driver : AggregateRoot
    {
        public string LicenseNumber { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public int FreeMinutes { get; protected set; }

        private IFreeMinutesPolicy _policy;

        public Driver(Guid id, string licenseNumber, string firstName, string lastName, int freeMinutes, IDomainEventPublisher eventPublisher)
            : base(id, eventPublisher)
        {
            if (String.IsNullOrEmpty(licenseNumber)) throw new Exception("License number is null or empty");
            if (String.IsNullOrEmpty(firstName)) throw new Exception("First name is null");
            if (String.IsNullOrEmpty(lastName)) throw new Exception("Last name distance is null");
            LicenseNumber = licenseNumber;
            FirstName = firstName;
            LastName = lastName;
            FreeMinutes = freeMinutes;


            this.DomainEventPublisher.Publish(new DriverCreatedEvent(this.Id, this.LicenseNumber, this.FirstName, this.LastName, this.FreeMinutes));
        }

        public void RegisterPolicy(IFreeMinutesPolicy policy, Rental rental)
        {
            this._policy = policy ?? throw new ArgumentNullException("Empty free minutes policy");
            FreeMinutes = policy.CalculateFreeMinutes(rental.Total, rental.GetTimeInMinutes());
        }

    }
}
