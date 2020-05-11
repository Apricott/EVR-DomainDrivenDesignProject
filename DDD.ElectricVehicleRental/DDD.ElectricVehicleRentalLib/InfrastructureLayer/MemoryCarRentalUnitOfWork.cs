using DDD.Base.DomainModelLayer.Interfaces;
using DDD.ElectricVehicleRentalLib.DomainModelLayer.Interfaces;
using DDD.ElectricVehicleRentalLib.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.ElectricVehicleRentalLib.InfrastructureLayer
{
    public class MemoryCarRentalUnitOfWork : ICarRentalUnitOfWork
    {
        public IRepository<Car> CarRepository { get; protected set; }

        public IRepository<Driver> DriverRepository { get; protected set; }

        public IRepository<Rental> RentalRepository { get; protected set; }

        public IRepository<Scooter> ScooterRepository { get; protected set; }

        public MemoryCarRentalUnitOfWork(
            IRepository<Driver> driverRepository,
            IRepository<Car> carRepository,
            IRepository<Rental> rentalRepository,
            IRepository<Scooter> scooterRepository)
        {
            DriverRepository = driverRepository;
            CarRepository = carRepository;
            RentalRepository = rentalRepository;
            ScooterRepository = scooterRepository;
        }

        public MemoryCarRentalUnitOfWork()
        {
            DriverRepository = new MemoryRepository<Driver>();
            CarRepository = new MemoryRepository<Car>();
            RentalRepository = new MemoryRepository<Rental>();
            ScooterRepository = new MemoryRepository<Scooter>();
        }


        public void Commit()
        { }

        public void Dispose()
        { }

        public void RejectChanges()
        { }
    }
}
