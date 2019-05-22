using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessorCOR
{
    public class CheckPaymentData : BasePaymentData
    {
        public CheckPaymentData()
        {
            this.PaymentType = PaymentType.CHECK;
        }

        public String BankRoutingNumber { get; set; }

        public String BankAccountNumber { get; set; }

        public String CheckNumber { get; set; }


    }
}
