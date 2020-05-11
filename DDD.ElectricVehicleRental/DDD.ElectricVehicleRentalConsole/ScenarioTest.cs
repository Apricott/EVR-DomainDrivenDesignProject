using System;
using System.Collections.Generic;
using System.Text;
using DDD.ElectricVehicleRentalLib.DomainModelLayer.Models;

namespace DDD.ElectricVehicleRentalConsole
{
    class ScenarioTest
    {
        private ScenarioHelper _scenarioHelper;
        public ScenarioTest(ScenarioHelper scenarioHelper)
        {
            this._scenarioHelper = scenarioHelper;
        }


        public void Test()
        {
            //Position pos1 = new Position(13, 14, "km");
            //Distance dist1 = new Distance(144, "km");


            Guid car1Id = _scenarioHelper.CreateCar("1234", new Position(13, 14, "km"), new Distance(144, "km"), new Distance(10000, "km"), new Money((decimal)0.8, "pln"));
            Guid scooter1Id = _scenarioHelper.CreateScooter("0987", new Position(43, 18, "km"), new Distance(7, "km"), new Distance(400, "km"), new Money((decimal)0.4, "pln"));
            _scenarioHelper.ShowCars();
            _scenarioHelper.ShowScooters();

            Guid driver1Id = _scenarioHelper.CreateDriver("4200", "Robert", "Kubica", 12);
            Guid driver2Id = _scenarioHelper.CreateDriver("9090", "Adam", "Małysz", 0);
            _scenarioHelper.ShowDrivers();

            Console.WriteLine("\n======================== Tworzymy wypozyczenia:\n");

            Guid rental1Id = _scenarioHelper.RentVehicle(driver1Id, car1Id, DateTime.Now.AddHours(2).AddMinutes(3));
            Guid rental2Id = _scenarioHelper.RentVehicle(driver2Id, scooter1Id, DateTime.Now.AddHours(1).AddMinutes(5));

            _scenarioHelper.ShowRentals();
            _scenarioHelper.ShowCars();
            _scenarioHelper.ShowScooters();

            Console.WriteLine("\n======================== Po zwolnieniu pojazdów:\n");

            _scenarioHelper.FreeUpVehicle(rental1Id, car1Id, driver1Id, DateTime.Now.AddHours(4).AddMinutes(0));
            _scenarioHelper.FreeUpVehicle(rental2Id, scooter1Id, driver2Id, DateTime.Now.AddHours(1).AddMinutes(25));
            _scenarioHelper.ShowRentals();
            _scenarioHelper.ShowCars();
            _scenarioHelper.ShowScooters();
            _scenarioHelper.ShowDrivers();

        }
    }
}
