using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessorImproved
{
    public class PaymentsDao : IPaymentsDao
    {


        public int SaveSuccessfulCreditCardPayment(CreditCardPaymentData creditCardData, CreditCardResult result)
        {
            // This would save to a database

            return 10;
        }


        public int SaveFailedCreditCardPayment(CreditCardPaymentData creditCardData, CreditCardResult result)
        {
            // This would save to a database
            return 15;
        }


        public int SaveSuccessfulEftPayment(EftPaymentData eftData, EftAuthorization result)
        {
            // This would save to a database

            return 20;
        }


        public int SaveFailedEftPayment(EftPaymentData eftData, EftAuthorization result)
        {
            // This would save to a database
            return 25;
        }


        public int SaveCheckPayment(CheckPaymentData checkData)
        {
            // This would save to a database

            return 30;
        }


        public int SaveUnknownPaymentType(BasePaymentData paymentData)
        {
            // Save an unknown Payment
            return 40;
        }

    }
}
