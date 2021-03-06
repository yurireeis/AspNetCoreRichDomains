using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public string PublicArea { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
        public Address(
            string publicArea,
            string number,
            string neighborhood,
            string city,
            string state,
            string country,
            string zipCode
        ){
            PublicArea = publicArea;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(PublicArea, 3, "Address.PublicArea", "PublicArea (street) is invalid.")
            );
        }
    }
}
