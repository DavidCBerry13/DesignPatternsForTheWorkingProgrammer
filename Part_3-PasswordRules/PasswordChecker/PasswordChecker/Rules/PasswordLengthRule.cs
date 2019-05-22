using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordChecker.Rules
{
    public class PasswordLengthRule : IPasswordRule
    {
        public bool BreakOnFailure { get { return false; } }


        public RuleResult CheckPassword(string username, string password)
        {
            if (password.Length < 8)
            {
                return RuleResult.CreateFailResult("The password must be 8 characters in length or greater");
            }

            return RuleResult.CreatePassResult();
        }
    }
}
