using System;
using System.Collections.Generic;
using System.Linq;

namespace PaymentContext.Domain.Entity
{
    public class Subscription
    {
        public Subscription(DateTime? expireDate)
        {
            CreateDate = DateTime.Now;
            LastUpdateDate =  DateTime.Now;
            ExpireDate = expireDate;
            Activate(true);
            _PaymentMethods = new List<PaymentMethod>();
        }

        public DateTime CreateDate { get; private set; }
        public DateTime LastUpdateDate { get; private set; }
        public DateTime? ExpireDate { get; private set; }
        public bool Active { get; private set; }
        public IReadOnlyCollection<PaymentMethod> PaymentMethods { get { return _PaymentMethods.ToArray(); } }
        private IList<PaymentMethod> _PaymentMethods;
        private DateTime dateTime;

        public void Activate(bool status)
        {
            Active = status;
            LastUpdateDate = DateTime.Now;
        }
        public void AddPaymentMethod(PaymentMethod paymentMethod) => _PaymentMethods.Add(paymentMethod);
    }
}
