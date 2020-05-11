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
    public class CarService : ICarService
    {
        private ICarRentalUnitOfWork _unitOfWork;
        private CarMapper _carMapper;
        private IDomainEventPublisher _domainEventPublisher;

        public CarService(ICarRentalUnitOfWork unitOfWork,
            CarMapper carMapper,
            IDomainEventPublisher domainEventPublisher)
        {
            this._unitOfWork = unitOfWork;
            this._carMapper = carMapper;
            this._domainEventPublisher = domainEventPublisher;
        }

        
        public void CreateCar(CarDTO carDTO)
        {
            Expression<Func<Car, bool>> expressionPredicate = x => x.RegistrationNumber == carDTO.RegistrationNumber;
            Car car = this._unitOfWork.CarRepository.Find(expressionPredicate).FirstOrDefault();

            if (car != null)
                throw new Exception($"Car '{carDTO.RegistrationNumber}' already exists");

            car = new Car(carDTO.Id, carDTO.RegistrationNumber, carDTO.CurrentPosition, carDTO.CurrentDistance, carDTO.TotalDistance, carDTO.UnitPrice,  this._domainEventPublisher);

            this._unitOfWork.CarRepository.Insert(car);
            this._unitOfWork.Commit();


        }

        public List<CarDTO> GetAllCars()
        {
            IList<Car> cars = this._unitOfWork.CarRepository.GetAll();

            List<CarDTO> result = this._carMapper.Map(cars);
            return result;
        }
    }
}
