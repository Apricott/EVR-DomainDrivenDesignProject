using DDD.Base.DomainModelLayer.Interfaces;
using DDD.ElectricVehicleRentalLib.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.ElectricVehicleRentalLib.DomainModelLayer.Interfaces
{
    public interface ICarRentalUnitOfWork : IUnitOfWork, IDisposable
    {
        IRepository<Car> CarRepository { get; }
        IRepository<Driver> DriverRepository { get; }
        IRepository<Rental> RentalRepository { get; }
        IRepository<Scooter> ScooterRepository { get; }
    }
}
