using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document : ValueObject
    {
    private const int CNPJ_LENGTH = 14;
    private const int CPF_LENGTH = 11;

    public EDocumentType Type { get; private set; }
        public string Number { get; private set; }
        public Document(string number, EDocumentType type)
        {
            Number = number;
            Type = type;
            AddNotifications(new Contract().Requires().IsTrue(IsValid(), "Document.Number", "Invalid Document."));
        }

        private bool IsValid()
        {
            if (Type == EDocumentType.CPF && Number.Length < CPF_LENGTH) { return false; }

            if (Type == EDocumentType.CNPJ && Number.Length < CNPJ_LENGTH) { return false; }

            return true;
        }
    }
}
