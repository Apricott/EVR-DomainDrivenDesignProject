namespace DDD.Base.DomainModelLayer.Models
{
    // Żródło: https://bottega.com.pl/ddd-cqrs-sample-project
    public static class MoneyExtensions
    {
        public static Money PLN(this int value)
        {
            return new Money(value, "PLN");
        }

        public static Money Euro(this int value)
        {
            return new Money(value, "EUR");
        }

        public static Money Usd(this int value)
        {
            return new Money(value, "USD");
        }

        public static Money PLN(this decimal value)
        {
            return new Money(value, "PLN");
        }

        public static Money Euro(this decimal value)
        {
            return new Money(value, "EUR");
        }

        public static Money Usd(this decimal value)
        {
            return new Money(value, "USD");
        }

        public static Money PLN(this double value)
        {
            return new Money((decimal)value, "PLN");
        }

        public static Money Euro(this double value)
        {
            return new Money((decimal)value, "EUR");
        }

        public static Money Usd(this double value)
        {
            return new Money((decimal)value, "USD");
        }
    }
}
