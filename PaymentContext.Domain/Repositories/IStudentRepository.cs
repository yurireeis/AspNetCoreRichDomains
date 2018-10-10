namespace PaymentContext.Domain.Repositories
{
    // creating an interface to be concretized with any framework you want
    public interface IStudentRepository
    {
         bool DocumentExists(string Document);
         bool EmailExists(string Email);
         void CreateSubscription(IStudentRepository student);
    }
}
