using DDD.Base.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.ElectricVehicleRentalLib.DomainModelLayer.Models
{
    public class Position : ValueObject
    {
        public Position(int xPosition, int yPosition, string unit)
        {
            XPosition = xPosition;
            YPosition = yPosition;
            Unit = unit;
        }

        public int XPosition { get; protected set; }
        public int YPosition { get; protected set; }
        public string Unit { get; protected set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return XPosition; 
            yield return YPosition;
            yield return Unit;
        }

        public Distance CalculateDistance(Position p)
        {
            double result = Math.Sqrt((p.XPosition ^ 2) + (p.YPosition ^ 2));
            return new Distance(result, "km");
        }
    }
}
