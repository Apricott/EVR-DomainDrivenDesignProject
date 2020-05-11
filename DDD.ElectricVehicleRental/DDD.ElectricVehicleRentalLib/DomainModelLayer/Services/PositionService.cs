using DDD.Base.DomainModelLayer.Events;
using DDD.ElectricVehicleRentalLib.DomainModelLayer.Interfaces;
using DDD.ElectricVehicleRentalLib.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.ElectricVehicleRentalLib.DomainModelLayer.Services
{
    class PositionService
    {
        private ICarRentalUnitOfWork _unitOfWork;
        private IDomainEventPublisher _domainEventPublisher;

        public PositionService(ICarRentalUnitOfWork unitOfWork,
            IDomainEventPublisher domainEventPublisher)
        {
            this._unitOfWork = unitOfWork;
            this._domainEventPublisher = domainEventPublisher;
        }


        public Position CheckPosition(Guid id, Car car)
        {
            Random random = new Random();
            Position position = new Position(random.Next(-100, 100), random.Next(-100, 100), "km");

            return position;
        }

    }
}
