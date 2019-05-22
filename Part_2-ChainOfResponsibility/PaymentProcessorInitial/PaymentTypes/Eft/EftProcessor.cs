using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessorInitial
{
    public class EftProcessor : IEftProcessor
    {

        public EftAuthorization AuthorizeEftPayment(string bankRoutingNumber, string bankAccountNumber, BankAccountType bankAccountType, decimal amount)
        {
            if ( bankRoutingNumber == SampleData.BANK_ROUTING_ONE && bankAccountNumber == SampleData.BANK_ACCOUNT_ONE)
            {
                return new EftAuthorization() { Authorized = true, AuthorizationCode = 11201 };
            }
            else if (bankRoutingNumber == SampleData.BANK_ROUTING_TWO && bankAccountNumber == SampleData.BANK_ACCOUNT_TWO)
            {
                return new EftAuthorization() { Authorized = true, AuthorizationCode = 80517 };
            }
            else if (bankRoutingNumber == SampleData.BANK_ROUTING_THREE && bankAccountNumber == SampleData.BANK_ACCOUNT_THREE)
            {
                return new EftAuthorization() { Authorized = true, AuthorizationCode = 23005 };
            }

            return new EftAuthorization() { Authorized = false };

        }
    }
}
