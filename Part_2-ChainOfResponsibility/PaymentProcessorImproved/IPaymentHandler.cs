using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessorImproved
{
    public interface IPaymentHandler
    {

        bool CanProcessPayment(BasePaymentData paymentData);

        /// <summary>
        /// Try to process the payment.  If we can, then we'll return.  Otherwise
        /// we'll call the next payment handler in the chain
        /// </summary>
        /// <param name="paymentData"></param>
        /// <returns></returns>
        PaymentResult ProcessPayment(BasePaymentData paymentData);



        

    }
}
