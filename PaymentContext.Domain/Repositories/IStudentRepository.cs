using PaymentContext.Domain.Entity;

namespace PaymentContext.Domain.Repositories
{
    // creating an interface to be concretized with any framework you want
    public interface IStudentRepository
    {
        bool DocumentExists(string Document);
        bool EmailExists(string Email);
        void CreateSubscription(Student student);
    }
}
