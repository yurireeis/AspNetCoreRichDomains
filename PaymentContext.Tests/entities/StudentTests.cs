using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entity;

namespace PaymentContext.Tests.entities
{
    public class StudentTests
    {
        [TestMethod]
        public void AddSignature()
        {
            var subscription = new Subscription(new DateTime());
            var student = new Student(firstName: "Yuri", lastName: "Reis", email: "yuri@me.com");
            student.SetEmail("teste");
            student.AddSubscription(subscription);
            var payment = new PayPal();
        }
    }
}
