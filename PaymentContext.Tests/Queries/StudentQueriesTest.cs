using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Queries;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests.Queries
{
    [TestClass]
    public class StudentQueriesTest
    {
        private FakeStudentRepository _StudentRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            _StudentRepository = new FakeStudentRepository();
        }

        [TestMethod]
        public void ShouldReturnNullWhenDocumentDoesNotExists()
        {
            var query = StudentQueries.GetStudentInfo("048904940");
            var student = _StudentRepository.GetStudents().AsQueryable().Where(query).FirstOrDefault();
            Assert.AreEqual(null, student);
        }

        [TestMethod]
        public void ShouldReturnStudentWhenDocumentExists()
        {
            var existentDoc = _StudentRepository.GetStudents()[0].Document.Number;
            var query = StudentQueries.GetStudentInfo(existentDoc);
            var student = _StudentRepository.GetStudents().AsQueryable().Where(query).FirstOrDefault();
            Assert.AreNotEqual(null, student);
        }
    }
}
