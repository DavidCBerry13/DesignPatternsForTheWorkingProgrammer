using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessorInitial
{
    public class CreditCardProcessor : ICreditCardProcessor
    {

        


        public CreditCardResult AuthorizeCreditCard(String cardNumber, String expirationDate, String cvv, String billingZipCode, decimal amount)
        {
            if ( cardNumber == SampleData.CARD_NUMBER_ONE && amount <= 500.00m)
            {
                return new CreditCardResult() { Authorized = true, AuthorizationCode = billingZipCode.Reverse().ToString() };
            }
            else if ( cardNumber == SampleData.CARD_NUMBER_TWO && amount <= 1000.00m )
            {
                return new CreditCardResult() { Authorized = true, AuthorizationCode = cvv + cvv };
            }
            else
            {
                return new CreditCardResult() { Authorized = false };
            }

        }



    }
}
