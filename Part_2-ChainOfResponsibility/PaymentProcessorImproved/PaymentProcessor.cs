using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessorImproved
{
    public class PaymentProcessor
    {

        public PaymentProcessor()
        {
            PaymentHandlers = new List<IPaymentHandler>();
        }


        public List<IPaymentHandler> PaymentHandlers { get; set; }




        public PaymentResult ProcessPayment(BasePaymentData paymentData)
        {
            foreach (var handler in PaymentHandlers)
            {
                if (handler.CanProcessPayment(paymentData))
                    return handler.ProcessPayment(paymentData);
            }

            throw new Exception("Unable to find processor to process payment");
        }






        public PaymentResult ProcessPaymentLinq(BasePaymentData paymentData)
        {
            var paymentHandler = PaymentHandlers.FirstOrDefault(handler => handler.CanProcessPayment(paymentData));

            if (paymentHandler != null)
            {
                return paymentHandler.ProcessPayment(paymentData);
            }
            else
            {
                throw new Exception("Unable to find processor to process payment");
            }
        }



    }
}
