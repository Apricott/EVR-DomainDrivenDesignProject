using DDD.Base.DomainModelLayer.Events;
using DDD.ElectricVehicleRentalLib.ApplicationLayer.DTOs;
using DDD.ElectricVehicleRentalLib.ApplicationLayer.Interfaces;
using DDD.ElectricVehicleRentalLib.ApplicationLayer.Mappers;
using DDD.ElectricVehicleRentalLib.DomainModelLayer.Interfaces;
using DDD.ElectricVehicleRentalLib.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DDD.ElectricVehicleRentalLib.ApplicationLayer.Services
{

    public class DriverService : IDriverService
    {
        private ICarRentalUnitOfWork _unitOfWork;
        private DriverMapper _driverMapper;
        private IDomainEventPublisher _domainEventPublisher;

        public DriverService(ICarRentalUnitOfWork unitOfWork,
            DriverMapper driverMapper,
            IDomainEventPublisher domainEventPublisher)
        {
            this._unitOfWork = unitOfWork;
            this._driverMapper = driverMapper;
            this._domainEventPublisher = domainEventPublisher;
        }


        public void CreateDriver(DriverDTO driverDTO)
        {
            Expression<Func<Driver, bool>> expressionPredicate = x => x.LicenseNumber == driverDTO.LicenseNumber;
            Driver driver = this._unitOfWork.DriverRepository.Find(expressionPredicate).FirstOrDefault();

            if (driver != null)
                throw new Exception($"Driver '{driverDTO.LicenseNumber}' already exists");

            driver = new Driver(driverDTO.Id, driverDTO.LicenseNumber, driverDTO.FirstName, driverDTO.LastName, driverDTO.FreeMinutes, this._domainEventPublisher);

            this._unitOfWork.DriverRepository.Insert(driver);
            this._unitOfWork.Commit();


        }

        public List<DriverDTO> GetAllDrivers()
        {
            IList<Driver> drivers = this._unitOfWork.DriverRepository.GetAll();

            List<DriverDTO> result = this._driverMapper.Map(drivers);
            return result;
        }
    }
}
