using DDD.ElectricVehicleRentalLib.DomainModelLayer.Models;
using DDD.ElectricVehicleRentalLib.DomainModelLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.ElectricVehicleRentalLib.DomainModelLayer.Policies
{
    public class ScooterFreeMinutesPolicy : IFreeMinutesPolicy
    {
        public string Name { get; protected set; }

        public ScooterFreeMinutesPolicy()
        {
            this.Name = "Scooter free minutes";
        }

        public int CalculateFreeMinutes(Money total, long numOfMinutes)
        {
            return (int)total.MultiplyBy(0.3).Amount;
        }
    }
}
