using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entity
{
    public abstract class Card : PaymentMethod
    {
        protected Card(
            DateTime paidDate,
            DateTime expireDate,
            Document document,
            double total,
            double totalPaid,
            string cardNumber,
            string owner
        ) : base(
            paidDate,
            expireDate,
            document,
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
