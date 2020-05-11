using DDD.ElectricVehicleRentalLib.ApplicationLayer.DTOs;
using DDD.ElectricVehicleRentalLib.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.ElectricVehicleRentalLib.ApplicationLayer.Mappers
{
    public class RentalMapper
    {
        public List<RentalDTO> Map(IEnumerable<Rental> rentals)
        {
            return rentals.Select(r => Map(r)).ToList();
        }

        public RentalDTO Map(Rental rental)
        {
            return new RentalDTO()
            {
                Id = rental.Id,
                VehicleId = rental.VehicleId,
                DriverId = rental.DriverId,
                Finished = rental.Finished,
                Started = rental.Started,
                Total = rental.Total,
                VehicleType = rental.VehicleType
            };
        }
    }
}
