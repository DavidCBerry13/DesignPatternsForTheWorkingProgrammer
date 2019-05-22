using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessorImproved
{
    public class CreditCardPaymentTypeHandler : IPaymentHandler
    {

        public CreditCardPaymentTypeHandler(ICreditCardService creditCardService, IPaymentsDao paymentsDao) 
        {
            this.creditCardService = creditCardService;
            this.paymentsDao = paymentsDao;
        }


        private ICreditCardService creditCardService;
        private IPaymentsDao paymentsDao;



        public bool CanProcessPayment(BasePaymentData paymentData)
        {
            return paymentData.PaymentType == PaymentType.CREDIT_CARD;
        }

        public PaymentResult ProcessPayment(BasePaymentData paymentData)
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
