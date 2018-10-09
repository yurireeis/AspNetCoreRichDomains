using System;
using System.Collections.Generic;
using System.Linq;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entity
{
    public class Student : Entities
    {
        public Student(
            Name name,
            Email email,
            Address address,
            Document document
        ) : base() {
            this.Name = name;
            this.Email = email;
            this.Address = address;
            this.Document = document;
            _Subscriptions = new List<Subscription>();
        }
        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public Document Document { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get { return _Subscriptions.ToArray(); } }
        private IList<Subscription> _Subscriptions;

        public void AddSubscription(Subscription subscription)
        {
            // if has already an active subscriptions, abort
            if(true) { throw new Exception(); }

            // abort all another subscriptions and set new as default
            foreach (var sub in Subscriptions) { sub.Activate(false); }

            // when you set an IReadOnlyCollection, you must create a private IList property to deal with it
            _Subscriptions.Add(subscription);
        }
    }
}
