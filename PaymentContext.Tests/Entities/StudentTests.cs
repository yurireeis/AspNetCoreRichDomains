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
        private Student _Student;
        private Subscription _Subscription;
        private Name _Name;
        private Document _Document;
        private Email _Email;
        private Address _Address;

        [TestInitialize]
        public void TestInitialize(){
            _Name = new Name("Yuri", "Reis");
            _Document = new Document("00000000000", EDocumentType.CPF);
            _Email = new Email("batman@dc.com");
            _Address = new Address("Rua X", "2", "Bairro", "Florianopolis", "Santa Catarina", "Brasil", "88000000");
        }

        [TestMethod]
        public void ShoudReturnErrorWhenStudentSubscriptionHasNotPaymentMethods()
        {
            // _Student = new Student(_Name, _Email, _Address, _Document);
            // _Subscription = new Subscription(DateTime.Now);
            // _Student.AddSubscription(_Subscription);
            // Assert.IsTrue(_Student.Invalid);
        }

        [TestMethod]
        [DataTestMethod]
        public void ShouldReturnSuccessWhenStudentHasAnActiveSubscriptionAndPaymentMethod()
        {
            _Student = new Student(_Name, _Email, _Address, _Document);
            _Subscription = new Subscription(DateTime.Now);
            var payment = new Boleto(DateTime.Now, DateTime.Now.AddDays(3), new Document("0000000000", EDocumentType.CPF), 100, 100, "079909090797090");
            _Subscription.AddPaymentMethod(payment);
            _Student.AddSubscription(_Subscription);
            Assert.IsTrue(_Student.Valid);
        }
    }
}
