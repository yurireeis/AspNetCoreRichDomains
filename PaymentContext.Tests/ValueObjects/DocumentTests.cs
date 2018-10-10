using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
    // add set class
    [TestClass]
    public class DocumentTests
    {
        // add test method
        // Don't forget to use RED, GREEN, REFACTORY approach
        [TestMethod]
        [DataTestMethod]
        [DataRow("000")]
        public void ShouldReturnErrorWhenCPFIsInvalid(string cpf)
        {
            var doc = new Document(cpf, EDocumentType.CPF);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("00000000000")]
        [DataRow("15266980052")]
        [DataRow("48034572047")]
        public void ShouldReturnSuccessWhenCPFIsValid(string cpf)
        {
            var doc = new Document(cpf, EDocumentType.CPF);
            Assert.IsTrue(doc.Valid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("0000000000000")]
        public void ShouldReturnErrorWhenCNPJIsInvalid(string cpf)
        {
            var doc = new Document(cpf, EDocumentType.CNPJ);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("00000000000000")]
        public void ShouldReturnSuccessWhenCNPJIsValid(string cpf)
        {
            var doc = new Document(cpf, EDocumentType.CNPJ);
            Assert.IsTrue(doc.Valid);
        }
    }
}
