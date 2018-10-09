using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entity
{
    public class PayPal : PaymentMethod
    {
        public PayPal(
            DateTime paidDate,
            DateTime expireDate,
            Document document,
            double total,
            double totalPaid,
            string transationCode
        ) : base(
            paidDate,
            expireDate,
            document,
            total,
            totalPaid
        ){
            TransactionCode = transationCode;
        }

        public string TransactionCode { get; private set; }
    }
}
