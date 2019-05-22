using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessorInitial
{
    public class PaymentType
    {

        /// <summary>
        /// Gets/Sets the unique code for this payment type
        /// </summary>        
        public String Code { get; private set; }

        /// <summary>
        /// Gets the full name/description of this payment type
        /// </summary>
        public String Description { get; private set; }


        public override bool Equals(object obj)
        {
            PaymentType other = obj as PaymentType;
            if (other == null)
                return false;

            return this.Code == other.Code;
        }

        public override int GetHashCode()
        {
            return this.Code.GetHashCode();
        }


        public static readonly PaymentType CREDIT_CARD = new PaymentType() { Code = "CC", Description = "Credit Card" };

        public static readonly PaymentType EFT = new PaymentType() { Code = "EFT", Description = "Electronic Funds Transfer" };

        public static readonly PaymentType CHECK = new PaymentType() { Code = "CHECK", Description = "Check" };


    }
}
