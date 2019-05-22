using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessorImproved
{
    public class CheckPaymentTypeHandler : IPaymentHandler
    {

        public CheckPaymentTypeHandler(IPaymentsDao paymentsDao) 
        {            
            this.paymentsDao = paymentsDao;
        }


        private IPaymentsDao paymentsDao;


        public bool CanProcessPayment(BasePaymentData paymentData)
        {
            return paymentData.PaymentType == PaymentType.CHECK;
        }

        public PaymentResult ProcessPayment(BasePaymentData paymentData)
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
    }
}
