using System;
using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entity
{
    public class Subscription : Entities
    {
        public DateTime CreateDate { get; private set; }
        public DateTime LastUpdateDate { get; private set; }
        public DateTime? ExpireDate { get; private set; }
        public DateTime? PaidDate { get; private set; }
        public bool Active { get; private set; }
        public IReadOnlyCollection<PaymentMethod> PaymentMethods { get { return _PaymentMethods.ToArray(); } }
        private IList<PaymentMethod> _PaymentMethods;
        private DateTime dateTime;

        public Subscription(DateTime? expireDate)
        {
            CreateDate = DateTime.Now;
            LastUpdateDate =  DateTime.Now;
            ExpireDate = expireDate;
            ActivateSubscription(true);
            _PaymentMethods = new List<PaymentMethod>();
        }

        public void ActivateSubscription(bool status)
        {
            Active = status;
            LastUpdateDate = DateTime.Now;
        }
        public void AddPaymentMethod(PaymentMethod paymentMethod)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(DateTime.Now, paymentMethod.PaidDate, "Subscription.PaidDate", "Payment date is older than current Date.")
            );
            _PaymentMethods.Add(paymentMethod);
        }
    }
}
