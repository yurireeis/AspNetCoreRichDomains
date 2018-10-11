using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests.Handlers
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            // using mocks (fake repos for testing)
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();

            command.FirstName = "Yuri";
            command.LastName = "Reis";
            command.PayerDocument = "00000000000";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddDays(5);
            command.SubscriptionExpireDate = DateTime.Now.AddMonths(1);
            command.PayerEmailAddress = "yuri@men.com";
            command.PublicArea = "Rua X";
            command.Number = "23";
            command.Neighborhood = "Bairro";
            command.City = "Cidade";
            command.State = "Estado";
            command.Country = "País";
            command.ZipCode = "88000000";
            command.BoletoNumber = "13004984034066406406";
            command.Total = 100;
            command.TotalPaid = 100;
            command.BarCode = "123456789123";

            handler.Handle(command);
            Assert.AreEqual(false, handler.Valid);
        }
    }
}
