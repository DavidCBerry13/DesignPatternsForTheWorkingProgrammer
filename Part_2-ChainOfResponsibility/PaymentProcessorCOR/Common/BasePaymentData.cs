using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessorCOR
{
    public class BasePaymentData
    {


        public String CustomerAccountNumber { get; set; }

        public DateTime PaymentDate { get; set; }

        public decimal Amount { get; set; }

        public PaymentType PaymentType { get; set; }

        

    }
}
