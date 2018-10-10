using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entity;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {

        [TestMethod]
        public void ShoudReturnErrorWhenSubscriptionHasntNoPaymentMethods()
        {
            Assert.Fail();
        }
        
        [TestMethod]
        public void ShouldReturnErrorWhenHasAnActiveSubscription()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHasntAnActiveSubscription()
        {
            Assert.Fail();
        } 
    }
}
