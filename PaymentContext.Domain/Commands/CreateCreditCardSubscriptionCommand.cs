using System;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands
{
    public class CreateCreditCardSubscriptionCommand : Notifiable, ICommand
    {
        // creating paypal signature
        // nothing more that joining all information needed to create a PayPal Subscription (in this example)
        // nothing more than a transport for objects (from one layer to another)
        // all information that I need to create a paypal payment
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PayerEmailAddress { get; set; }
        public string PublicArea { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string Owner { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime SubscriptionExpireDate { get; set; }
        public string PayerDocument { get; set; }
        public EDocumentType PayerDocumentType { get; set; }
        public double Limit { get; set; }
        public string ChargingAddress { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CardExpireDate { get; set; }
        public double Interest { get; set; }
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
