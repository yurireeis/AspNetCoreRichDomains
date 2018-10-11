using System;
using System.Linq.Expressions;
using PaymentContext.Domain.Entity;

namespace PaymentContext.Domain.Queries
{
    public class StudentQueries
    {
        // using expressions only (Don't use SQL strings)
        // the method above bring student by document
        public static Expression<Func<Student, bool>> GetProductsInStock(string document)
        {
            return x => x.Document.Number == document;
        }
    }
}
