using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessorInitial
{
    public interface ICreditCardProcessor
    {

        CreditCardResult AuthorizeCreditCard(String cardNumber, String expirationDate, String cvv, String billingZipCode, decimal amount);

    }
}
