using DDD.Base.DomainModelLayer.Events;
using DDD.Base.InfrastructureLayer;
using DDD.ElectricVehicleRentalLib.ApplicationLayer.Interfaces;
using DDD.ElectricVehicleRentalLib.ApplicationLayer.Mappers;
using DDD.ElectricVehicleRentalLib.ApplicationLayer.Services;
using DDD.ElectricVehicleRentalLib.DomainModelLayer.Events;
using DDD.ElectricVehicleRentalLib.DomainModelLayer.Events.Listeners;
using DDD.ElectricVehicleRentalLib.DomainModelLayer.Factories;
using DDD.ElectricVehicleRentalLib.DomainModelLayer.Models;
using DDD.ElectricVehicleRentalLib.InfrastructureLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.ElectricVehicleRentalConsole
{
    public class SimpleTestContainer
    {
        public IDriverService DriverService { get; }
        public ICarService CarService { get; }
        public IRentalService RentalService { get; }
        public IScooterService ScooterService { get; }

        public SimpleTestContainer()
        {
            // domain event publisher
            var domainEventPublisher = new SimpleEventPublisher();

            // infrastructure service
            var emaildispatcher = new EmailDispatcher();

            // event listeners
            var driverCreatedEventListener = new DriverCreatedEventListener();
            domainEventPublisher.Subscribe<DriverCreatedEvent>(driverCreatedEventListener);

            //unitOfWork
            var unitOfWork = new MemoryCarRentalUnitOfWork(
                new MemoryRepository<Driver>(),
                new MemoryRepository<Car>(),
                new MemoryRepository<Rental>(),
                new MemoryRepository<Scooter>());
            
            // factories
            var rentalFactory = new RentalFactory(domainEventPublisher);
            var carFactory = new CarFactory(domainEventPublisher);
            var freeMinutesFactory = new FreeMinutesFactory();

            // mappers
            var carMapper = new CarMapper();
            var driverMapper = new DriverMapper();
            var scooterMapper = new ScooterMapper();
            var rentalMapper = new RentalMapper();

            this.CarService = new CarService(
                unitOfWork,
                carMapper,
                domainEventPublisher);

            this.ScooterService = new ScooterService(
                unitOfWork,
                scooterMapper,
                domainEventPublisher);

            this.DriverService = new DriverService(
                unitOfWork,
                driverMapper,
                domainEventPublisher);

            this.RentalService = new RentalService(
                unitOfWork,
                rentalFactory,
                rentalMapper,
                freeMinutesFactory,
                domainEventPublisher);

        }

                              
    }
}
