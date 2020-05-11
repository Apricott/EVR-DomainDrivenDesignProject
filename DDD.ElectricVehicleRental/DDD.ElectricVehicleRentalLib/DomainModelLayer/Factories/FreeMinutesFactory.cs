using DDD.ElectricVehicleRentalLib.DomainModelLayer.Interfaces;
using DDD.ElectricVehicleRentalLib.DomainModelLayer.Models;
using DDD.ElectricVehicleRentalLib.DomainModelLayer.Policies;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.ElectricVehicleRentalLib.DomainModelLayer.Factories
{
    public class FreeMinutesFactory
    {
        public IFreeMinutesPolicy Create(Rental rental)
        {
            IFreeMinutesPolicy policy = new StandardFreeMinutesPolicy();

            if (rental.VehicleType == VehicleType.Scooter)
                policy = new ScooterFreeMinutesPolicy();
            else if (rental.GetTimeInMinutes() > 60)
                policy = new VIPFreeMinutesPolicy();

            return policy;
        }
    }
}
