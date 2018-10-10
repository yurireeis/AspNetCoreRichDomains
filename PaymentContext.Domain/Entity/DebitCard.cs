using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entity
{
    public class DebitCard : Card
    {
        public double Balance { get; set; }
        public double SpecialCredit { get; set; }
        public double SpecialCreditInterest { get; set; }
        protected DebitCard(
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
            totalPaid,
            cardNumber,
            owner
        ){}
    }
}
