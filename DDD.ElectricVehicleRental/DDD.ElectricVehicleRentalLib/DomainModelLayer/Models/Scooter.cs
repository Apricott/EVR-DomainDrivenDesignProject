using DDD.Base.DomainModelLayer.Events;
using DDD.Base.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.ElectricVehicleRentalLib.DomainModelLayer.Models
{
    public class Scooter : Vehicle
    {
        public string RegistrationNumber { get; protected set; }
        public Position CurrentPosition { get; protected set; }
        public Distance CurrentDistance { get; protected set; }
        public Distance TotalDistance { get; protected set; }
        public override Money UnitPrice { get; protected set; }
        public override Status _Status { get; protected set; }


        public override VehicleType _VehicleType { get; protected set; }

        public Scooter(Guid scooterId, string registrationNumber, Position currentPosition, Distance currentDistance, Distance totalDistance, Money unitPrice, IDomainEventPublisher eventPublisher)
            : base(scooterId, eventPublisher)
        {
            if (String.IsNullOrEmpty(registrationNumber)) throw new Exception("Registration number is null or empty");
            if (unitPrice < Money.Zero) throw new ArgumentNullException("Unit price is less then zero.");

            this.RegistrationNumber = registrationNumber;
            this._Status = Status.Free;
            this.CurrentPosition = currentPosition;
            this.CurrentDistance = currentDistance;
            this.TotalDistance = totalDistance;
            this.UnitPrice = unitPrice;
            this._VehicleType = VehicleType.Scooter;
        }

        public override void ReserveVehicle()
        {
            if (this._Status != Status.Free)
                throw new Exception($"Scooter '{this.RegistrationNumber}' is not available");

            this._Status = Status.Reserved;
        }

        public override void FreeUpVehicle()
        {
            this._Status = Status.Free;
        }
    }
}
