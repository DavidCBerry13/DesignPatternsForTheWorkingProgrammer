using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordChecker
{

    /// <summary>
    /// Represents the results of a password being validated.
    /// </summary>
    public class PasswordResult
    {

        public PasswordResult()
        {
            this.Messages = new List<string>();
        }

        /// <summary>
        /// Gets/Sets if the supplied password meets all of the password requirements.  
        /// True if all requirements are met.  False otherwise
        /// </summary>
        public bool ValidPassword { get; set; }

        /// <summary>
        /// Gets a list of messages about why the password was considered invalid.  If the password is valid, this
        /// list should be empty
        /// </summary>
        public List<String> Messages { get; set; }



    }
}
