using System;
using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
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

            // this method concatenate the notifications
            AddNotifications(Name, Document, Email, Address);
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
            // abort all another subscriptions and set new as default
            // when you set an IReadOnlyCollection, you must create a private IList property to deal with it
            bool hasSubscriptionActive = false;

            foreach (var sub in Subscriptions) { if (sub.Active) { hasSubscriptionActive = true; } }

            _Subscriptions.Add(subscription);

            AddNotifications(new Contract()
                .Requires()
                .IsFalse(hasSubscriptionActive, "Student.Subscriptions", "You are already subscribed.")
                .IsGreaterThan(0, subscription.PaymentMethods.Count, "Student.Subscription.PaymentMethods", "This subscription Doesn't have any payment method.")
            );
        }
    }
}
