using System;

namespace DDD.Base.DomainModelLayer.Models
{
    public class Price: Money 
    { 
        public Price(decimal amount, string currency)
            :base(amount, currency)
        {
            if (amount < 0) throw new Exception("Price can not be less then zero");
        }
    }
}
