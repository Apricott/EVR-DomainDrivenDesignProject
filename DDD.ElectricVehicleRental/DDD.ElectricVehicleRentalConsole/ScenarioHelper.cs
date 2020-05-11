using DDD.ElectricVehicleRentalLib.ApplicationLayer.Interfaces;
using DDD.ElectricVehicleRentalLib.ApplicationLayer.DTOs;
using DDD.ElectricVehicleRentalLib.ApplicationLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;
using DDD.ElectricVehicleRentalLib.DomainModelLayer.Models;

namespace DDD.ElectricVehicleRentalConsole
{
    public class ScenarioHelper
    {
        private ICarService _carService;
        private IDriverService _driverService;
        private IRentalService _rentalService;
        private IScooterService _scooterService;

        public ScenarioHelper(ICarService carService, IDriverService driverService, IScooterService scooterService, IRentalService rentalService)
        {
            this._driverService = driverService;
            this._carService = carService;
            this._rentalService = rentalService;
            this._scooterService = scooterService;
        }

        public void ShowCars()
        {
            Console.WriteLine("\nCars");
            Console.WriteLine("-------------------------------\n");
            List<CarDTO> cars = this._carService.GetAllCars();
            foreach (CarDTO car in cars)
            {
                Console.WriteLine($"Id:                 '{car.Id}'");
                Console.WriteLine($"RegistrationNumber: '{car.RegistrationNumber}'");
                Console.WriteLine($"Status:             '{car._Status}'");
                Console.WriteLine($"CurrentPosition:    '{car.CurrentPosition.XPosition} , {car.CurrentPosition.YPosition}'");
                Console.WriteLine($"CurrentDistance:    '{car.CurrentDistance.Value}'");
                Console.WriteLine($"TotalDistance:      '{car.TotalDistance.Value}'");
            }
        }

        public void ShowScooters()
        {
            Console.WriteLine("\nScooters");
            Console.WriteLine("-------------------------------\n");
            List<ScooterDTO> scooters = this._scooterService.GetAllScooters();
            foreach (ScooterDTO scooter in scooters)
            {
                Console.WriteLine($"Id:                 '{scooter.Id}'");
                Console.WriteLine($"RegistrationNumber: '{scooter.RegistrationNumber}'");
                Console.WriteLine($"Status:             '{scooter._Status}'");
                Console.WriteLine($"CurrentPosition:    '{scooter.CurrentPosition.XPosition} , {scooter.CurrentPosition.YPosition}'");
                Console.WriteLine($"CurrentDistance:    '{scooter.CurrentDistance.Value}'");
                Console.WriteLine($"TotalDistance:      '{scooter.TotalDistance.Value}'");
            }
        }

        public void ShowRentals()
        {
            Console.WriteLine("\nRentals");
            Console.WriteLine("-------------------------------\n");
            List<RentalDTO> rentals = this._rentalService.GetAllRentals();
            foreach (RentalDTO rental in rentals)
            {
                Console.WriteLine($"Id:                 '{rental.Id}'");
                Console.WriteLine($"VehicleId:          '{rental.VehicleId}'");
                Console.WriteLine($"VehicleType:        '{rental.VehicleType}'");
                Console.WriteLine($"DriverId:           '{rental.DriverId}'");
                Console.WriteLine($"Started:            '{rental.Started}'");
                Console.WriteLine($"Finished:           '{rental.Finished}'");
                Console.WriteLine($"Total:              '{rental.Total}'");
            }
        }

        public void ShowDrivers()
        {
            Console.WriteLine("\nDrivers");
            Console.WriteLine("-------------------------------\n");
            List<DriverDTO> drivers = this._driverService.GetAllDrivers();
            foreach (DriverDTO driver in drivers)
            {
                Console.WriteLine($"Id:                 '{driver.Id}'");
                Console.WriteLine($"First name:         '{driver.FirstName}'");
                Console.WriteLine($"Last name:          '{driver.LastName}'");
                Console.WriteLine($"License number:     '{driver.LicenseNumber}'");
                Console.WriteLine($"Free minutes:       '{driver.FreeMinutes}'");
                
            }
        }

        public Guid CreateCar(string registrationNumber, Position currentPosition, Distance currentDistance , Distance totalDistance, Money unitPrice)
        {
            Guid carId = Guid.NewGuid();
            CarDTO carDTO = new CarDTO()
            {
                Id = carId,
                RegistrationNumber = registrationNumber,
                CurrentPosition = currentPosition,
                CurrentDistance = currentDistance,
                TotalDistance = totalDistance,
                UnitPrice = unitPrice          
            };
            this._carService.CreateCar(carDTO);
            return carId;
        }
        public Guid CreateScooter(string registrationNumber, Position currentPosition, Distance currentDistance, Distance totalDistance, Money unitPrice)
        {
            Guid scooterId = Guid.NewGuid();
            ScooterDTO scooterDTO = new ScooterDTO()
            {
                Id = scooterId,
                RegistrationNumber = registrationNumber,
                CurrentPosition = currentPosition,
                CurrentDistance = currentDistance,
                TotalDistance = totalDistance,
                UnitPrice = unitPrice
            };
            this._scooterService.CreateScooter(scooterDTO);
            return scooterId;
        }

        public Guid CreateDriver(string licenseNumber, string firstName, string lastName, int freeMinutes)
        {
            Guid driverId = Guid.NewGuid();
            DriverDTO driverDTO = new DriverDTO()
            {
                Id = driverId,
                LicenseNumber = licenseNumber,
                FirstName = firstName,
                LastName = lastName,
                FreeMinutes = freeMinutes,
            };
            this._driverService.CreateDriver(driverDTO);
            return driverId;
        }

        public Guid RentVehicle(Guid driverId, Guid vehicleId,DateTime start)
         {
            Guid rentalId = Guid.NewGuid();
            this._rentalService.StartRental(rentalId, vehicleId, driverId, start);

            return rentalId;
        }

        public void FreeUpVehicle(Guid rentalId, Guid vehicleId, Guid driverId, DateTime finished)
        {
            this._rentalService.StopRental(rentalId, vehicleId, driverId, finished);
        }

    }
}
