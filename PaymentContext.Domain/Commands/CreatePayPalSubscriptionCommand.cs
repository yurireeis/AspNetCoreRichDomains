using System;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands
{
    public class CreatePayPalSubscriptionCommand : Notifiable, ICommand
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
        public DateTime paidDate { get; set; }
        public DateTime expireDate { get; set; }
        public string PayerDocument { get; set; }
        public EDocumentType PayerDocumentType { get; set; }
        public double total { get; set; }
        public double totalPaid { get; set; }
        public string transationCode { get; set; }
        public double Total { get; set; }
        public double TotalPaid { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsLowerOrEqualsThan(0, Total, "Payment.Total", "Payment must be a value greater than zero.")
                .IsGreaterThan(Total, TotalPaid, "Payment.TotalPaid", "Payment value is lower than total")
            );
        }
    }
}
