using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordChecker.Rules
{
    public class PasswordNotUsedBeforeRule : IPasswordRule
    {

        public bool BreakOnFailure { get { return false; } }


        public RuleResult CheckPassword(string username, string password)
        {
            if (this.HasPasswordBeenUsedBefore(username, password))
            {
                return RuleResult.CreateFailResult($"You have entered a password that you have used before.  Please enter a new password");
            }

            return RuleResult.CreatePassResult();
        }


        internal bool HasPasswordBeenUsedBefore(String username, String newPassword)
        {
            List<PasswordHistory> historicalPasswords = this.GetHistoricalPasswords(username);

            foreach (var oldPassword in historicalPasswords)
            {
                var hashedPassword = PasswordUtil.HashPassword(oldPassword.Salt, newPassword);
                if (hashedPassword == oldPassword.PasswordHash)
                    return true;
            }

            return false;
        }


        internal List<PasswordHistory> GetHistoricalPasswords(String username)
        {
            return new List<PasswordHistory>()
            {
                new PasswordHistory() { Salt = "ABCDEFGH", PasswordHash = "3130E56DC7A51A6B768442B80643C6AC2E4A9CA881DC7C995172E2A448F326A2" },
                new PasswordHistory() { Salt = "EFGHIJKL", PasswordHash = "6DF2A7FD740D357AA4122792D47BCB31A9AB88AD2A52E9E011979EAC537F9A16" },
                new PasswordHistory() { Salt = "IJKLMNOP", PasswordHash = "040942AA8AF939B60A4156FEC8620C7EDDA287BBF1AEC7E6DD06270D81837B9D" }
            };
        }

    }



    

}
