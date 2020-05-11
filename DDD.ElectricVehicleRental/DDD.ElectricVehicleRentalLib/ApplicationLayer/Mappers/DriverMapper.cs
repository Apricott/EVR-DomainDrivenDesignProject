using DDD.ElectricVehicleRentalLib.ApplicationLayer.DTOs;
using DDD.ElectricVehicleRentalLib.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.ElectricVehicleRentalLib.ApplicationLayer.Mappers
{
    public class DriverMapper
    {
        public List<DriverDTO> Map(IEnumerable<Driver> drivers)
        {
            return drivers.Select(r => Map(r)).ToList();
        }

        public DriverDTO Map(Driver driver)
        {
            return new DriverDTO()
            {
                Id = driver.Id,
                LicenseNumber = driver.LicenseNumber,
                FirstName = driver.FirstName,
                LastName = driver.LastName,
                FreeMinutes = driver.FreeMinutes
            };
        }
    }
}
