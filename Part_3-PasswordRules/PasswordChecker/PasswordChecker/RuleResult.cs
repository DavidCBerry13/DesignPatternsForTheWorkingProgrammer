using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordChecker
{
    public class RuleResult
    {
        private RuleResult()
        {

        }

        /// <summary>
        /// Gets if the rule passed or failed
        /// </summary>
        public bool Passed { get; private set; }

        /// <summary>
        /// Gets a message indicting why the rule failed
        /// </summary>
        public String Message { get; private set; }



        public static RuleResult CreatePassResult()
        {
            return new RuleResult() { Passed = true };
        }
        
        public static RuleResult CreateFailResult(String message)
        {
            return new RuleResult() { Passed = false, Message = message };
        }



    }
}
