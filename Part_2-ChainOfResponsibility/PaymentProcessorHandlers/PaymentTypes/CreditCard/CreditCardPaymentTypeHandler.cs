using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessorCOR
{
    public class CreditCardPaymentTypeHandler : PaymentTypeHandlerBase
    {

        public CreditCardPaymentTypeHandler(ICreditCardService creditCardService, IPaymentsDao paymentsDao) 
        {
            this.creditCardService = creditCardService;
            this.paymentsDao = paymentsDao;
        }


        private ICreditCardService creditCardService;
        private IPaymentsDao paymentsDao;



        protected override bool CanProcessPayment(BasePaymentData paymentData)
        {
            return paymentData.PaymentType == PaymentType.CREDIT_CARD;
        }

        protected override PaymentResult ExecutePaymentProcess(BasePaymentData paymentData)
        {
            CreditCardPaymentData creditCardData = paymentData as CreditCardPaymentData;

            CreditCardResult authResult = this.creditCardService.AuthorizeCreditCard(creditCardData.CreditCardNumber,
                creditCardData.ExpirationDate, creditCardData.Cvv, creditCardData.BillingZipCode, creditCardData.Amount);

            if (authResult.Authorized == true)
            {
                int referenceNumber = paymentsDao.SaveSuccessfulCreditCardPayment(creditCardData, authResult);

                PaymentResult paymentResult = new PaymentResult()
                {
                    CustomerAccountNumber = creditCardData.CustomerAccountNumber,
                    PaymentDate = creditCardData.PaymentDate,
                    Success = authResult.Authorized,
                    ReferenceNumber = referenceNumber
                };
                return paymentResult;
            }
            else
            {
                int referenceNumber = paymentsDao.SaveFailedCreditCardPayment(creditCardData, authResult);

                PaymentResult paymentResult = new PaymentResult()
                {
                    CustomerAccountNumber = creditCardData.CustomerAccountNumber,
                    PaymentDate = creditCardData.PaymentDate,
                    Success = authResult.Authorized,
                    ReferenceNumber = referenceNumber
                };
                return paymentResult;
            }
        }
    }
}
