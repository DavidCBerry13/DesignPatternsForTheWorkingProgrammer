using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PasswordChecker.Rules
{
    public class PasswordContainsLettersRule : IPasswordRule
    {

        public bool BreakOnFailure { get { return false; } }


        public RuleResult CheckPassword(string username, string password)
        {
            if (!Regex.IsMatch(password, "[A-Z]+", RegexOptions.IgnoreCase))
            {
                return RuleResult.CreateFailResult("The password must contain at least one letter");                
            }

            return RuleResult.CreatePassResult();
        }
    }
}
