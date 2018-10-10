using System;
using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entity;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler : 
        Notifiable,
        IHandler<CreateBoletoSubscriptionCommand>,
        IHandler<CreatePayPalSubscriptionCommand>,
        IHandler<CreateCreditCardSubscriptionCommand>,
        IHandler<CreateDebitCardSubscriptionCommand>
    {
        private readonly IStudentRepository _Repository;
        private readonly IEmailService _EmailService;

        public SubscriptionHandler(
            IStudentRepository repository,
            IEmailService emailService
        ){
            _Repository = repository;
            _EmailService = emailService;
        }

        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            // fail fast validation
            command.Validate();

            if (command.Invalid) {
                AddNotifications(command);
                return new CommandResult(false, "It's not possible to realize your subscribe.");
            }

            // verify if the document is already exists (go in database)
            if (_Repository.DocumentExists(command.PayerDocument))
            {
                AddNotifications(command);
                return new CommandResult(false, "CPF already exists.");
            }


            // verify if e-mail is already registered

            if (_Repository.EmailExists(command.PayerEmailAddress))
            {
                AddNotifications(command);
                return new CommandResult(false, "Email already exists.");
            }

            // generate VO's
            var name = new Name(command.FirstName, command.LastName);
            var email = new Email(command.PayerEmailAddress);
            var address = new Address(command.PublicArea, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);
            var document = new Document(command.PayerDocument, command.PayerDocumentType);

            // generate entities
            var student = new Student(name, email, address, document);
            var subscription = new Subscription(command.SubscriptionExpireDate);
            var payment = new Boleto(
                command.PaidDate,
                command.ExpireDate,
                new Document(command.PayerDocument, command.PayerDocumentType),
                command.Total,
                command.TotalPaid,
                command.BarCode
            );

            // relationships
            subscription.AddPaymentMethod(payment);
            student.AddSubscription(subscription);

            // join validations
            AddNotifications(name, document, email, address, student, subscription, payment);

            // validate notifications
            if(Invalid) { return new CommandResult(false, "It's not possible to finalize your subscription."); }

            // save informations
            _Repository.CreateSubscription(student);

            // send welcome email
            _EmailService.send(student.ToString(), student.Email.Address, "Congratulations for subscribing", "Welcome!");

            // return infos
            return new CommandResult(true, "Subscribe done with success");
        }

        public ICommandResult Handle(CreatePayPalSubscriptionCommand command)
        {   
            // fail fast validation
            command.Validate();

            if (command.Invalid) {
                AddNotifications(command);
                return new CommandResult(false, "It's not possible to realize your subscribe.");
            }

            // verify if the document is already exists (go in database)
            if (_Repository.DocumentExists(command.PayerDocument))
            {
                AddNotifications(command);
                return new CommandResult(false, "CPF already exists.");
            }

            // verify if e-mail is already registered
            if (_Repository.EmailExists(command.PayerEmailAddress))
            {
                AddNotifications(command);
                return new CommandResult(false, "Email already exists.");
            }

            // generate VO's
            var name = new Name(command.FirstName, command.LastName);
            var email = new Email(command.PayerEmailAddress);
            var address = new Address(command.PublicArea, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);
            var document = new Document(command.PayerDocument, command.PayerDocumentType);

            // generate entities
            var student = new Student(name, email, address, document);
            var subscription = new Subscription(command.SubscriptionExpireDate);
            var payment = new PayPal(
                command.PaidDate,
                command.ExpireDate,
                new Document(command.PayerDocument, command.PayerDocumentType),
                command.Total,
                command.TotalPaid,
                command.transationCode
            );

            // relationships
            subscription.AddPaymentMethod(payment);
            student.AddSubscription(subscription);

            // join validations
            AddNotifications(name, document, email, address, student, subscription, payment);

            if (Invalid) { return new CommandResult(false, "it's not possible to fialize your subscription."); }

            // save informations
            _Repository.CreateSubscription(student);

            // send welcome email
            _EmailService.send(student.ToString(), student.Email.Address, "Congratulations for subscribing", "Welcome!");

            // return infos
            return new CommandResult(true, "Subscribe done with success");
        }

        public ICommandResult Handle(CreateCreditCardSubscriptionCommand command)
        {
            // fail fast validation
            command.Validate();

            if (command.Invalid) {
                AddNotifications(command);
                return new CommandResult(false, "It's not possible to realize your subscribe.");
            }

            // verify if the document is already exists (go in database)
            if (_Repository.DocumentExists(command.PayerDocument))
            {
                AddNotifications(command);
                return new CommandResult(false, "CPF already exists.");
            }


            // verify if e-mail is already registered
            if (_Repository.EmailExists(command.PayerEmailAddress))
            {
                AddNotifications(command);
                return new CommandResult(false, "Email already exists.");
            }

            // generate VO's
            var name = new Name(command.FirstName, command.LastName);
            var email = new Email(command.PayerEmailAddress);
            var address = new Address(command.PublicArea, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);
            var document = new Document(command.PayerDocument, command.PayerDocumentType);

            // generate entities
            var student = new Student(name, email, address, document);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new CreditCard(
                command.PaidDate,
                command.ExpireDate,
                new Document(command.PayerDocument, command.PayerDocumentType),
                command.Total,
                command.TotalPaid,
                command.Number,
                command.Owner,
                command.Limit,
                command.ChargingAddress,
                command.DueDate,
                command.CardExpireDate,
                command.Interest
            );

            // relationships
            subscription.AddPaymentMethod(payment);
            student.AddSubscription(subscription);

            // check notifications
            if (Invalid) { return new CommandResult(false, "It's not possible to finalize your subscription."); }

            // join validations
            AddNotifications(name, document, email, address, student, subscription, payment);

            // save informations
            _Repository.CreateSubscription(student);

            // send welcome email
            _EmailService.send(student.ToString(), student.Email.Address, "Congratulations for subscribing", "Welcome!");

            // return infos
            return new CommandResult(true, "Subscribe done with success");
        }

        public ICommandResult Handle(CreateDebitCardSubscriptionCommand command)
        {
            // fail fast validation
            command.Validate();

            if (command.Invalid) {
                AddNotifications(command);
                return new CommandResult(false, "It's not possible to realize your subscribe.");
            }

            // verify if the document is already exists (go in database)
            if (_Repository.DocumentExists(command.PayerDocument))
            {
                AddNotifications(command);
                return new CommandResult(false, "CPF already exists.");
            }


            // verify if e-mail is already registered
            if (_Repository.EmailExists(command.PayerEmailAddress))
            {
                AddNotifications(command);
                return new CommandResult(false, "Email already exists.");
            }

            // generate VO's
            var name = new Name(command.FirstName, command.LastName);
            var email = new Email(command.PayerEmailAddress);
            var address = new Address(command.PublicArea, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);
            var document = new Document(command.PayerDocument, command.PayerDocumentType);

            // generate entities
            var student = new Student(name, email, address, document);
            var subscription = new Subscription(command.SubscriptionExpireDate);
            var payment = new DebitCard(
                DateTime.Now,
                DateTime.Now.AddDays(5),
                new Document(command.PayerDocument, command.PayerDocumentType),
                command.Total,
                command.TotalPaid,
                command.Number,
                command.Owner
            );

            // relationships
            subscription.AddPaymentMethod(payment);
            student.AddSubscription(subscription);

            // check notifications
            if (Invalid) { return new CommandResult(false, "It's not possible to finalize your subscription."); }

            // join validations
            AddNotifications(name, document, email, address, student, subscription, payment);

            // save informations
            _Repository.CreateSubscription(student);

            // send welcome email
            _EmailService.send(student.ToString(), student.Email.Address, "Congratulations for subscribing", "Welcome!");

            // return infos
            return new CommandResult(true, "Subscribe done with success");
        }
    }
}
