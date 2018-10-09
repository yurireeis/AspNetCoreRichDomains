using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entity
{
    public class Boleto : PaymentMethod
    {
        public Boleto(
            DateTime paidDate,
            DateTime expireDate,
            Document document,
            double total,
            double totalPaid,
            string barcode
        ) : base(
            paidDate,
            expireDate,
            document,
            total,
            totalPaid
        ){
            setBoletoNumber();
        }

        private void setBoletoNumber() => BoletoNumber = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();

        public string BarCode { get; private set; }
        public string BoletoNumber { get; private set; }
    }
}
