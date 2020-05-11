using DDD.ElectricVehicleRentalLib.ApplicationLayer.DTOs;
using DDD.ElectricVehicleRentalLib.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.ElectricVehicleRentalLib.ApplicationLayer.Mappers
{
    public class ScooterMapper
    {
        public List<ScooterDTO> Map(IEnumerable<Scooter> scooters)
        {
            return scooters.Select(s => Map(s)).ToList();
        }

        public ScooterDTO Map(Scooter scooter)
        {
            return new ScooterDTO()
            {
                Id = scooter.Id,
                _Status = scooter._Status,
                CurrentDistance = scooter.CurrentDistance,
                CurrentPosition = scooter.CurrentPosition,
                TotalDistance = scooter.TotalDistance,
                RegistrationNumber = scooter.RegistrationNumber
            };
        }
    }
}
