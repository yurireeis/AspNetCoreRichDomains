using System;

namespace PaymentContext.Domain.Entity
{
    public abstract class PaymentMethod
    {
        public PaymentMethod(
            DateTime paidDate, 
            DateTime expireDate, 
            double total, 
            double totalPaid
        ) {
            SetGuid();
            PaidDate = paidDate;
            ExpireDate = expireDate;
            Total = total;
            TotalPaid = totalPaid;
        }

        // payment must be boleto, Card (Credit or Debit) or PayPal
        public string Number { get; private set; }
        public DateTime PaidDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public double Total { get; private set; }
        public double TotalPaid { get; private set; }

        private void SetGuid()
        {
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
        }
    }
}
