using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessorCOR
{
    public class CheckPaymentTypeHandler : PaymentTypeHandlerBase
    {

        public CheckPaymentTypeHandler(IPaymentsDao paymentsDao) 
        {            
            this.paymentsDao = paymentsDao;
        }


        private IPaymentsDao paymentsDao;


        protected override bool CanProcessPayment(BasePaymentData paymentData)
        {
            return paymentData.PaymentType == PaymentType.CHECK;
        }

        protected override PaymentResult ExecutePaymentProcess(BasePaymentData paymentData)
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
