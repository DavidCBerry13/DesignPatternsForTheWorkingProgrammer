using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordChecker
{
    public class BetterPasswordRuleValidator : IPasswordChecker
    {

        public BetterPasswordRuleValidator()
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
            List<RuleResult> ruleResults = new List<RuleResult>();

            foreach (var rule in this.passwordRules)
            {
                RuleResult ruleResult = rule.CheckPassword(username, password);
                ruleResults.Add(ruleResult);

                if (rule.BreakOnFailure && !ruleResult.Passed)
                {
                    // This is a "Break on Failure" rule that has failed,
                    // so we want to break out of the loop
                    break;
                }
            }

            PasswordResult passwordResults = new PasswordResult();
            passwordResults.ValidPassword = ruleResults.All(r => r.Passed);
            passwordResults.Messages = ruleResults
                .Where(r => !r.Passed)
                .Where(r => !String.IsNullOrWhiteSpace(r.Message))
                .Select(r => r.Message).ToList();

            return passwordResults;
        }





    }
}
