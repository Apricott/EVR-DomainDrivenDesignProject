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
    public class ScooterService : IScooterService
    {
        private ICarRentalUnitOfWork _unitOfWork;
        private ScooterMapper _scooterMapper;
        private IDomainEventPublisher _domainEventPublisher;

        public ScooterService(ICarRentalUnitOfWork unitOfWork,
            ScooterMapper scooterMapper,
            IDomainEventPublisher domainEventPublisher)
        {
            this._unitOfWork = unitOfWork;
            this._scooterMapper = scooterMapper;
            this._domainEventPublisher = domainEventPublisher;
        }


        public void CreateScooter(ScooterDTO scooterDTO)
        {
            Expression<Func<Scooter, bool>> expressionPredicate = x => x.RegistrationNumber == scooterDTO.RegistrationNumber;
            Scooter scooter = this._unitOfWork.ScooterRepository.Find(expressionPredicate).FirstOrDefault();

            if (scooter != null)
                throw new Exception($"Scooter '{scooterDTO.RegistrationNumber}' already exists");

            scooter = new Scooter(scooterDTO.Id, scooterDTO.RegistrationNumber, scooterDTO.CurrentPosition, scooterDTO.CurrentDistance, scooterDTO.TotalDistance, scooterDTO.UnitPrice, this._domainEventPublisher);

            this._unitOfWork.ScooterRepository.Insert(scooter);
            this._unitOfWork.Commit();


        }

        public List<ScooterDTO> GetAllScooters()
        {
            IList<Scooter> scooters = this._unitOfWork.ScooterRepository.GetAll();

            List<ScooterDTO> result = this._scooterMapper.Map(scooters);
            return result;
        }
    }
}
