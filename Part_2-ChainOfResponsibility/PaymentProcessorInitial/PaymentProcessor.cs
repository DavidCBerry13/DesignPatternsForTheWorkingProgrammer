using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessorInitial
{
    public class PaymentProcessor
    {
        public PaymentProcessor(ICreditCardProcessor ccProcessor, IEftProcessor eftProcessor, IPaymentsDao paymentsDao)
        {
            this.creditCardProcessor = ccProcessor;
            this.eftProcessor = eftProcessor;
            this.paymentsDao = paymentsDao;
        }


        private ICreditCardProcessor creditCardProcessor;
        private IEftProcessor eftProcessor;
        private IPaymentsDao paymentsDao;



        public PaymentResult ProcessPayment(PaymentDataBase paymentData)
        {
            if ( paymentData.PaymentType == PaymentType.CREDIT_CARD)
            {
                CreditCardPaymentData creditCardData = paymentData as CreditCardPaymentData;

                CreditCardResult authResult = this.creditCardProcessor.AuthorizeCreditCard(creditCardData.CreditCardNumber,
                    creditCardData.ExpirationDate, creditCardData.Cvv, creditCardData.BillingZipCode, creditCardData.Amount);

                if ( authResult.Authorized == true)
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
            else if (paymentData.PaymentType == PaymentType.EFT)
            {
                EftPaymentData eftPaymentData = paymentData as EftPaymentData;

                EftAuthorization eftResult = this.eftProcessor.AuthorizeEftPayment(eftPaymentData.RoutingNumber,
                    eftPaymentData.BankAccountNumber, eftPaymentData.AccountType, eftPaymentData.Amount);

                if ( eftResult.Authorized)
                {
                    int referenceNumber = paymentsDao.SaveSuccessfulEftPayment(eftPaymentData, eftResult);

                    PaymentResult paymentResult = new PaymentResult()
                    {
                        CustomerAccountNumber = eftPaymentData.CustomerAccountNumber,
                        PaymentDate = eftPaymentData.PaymentDate,
                        Success = eftResult.Authorized,
                        ReferenceNumber = referenceNumber
                    };

                    return paymentResult;
                }
                else
                {
                    int referenceNumber = paymentsDao.SaveFailedEftPayment(eftPaymentData, eftResult);

                    PaymentResult paymentResult = new PaymentResult()
                    {
                        CustomerAccountNumber = eftPaymentData.CustomerAccountNumber,
                        PaymentDate = eftPaymentData.PaymentDate,
                        Success = eftResult.Authorized,
                        ReferenceNumber = referenceNumber
                    };
                    return paymentResult;
                }
            }
            else if (paymentData.PaymentType == PaymentType.CHECK)
            {
                CheckPaymentData checkPaymentData = paymentData as CheckPaymentData;

                int referenceNumber = this.paymentsDao.SaveCheckPayment(checkPaymentData);
                PaymentResult paymentResult = new PaymentResult()
                {
                    CustomerAccountNumber = checkPaymentData.CustomerAccountNumber,
                    PaymentDate = checkPaymentData.PaymentDate,
                    Success = true,
                    ReferenceNumber = referenceNumber
                };
                return paymentResult;
            }
            else
            {
                throw new ApplicationException("Unknown Payment Type");
            }

        }




    }
}
