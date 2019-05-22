using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessorCOR
{
    public abstract class PaymentTypeHandlerBase : IPaymentHandler
    {



        /// <summary>
        /// Gets the next payment handler that follows this one.  If this proeprty returns
        /// null, then we are at the end of the chain
        /// </summary>
        public IPaymentHandler NextPaymentHandler { get; set; }


        /// <summary>
        /// Try to process the payment.  If we can, then we'll return.  Otherwise
        /// we'll call the next payment handler in the chain
        /// </summary>
        /// <param name="paymentData"></param>
        /// <returns></returns>
        public PaymentResult TryProcessPayment(BasePaymentData paymentData)
        {
            if ( this.CanProcessPayment(paymentData))
            {
                return this.ExecutePaymentProcess(paymentData);
            }
            else if (NextPaymentHandler != null)
            {
                return this.NextPaymentHandler.TryProcessPayment(paymentData);
            }
            else
            {
                throw new ApplicationException("Unable to Process Payment Type");
            }
        }



        protected abstract bool CanProcessPayment(BasePaymentData paymentData);


        protected abstract PaymentResult ExecutePaymentProcess(BasePaymentData paymentData);


    }
}
