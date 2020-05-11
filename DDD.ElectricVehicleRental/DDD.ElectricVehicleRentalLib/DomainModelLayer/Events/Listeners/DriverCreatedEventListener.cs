using DDD.Base.DomainModelLayer.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.ElectricVehicleRentalLib.DomainModelLayer.Events.Listeners
{
    public class DriverCreatedEventListener : IEventListener<DriverCreatedEvent>
    {


        public void Handle(DriverCreatedEvent eventData)
        {
            Console.WriteLine("Driver " + eventData.LicenseNumber + " created"); 
        }
    }
}


