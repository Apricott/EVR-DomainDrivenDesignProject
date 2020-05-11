using DDD.ElectricVehicleRentalLib.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.ElectricVehicleRentalLib.ApplicationLayer.DTOs
{
    public class ScooterDTO
    {
        public Guid Id { get; set; }
        public string RegistrationNumber { get; set; }
        public Status _Status { get; set; }
        public Position CurrentPosition { get; set; }
        public Distance CurrentDistance { get; set; }
        public Distance TotalDistance { get; set; }
        public Money UnitPrice { get; set; }
    }
}
