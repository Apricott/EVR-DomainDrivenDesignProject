using DDD.Base.ApplicationLayer.Services;
using DDD.ElectricVehicleRentalLib.ApplicationLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.ElectricVehicleRentalLib.ApplicationLayer.Interfaces
{
    public interface IScooterService : IApplicationService
    {
        public void CreateScooter(ScooterDTO scooterDTO);
        List<ScooterDTO> GetAllScooters();
    }
}
