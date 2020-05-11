using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DDD.Base.DomainModelLayer.Models
{
    // Na podstawie:
    // https://enterprisecraftsmanship.com/posts/value-object-better-implementation/
    // https://bottega.com.pl/ddd-cqrs-sample-project
    public class Money : ValueObject
    {
        public static readonly string DefaultCurrency = NumberFormatInfo.CurrentInfo.CurrencySymbol;
        public static readonly Money Zero = new Money(0);

        public string Currency { get; }
        public decimal Amount { get; }

        public Money(decimal amount, string currency)
        {
            Currency = currency;
            Amount = amount;
        }

        public Money(decimal amount)
        {
            Currency = DefaultCurrency;
            Amount = amount;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Currency.ToUpper();
            yield return Math.Round(Amount, 2);
        }

        public static Money operator +(Money m, Money m2)
        {
            if (!AreCompatibleCurrencies(m, m2))
            {
                throw new ArgumentException("Currency mismatch");
            }
            return new Money(m.Amount + m2.Amount, m.Currency);
        }

        public static Money operator -(Money m, Money m2)
        {
            if (!AreCompatibleCurrencies(m, m2))
            {
                throw new ArgumentException("Currency mismatch");
            }
            return new Money(m.Amount - m2.Amount, m.Currency);
        }

        public Money MultiplyBy(double multiplier)
        {
            return MultiplyBy((decimal)multiplier);
        }
        public Money MultiplyBy(int multiplier)
        {
            return MultiplyBy((decimal)multiplier);
        }

        public Money MultiplyBy(decimal multiplier)
        {
            return new Money(Amount * multiplier, Currency);
        }

        /// <summary>
        /// Currency is compatible if the same or either money object has zero value.
        /// </summary>
        private static bool AreCompatibleCurrencies(Money m, Money m2)
        {
            return IsZero(m.Amount) || IsZero(m2.Amount) || m.Currency.Equals(m2.Currency);
        }

        private static bool IsZero(decimal testedValue)
        {
            return decimal.Zero.CompareTo(testedValue) == 0;
        }

        public static bool operator <(Money m, Money m2)
        {
            return m.Amount.CompareTo(m2.Amount) < 0;
        }

        public static bool operator >(Money m, Money m2)
        {
            return m.Amount.CompareTo(m2.Amount) > 0;
        }

        public static bool operator >=(Money m, Money m2)
        {
            return m.Amount.CompareTo(m2.Amount) >= 0;
        }

        public static bool operator <=(Money m, Money m2)
        {
            return m.Amount.CompareTo(m2.Amount) <= 0;
        }

        public override string ToString()
        {
            return string.Format("{0}.2f {1}", Amount, Currency);
        }
    }
}
