using DDD.Base.DomainModelLayer.Events;
using DDD.ElectricVehicleRentalLib.ApplicationLayer.DTOs;
using DDD.ElectricVehicleRentalLib.ApplicationLayer.Interfaces;
using DDD.ElectricVehicleRentalLib.ApplicationLayer.Mappers;
using DDD.ElectricVehicleRentalLib.DomainModelLayer.Factories;
using DDD.ElectricVehicleRentalLib.DomainModelLayer.Interfaces;
using DDD.ElectricVehicleRentalLib.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DDD.ElectricVehicleRentalLib.ApplicationLayer.Services
{
    public class RentalService : IRentalService
    {
        private ICarRentalUnitOfWork _unitOfWork;
        private RentalMapper _rentalMapper;
        private RentalFactory _rentalFactory;
        private FreeMinutesFactory _freeMinutesFactory;
        private IDomainEventPublisher _domainEventPublisher;

        public RentalService(ICarRentalUnitOfWork unitOfWork,
            RentalFactory rentalFactory,
            RentalMapper rentalMapper,
            FreeMinutesFactory freeMinutesFactory,
            IDomainEventPublisher domainEventPublisher)
        {
            this._unitOfWork = unitOfWork;
            this._rentalMapper = rentalMapper;
            this._rentalFactory = rentalFactory;
            this._freeMinutesFactory = freeMinutesFactory;
            this._domainEventPublisher = domainEventPublisher;
        }


        public void StartRental(Guid rentalId, Guid vehicleId, Guid driverId, DateTime start)
        {
            Vehicle vehicle = this._unitOfWork.CarRepository.Get(vehicleId);
            if (vehicle == null)
            {
                vehicle = this._unitOfWork.ScooterRepository.Get(vehicleId)
                    ?? throw new Exception($"Could not find vehicle '{vehicleId}'.");
            }

            Driver driver = this._unitOfWork.DriverRepository.Get(driverId)
                ?? throw new Exception($"Could not find driver '{driverId}'.");

            Rental rental = this._rentalFactory.Create(rentalId, vehicle, driver, DateTime.Now);
            vehicle.ReserveVehicle();

            this._unitOfWork.RentalRepository.Insert(rental);
            this._unitOfWork.Commit();

        }

        public void StopRental(Guid rentalId, Guid vehicleId, Guid driverId, DateTime stop)
        {
            Vehicle vehicle = this._unitOfWork.CarRepository.Get(vehicleId);
            if (vehicle == null)
            {
                vehicle = this._unitOfWork.ScooterRepository.Get(vehicleId)
                    ?? throw new Exception($"Could not find vehicle '{vehicleId}'.");
            }

            Driver driver = this._unitOfWork.DriverRepository.Get(driverId)
                ?? throw new Exception($"Could not find driver '{driverId}'.");
            Rental rental = this._unitOfWork.RentalRepository.Get(rentalId)
                ?? throw new Exception($"Could not find rental '{rentalId}'.");

            rental.StopRental(stop, vehicle.UnitPrice);
            vehicle.FreeUpVehicle();

            IFreeMinutesPolicy policy = this._freeMinutesFactory.Create(rental);

            driver.RegisterPolicy(policy, rental);

            this._unitOfWork.Commit();
        }


        public List<RentalDTO> GetAllRentals()
        {
            IList<Rental> rentals = this._unitOfWork.RentalRepository.GetAll();

            List<RentalDTO> result = this._rentalMapper.Map(rentals);
            return result;
        }
    }
}
