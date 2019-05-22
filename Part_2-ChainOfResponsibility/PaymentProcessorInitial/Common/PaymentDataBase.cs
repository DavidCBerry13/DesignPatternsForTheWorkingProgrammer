using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessorInitial
{
    public class PaymentDataBase
    {


        public String CustomerAccountNumber { get; set; }

        public DateTime PaymentDate { get; set; }

        public decimal Amount { get; set; }

        public PaymentType PaymentType { get; set; }

        

    }
}
