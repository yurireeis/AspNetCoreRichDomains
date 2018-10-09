using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entity
{
    public abstract class PaymentMethod
    {
        public string Number { get; private set; }
        public DateTime PaidDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public Document Document { get; private set; }
        public double Total { get; private set; }
        public double TotalPaid { get; private set; }
        public PaymentMethod(
            DateTime paidDate, 
            DateTime expireDate,
            Document document,
            double total, 
            double totalPaid
        ) {
            SetGuid();
            PaidDate = paidDate;
            ExpireDate = expireDate;
            Total = total;
            TotalPaid = totalPaid;            
        }

        private void SetGuid()
        {
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
        }
    }
}
