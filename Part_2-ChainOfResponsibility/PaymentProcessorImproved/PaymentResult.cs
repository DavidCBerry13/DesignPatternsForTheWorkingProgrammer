using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessorImproved
{
    public class PaymentResult
    {

        public String CustomerAccountNumber { get; set; }

        public DateTime PaymentDate { get; set; }

        public bool Success { get; set; }

        public int? ReferenceNumber { get; set; }

       
    }
}
