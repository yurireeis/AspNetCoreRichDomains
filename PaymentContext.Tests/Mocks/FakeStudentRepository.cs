using System.Collections;
using System.Collections.Generic;
using PaymentContext.Domain.Entity;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Mocks
{
    public class FakeStudentRepository : IStudentRepository
    {
        public void CreateSubscription(Student student) { }

        public bool DocumentExists(string document)
        {
            if (document == "11111111111") { return true; }
            return false;
        }

        public bool EmailExists(string email)
        {
            if (email == "hello@balta.io") { return true; }
            return false;
        }

        public IList<Student> GetStudents()
        {
            var students = new List<Student>();
            for (int i = 0; i < 5; i++)
            {
                students.Add(new Student(
                    new Name($"Yuri {i}", $"Reis {i}"),
                    new Email($"yuri{i}@me.com"),
                    new Address($"Rua {i}", $"{i}", $"Bairro {i}", $"Cidade {i}", $"Estado {i}", $"Pais {i}", $"8800000{i}"),
                    new Document($"00000000{i}", EDocumentType.CPF)
                ));
            }
            return students;
        }
    }
}
