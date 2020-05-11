using DDD.ElectricVehicleRentalLib.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.ElectricVehicleRentalLib.DomainModelLayer.Interfaces
{
    public interface IFreeMinutesPolicy
    {
        string Name { get; }
        int CalculateFreeMinutes(Money total, long numOfMinutes);
    }
}
