using System;
using System.Collections.Generic;
using System.Linq;

namespace PaymentContext.Domain.Entity
{
    public class Student
    {
        public Student(string firstName, string lastName, string email)
        {
          SetFirstName(firstName);
          SetLastName(lastName);
          SetEmail(email);
          _Subscriptions = new List<Subscription>();
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get { return _Subscriptions.ToArray(); } }
        private IList<Subscription> _Subscriptions;
        public void SetFirstName(string firstName)
        {
            if (firstName.Length >= 3) { throw new Exception("Name must have at least 3 characters"); }
            FirstName = firstName;
        }

        // set regex for email validation here
        public void SetEmail(string email) => Email = email;

        public void SetLastName(string lastName)
        {
            if (lastName.Length >= 3) { throw new Exception("Name must have at least 3 characters"); }
            LastName = lastName;
        }

        public void AddSubscription(Subscription subscription)
        {
            // if has already an active subscriptions, abort
            // abort all another subscriptions and set new as default
            foreach (var sub in Subscriptions) { sub.Activate(false); }

            // when you set an IReadOnlyCollection, you must create a private IList property to deal with it
            _Subscriptions.Add(subscription);
        }
    }
}
