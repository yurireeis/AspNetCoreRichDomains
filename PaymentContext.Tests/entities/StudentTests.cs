using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entity;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.entities
{
    public class StudentTests
    {
        [TestMethod]
        public void AddSignature() {
          var name = new Name("Yuri", "Reis");
          foreach (var notification in name.Notifications)
          {
              Console.WriteLine(notification.Message);
          }
        }
    }
}
