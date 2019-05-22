using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessorCOR
{
    public class CreditCardPaymentData : BasePaymentData
    {
        public CreditCardPaymentData()
        {
            this.PaymentType = PaymentType.CREDIT_CARD;
        }

        public String CardholderName { get; set; }

        public String CreditCardNumber { get; set; }

        public String ExpirationDate { get; set; }

        public String Cvv { get; set; }

        public String BillingZipCode { get; set; }
    }
}
