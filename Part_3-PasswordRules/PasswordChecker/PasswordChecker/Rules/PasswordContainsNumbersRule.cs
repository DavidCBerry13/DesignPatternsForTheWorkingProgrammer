using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PasswordChecker.Rules
{
    public class PasswordContainsNumbersRule : IPasswordRule
    {
        public bool BreakOnFailure { get { return false; } }


        public RuleResult CheckPassword(string username, string password)
        {
            if (!Regex.IsMatch(password, "[0-9]+"))
            {
                return RuleResult.CreateFailResult("The password must contain at least one number");                
            }

            return RuleResult.CreatePassResult();
        }
    }
}
