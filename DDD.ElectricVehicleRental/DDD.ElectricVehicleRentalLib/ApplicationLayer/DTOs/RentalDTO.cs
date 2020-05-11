using DDD.ElectricVehicleRentalLib.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.ElectricVehicleRentalLib.ApplicationLayer.DTOs
{
    public class RentalDTO
    {
        public Guid Id { get; set; }
        public DateTime Started { get; set; }
        public DateTime? Finished { get; set; }
        public Money Total { get; set; }
        public Guid VehicleId { get; set; }
        public VehicleType VehicleType { get; set; }
        public Guid DriverId { get; set; }
    }
}
