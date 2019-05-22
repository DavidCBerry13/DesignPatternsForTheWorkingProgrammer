using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordChecker
{
    public interface IPasswordRule
    {

        bool BreakOnFailure { get; }

        RuleResult CheckPassword(String username, String password);
       

    }
}
