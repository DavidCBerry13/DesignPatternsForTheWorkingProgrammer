using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PasswordChecker.Rules
{
    public class PasswordCannotContainUsername : IPasswordRule
    {
        public bool BreakOnFailure { get { return false; } }


        public RuleResult CheckPassword(string username, string password)
        {
            String usernameRegex = String.Format("({0})+", username);
            if (Regex.IsMatch(password, usernameRegex, RegexOptions.IgnoreCase))
            {
                return RuleResult.CreateFailResult($"Your username of {username} may not be used as part of the password");                
            }

            return RuleResult.CreatePassResult();
        }
    }
}
