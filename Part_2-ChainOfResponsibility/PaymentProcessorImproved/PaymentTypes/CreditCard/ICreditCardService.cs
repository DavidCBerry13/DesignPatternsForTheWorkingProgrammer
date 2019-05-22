using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessorImproved
{
    public interface ICreditCardService
    {

        CreditCardResult AuthorizeCreditCard(String cardNumber, String expirationDate, String cvv, String billingZipCode, decimal amount);

    }
}
