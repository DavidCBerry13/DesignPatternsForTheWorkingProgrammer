using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessorCOR
{
    /// <summary>
    /// Represents a bank account type (like checking or savings)
    /// </summary>
    public class BankAccountType
    {
        private BankAccountType(String code, String name)
        {
            this.Code = code;
            this.Name = name;
        }

        public String Code { get; private set; }


        public String Name { get; private set; }


        public override bool Equals(object obj)
        {
            BankAccountType other = obj as BankAccountType;
            if (obj == null)
                return false;

            return this.Code == other.Code;
        }


        public override int GetHashCode()
        {
            return this.Code.GetHashCode();
        }



        public static readonly BankAccountType CHECKING = new BankAccountType("C", "Checking");

        public static readonly BankAccountType SAVINGS = new BankAccountType("S", "Savings");
    }
}
