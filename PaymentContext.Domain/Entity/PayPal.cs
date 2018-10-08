using System;

namespace PaymentContext.Domain.Entity
{
    public class PayPal : PaymentMethod
    {
        public PayPal(
            DateTime paidDate,
            DateTime expireDate,
            double total,
            double totalPaid,
            string transationCode
        ) : base(
            paidDate,
            expireDate,
            total,
            totalPaid
        ){
            TransactionCode = transationCode;
        }

        public string TransactionCode { get; private set; }
    }
}
