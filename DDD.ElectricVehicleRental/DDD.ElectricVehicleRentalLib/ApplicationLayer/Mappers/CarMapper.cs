using DDD.ElectricVehicleRentalLib.ApplicationLayer.DTOs;
using DDD.ElectricVehicleRentalLib.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.ElectricVehicleRentalLib.ApplicationLayer.Mappers
{
    public class CarMapper
    {
        public List<CarDTO> Map(IEnumerable<Car> cars)
        {
            return cars.Select(c => Map(c)).ToList();
        }

        public CarDTO Map(Car car)
        {
            return new CarDTO()
            {
                Id = car.Id,
                _Status = car._Status,
                CurrentDistance = car.CurrentDistance,
                CurrentPosition = car.CurrentPosition,
                TotalDistance = car.TotalDistance,
                RegistrationNumber = car.RegistrationNumber
            };
        }


    }
}
