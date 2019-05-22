using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentProcessorImproved
{
    public class UnknownPaymentTypeHandler : IPaymentHandler
    {

        public UnknownPaymentTypeHandler(IPaymentsDao payentsDao)
        {
            PaymentsDao = payentsDao;
        }


        public IPaymentsDao PaymentsDao { get; set; }


        public bool CanProcessPayment(BasePaymentData paymentData)
        {
            return true;
        }

        public PaymentResult ProcessPayment(BasePaymentData paymentData)
        {
            throw new Exception("Unkown Payment Type");
        }
    }
}
