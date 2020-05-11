using DDD.ElectricVehicleRentalLib.DomainModelLayer.Models;
using DDD.ElectricVehicleRentalLib.DomainModelLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.ElectricVehicleRentalLib.DomainModelLayer.Policies
{
    public class StandardFreeMinutesPolicy : IFreeMinutesPolicy
    {
        public string Name { get; protected set; }

        public StandardFreeMinutesPolicy()
        {
            this.Name = "Standard free minutes";
        }

        public int CalculateFreeMinutes(Money total, long numOfMinutes)
        {
            return (int)total.MultiplyBy(0.1).Amount;
        }
    }
}
