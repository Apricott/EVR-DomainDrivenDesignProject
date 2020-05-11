using DDD.Base.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.ElectricVehicleRentalLib.DomainModelLayer.Models
{
    public class Distance : ValueObject
    {
        public double Value { get; protected set; }
        public string Unit { get; protected set; }

        public Distance(double value, string unit)
        {
            this.Value = value;
            this.Unit = unit;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value; ;
            yield return Unit;
        }

        public int Compare(Distance s)
        {
            return this.Value.CompareTo(s.Value);
        }

        public static bool operator <(Distance m, Distance m2)
        {
            return m.Value.CompareTo(m2.Value) < 0;
        }

        public static bool operator >(Distance m, Distance m2)
        {
            return m.Value.CompareTo(m2.Value) > 0;
        }

        public static bool operator >=(Distance m, Distance m2)
        {
            return m.Value.CompareTo(m2.Value) >= 0;
        }

        public static bool operator <=(Distance m, Distance m2)
        {
            return m.Value.CompareTo(m2.Value) <= 0;
        }
    }
}
