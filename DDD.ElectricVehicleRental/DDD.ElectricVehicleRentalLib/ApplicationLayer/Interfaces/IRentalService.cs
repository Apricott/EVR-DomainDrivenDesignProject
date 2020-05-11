using DDD.Base.ApplicationLayer.Services;
using DDD.ElectricVehicleRentalLib.ApplicationLayer.DTOs;
using DDD.ElectricVehicleRentalLib.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.ElectricVehicleRentalLib.ApplicationLayer.Interfaces
{
    public interface IRentalService : IApplicationService
    {
        public void StartRental(Guid rentalId, Guid vehicleId, Guid driverId, DateTime start);
        public void StopRental(Guid rentalId, Guid vehicleId, Guid driverId, DateTime finish);
        List<RentalDTO> GetAllRentals();
    }
}
