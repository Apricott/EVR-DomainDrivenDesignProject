using DDD.ElectricVehicleRentalLib.DomainModelLayer.Models;
using DDD.ElectricVehicleRentalLib.DomainModelLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.ElectricVehicleRentalLib.DomainModelLayer.Policies
{
    public class VIPFreeMinutesPolicy : IFreeMinutesPolicy
    {
        public string Name { get; protected set; }

        public VIPFreeMinutesPolicy()
        {
            this.Name = "Vip discount policy";
        }

        public int CalculateFreeMinutes(Money total, long numOfMinutes)
        { 
            return (int)total.MultiplyBy(0.15).Amount;
        }
    }
}
