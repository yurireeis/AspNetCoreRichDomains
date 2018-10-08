using System;

namespace PaymentContext.Domain.Entity
{
    public abstract class Card : PaymentMethod
    {
        protected Card(
            DateTime paidDate,
            DateTime expireDate,
            double total,
            double totalPaid,
            string cardNumber,
            string owner
        ) : base(
            paidDate,
            expireDate,
            total,
            totalPaid
        ) {
            CardNumber = cardNumber;
            Owner = owner;
        }

        public string CardNumber { get; private set; }
        public string Owner { get; private set; }
    }
}
