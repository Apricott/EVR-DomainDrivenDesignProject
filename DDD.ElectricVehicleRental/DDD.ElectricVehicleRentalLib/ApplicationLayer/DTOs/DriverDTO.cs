using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.ElectricVehicleRentalLib.ApplicationLayer.DTOs
{
    public class DriverDTO
    {
        public Guid Id { get; set; }
        public string LicenseNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int FreeMinutes { get; set; }
    }
}
