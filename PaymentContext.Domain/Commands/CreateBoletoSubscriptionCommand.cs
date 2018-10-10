using System;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Commands
{
    public class CreateBoletoSubscriptionCommand
    {
        // creating paypal signature
        // nothing more that joining all information needed to create a PayPal Subscription (in this example)
        // nothing more than a transport for objects (from one layer to another)
        // all information that I need to create a paypal payment
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PayerEmailAddress { get; set; }
        public string PublicArea { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
        public string BarCode { get; private set; }
        public string BoletoNumber { get; private set; }
    }
}
