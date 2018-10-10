using System;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands
{
    public class CreateBoletoSubscriptionCommand : Notifiable, ICommand
    {
        // creating paypal signature
        // nothing more that joining all information needed to create a PayPal Subscription (in this example)
        // nothing more than a transport for objects (from one layer to another)
        // all information that I need to create a paypal payment
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PayerDocument { get; set; }
        public EDocumentType PayerDocumentType { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime SubscriptionExpireDate { get; set; }
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
        public double Total { get; set; }
        public double TotalPaid { get; set; }

        public void Validate()
        {
            // set validations here
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName, 3, "Name.First", "Name must contain at least three characters.")
                .HasMinLen(LastName, 3, "Name.Last", "Name must contain at least three characters.")
                .IsLowerOrEqualsThan(0, Total, "Payment.Total", "Payment must be a value greater than zero.")
                .IsGreaterThan(Total, TotalPaid, "Payment.TotalPaid", "Payment value is lower than total")
            );
        }
    }
}
