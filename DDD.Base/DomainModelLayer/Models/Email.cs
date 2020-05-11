using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DDD.Base.DomainModelLayer.Models
{
    public class Email: ValueObject
    {
        public string Value { get; private set; }
        public Email(string value)
        {
            if (!(IsValidEmail(value))) throw new Exception("Invalid email");

            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value.ToUpper();
        }

        public bool IsValidEmail(string email)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }
    }
}
