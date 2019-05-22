using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessorCOR
{
    public interface IPaymentsDao
    {

        int SaveSuccessfulCreditCardPayment(CreditCardPaymentData creditCardData, CreditCardResult result);


        int SaveFailedCreditCardPayment(CreditCardPaymentData creditCardData, CreditCardResult result);


        int SaveSuccessfulEftPayment(EftPaymentData eftData, EftAuthorization result);


        int SaveFailedEftPayment(EftPaymentData eftData, EftAuthorization result);


        int SaveCheckPayment(CheckPaymentData checkData);

    }
}
