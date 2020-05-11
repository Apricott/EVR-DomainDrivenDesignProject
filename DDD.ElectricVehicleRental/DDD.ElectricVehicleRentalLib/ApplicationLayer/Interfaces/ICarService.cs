using DDD.Base.ApplicationLayer.Services;
using DDD.ElectricVehicleRentalLib.ApplicationLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.ElectricVehicleRentalLib.ApplicationLayer.Interfaces
{
    public interface ICarService : IApplicationService
    {
        void CreateCar(CarDTO carDTO);
        List<CarDTO> GetAllCars();


    }
}
