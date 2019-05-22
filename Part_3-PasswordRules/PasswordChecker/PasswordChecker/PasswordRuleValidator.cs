using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordChecker
{
    public class PasswordRuleValidator : IPasswordChecker
    {

        public PasswordRuleValidator()
        {
            this.passwordRules = new List<IPasswordRule>();    
        }

        private List<IPasswordRule> passwordRules;


        public void AddRule(IPasswordRule rule)
        {
            this.passwordRules.Add(rule);
        }


        public PasswordResult ValidatePassword(string username, string password)
        {
            List<RuleResult> results = new List<RuleResult>();

            foreach (var rule in this.passwordRules)
            {
                RuleResult ruleResult = rule.CheckPassword(username, password);

                if ( !ruleResult.Passed )
                {
                    PasswordResult passwordResults = new PasswordResult() { ValidPassword = false };
                    passwordResults.Messages.Add(ruleResult.Message);
                    return passwordResults;
                }
            }

            return new PasswordResult() { ValidPassword = true };

        }








    }
}
