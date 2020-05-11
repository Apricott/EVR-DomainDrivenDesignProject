using DDD.Base.ApplicationLayer.Services;
using DDD.ElectricVehicleRentalLib.ApplicationLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.ElectricVehicleRentalLib.ApplicationLayer.Interfaces
{
    public interface IDriverService : IApplicationService
    {
        void CreateDriver(DriverDTO driverDTO);
        List<DriverDTO> GetAllDrivers();

    }
}
