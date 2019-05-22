using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordChecker.Rules
{
    public class PasswordIsNotEmptyRule : IPasswordRule
    {

        public bool BreakOnFailure { get { return true; } }


        public RuleResult CheckPassword(string username, string password)
        {
            if (String.IsNullOrEmpty(password))
            {
                return RuleResult.CreateFailResult("A password value must be provided");
            }

            return RuleResult.CreatePassResult();
        }
    }
}
