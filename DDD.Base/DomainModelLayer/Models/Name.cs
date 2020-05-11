using System;
using System.Collections.Generic;

namespace DDD.Base.DomainModelLayer.Models
{
    public class Name : ValueObject
    {
        public Name(string firstName, string surname)
        {
            if (String.IsNullOrEmpty(firstName)) throw new ArgumentNullException("First name is invalid");
            if (String.IsNullOrEmpty(surname)) throw new ArgumentNullException("Surname is invalid");

            this.FirstName = firstName;
            this.Surname = surname;
        }

        public string FirstName { get; protected set; }

        public string Surname { get; protected set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName.ToUpper();
            yield return Surname.ToUpper();
        }

        public override string ToString()
        {
            return String.Format(
                "firstName:{0};;surname:{1}", FirstName, Surname
            );
        }
    }
}
