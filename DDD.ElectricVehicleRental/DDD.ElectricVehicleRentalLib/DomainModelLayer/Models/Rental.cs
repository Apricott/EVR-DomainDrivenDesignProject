using DDD.Base.DomainModelLayer.Events;
using DDD.Base.DomainModelLayer.Models;
using DDD.ElectricVehicleRentalLib.DomainModelLayer.Events;
using DDD.ElectricVehicleRentalLib.DomainModelLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DDD.ElectricVehicleRentalLib.DomainModelLayer.Models
{
    public class Rental : AggregateRoot
    {
        public DateTime Started { get; protected set; }
        public DateTime? Finished { get; protected set; }
        public Money Total { get; protected set; }
        public Guid VehicleId { get; protected set; }
        public VehicleType VehicleType { get; protected set; }
        public Guid DriverId { get; protected set; }

        public Rental(Guid id, Guid vehicleId, VehicleType vehicleType, Guid driverId, DateTime started, IDomainEventPublisher eventPublisher)
            : base(id, eventPublisher)
        {
            if (started == null) throw new Exception("Started time is null or empty");
            this.Started = started;
            this.Total = Money.Zero;
            this.VehicleId = vehicleId;
            this.VehicleType = vehicleType;
            this.DriverId = driverId;

            this.DomainEventPublisher.Publish<RentalStartedEvent>(new RentalStartedEvent(this.Id, this.VehicleId, this.VehicleType, this.DriverId));
        }

        public void StopRental(DateTime finished, Money unitPrice)
        {
            if (finished < Started)
                throw new Exception($"Exit date and time is earlier than enter date and time.");

            Finished = finished;

            var timeInMinutes = (this.Finished.Value - this.Started).Minutes + ((this.Finished.Value - this.Started).Hours * 60);
            Total = unitPrice.MultiplyBy(timeInMinutes);

            // publish event
            this.DomainEventPublisher.Publish<RentalFinishedEvent>(new RentalFinishedEvent(this.Id, this.VehicleId, this.VehicleType, this.DriverId));
        }

        public int GetTimeInMinutes()
        {
            if (!this.Finished.HasValue) throw new Exception("Not finished visit");

            return (this.Finished.Value - this.Started).Minutes;
        }

    }
}
