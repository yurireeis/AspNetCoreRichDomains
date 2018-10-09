using System;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string first, string last)
        {
          SetFirst(first);
          SetLast(last);
        }
        public string First { get; private set; }
        public string Last { get; private set; }

        public void SetFirst(string firstName)
        {
            if (HasMinimalQuantityOfChars(3, firstName)) { First = firstName; }
        }

        public void SetLast(string lastName)
        {
            if (HasMinimalQuantityOfChars(3, lastName)) { Last = lastName; }
        }

        private bool HasMinimalQuantityOfChars(uint quantity, string propertyValue)
        {
            if (string.IsNullOrEmpty(propertyValue) || propertyValue.Length <= quantity) {
                AddNotification(propertyValue, "Not Valid");
                return false;
            }
            return true;
        }
    }
}
