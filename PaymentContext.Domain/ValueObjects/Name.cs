using System;
using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string first, string last)
        {
            First = first;
            Last = last;
        }

        public string First { get; private set; }
        public string Last { get; private set; }

        private bool HasMinimalQuantityOfChars(uint quantity, string propertyValue)
        {
            if (string.IsNullOrEmpty(propertyValue) || propertyValue.Length <= quantity) {
                AddNotification(propertyValue, "Not Valid");
                return false;
            }
            return true;
        }

        public override string ToString() => $"{First} {Last}";
    }
}
