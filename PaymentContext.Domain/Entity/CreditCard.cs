using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entity
{
    public class CreditCard : Card
    {
        protected CreditCard(
            DateTime paidDate,
            DateTime expireDate,
            Document document,
            double total,
            double totalPaid,
            string cardNumber,
            string owner,
            double limit,
            string chargingAddress,
            DateTime dueDate,
            DateTime cardExpireDate,
            double interest
        ) : base(
            paidDate,
            expireDate,
            document,
            total,
            totalPaid,
            cardNumber,
            owner
        ){
            Limit = limit;
            ChargingAddress = chargingAddress;
            DueDate = dueDate;
            Interest = interest;
        }

        public double Limit { get; private set; }
        public string ChargingAddress { get; private set; }
        public DateTime DueDate { get; private set; }
        public DateTime CardExpireDate { get; private set; }
        public double Interest { get; private set; }
    }
}
