using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PaymentContext.Tests.ValueObjects
{
    // add set class
    [TestClass]
    public class DocumentTests
    {
        // add test method
        // Don't forget to use RED, GREEN, REFACTORY approach
        [TestMethod]
        public void ShouldReturnErrorWhenCPFIsInvalid()
        {
            Assert.Fail();
        }

        public void ShouldReturnErrorWhenCPFIsValid()
        {
            Assert.Fail();
        }

        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {
            Assert.Fail();
        }

        public void ShouldReturnErrorWhenCNPJIsValid()
        {
            Assert.Fail();
        }
    }
}
