using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessorCOR
{
    public class PaymentProcessor
    {

        public PaymentProcessor(IPaymentHandler paymentProcessingChain)
        {
            paymentProcessingChainFirstElement = paymentProcessingChain;
        }


        private IPaymentHandler paymentProcessingChainFirstElement;




        public PaymentResult ProcessPayment(BasePaymentData paymentData)
        {
            return this.paymentProcessingChainFirstElement.TryProcessPayment(paymentData);
        }
    }
}
