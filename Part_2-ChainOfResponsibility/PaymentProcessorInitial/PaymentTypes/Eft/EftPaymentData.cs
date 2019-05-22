using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessorInitial
{
    public class EftPaymentData : PaymentDataBase
    {


        public BankAccountType AccountType { get; set; }

        public String RoutingNumber { get; set; }

        public String BankAccountNumber { get; set; }
    }
}
