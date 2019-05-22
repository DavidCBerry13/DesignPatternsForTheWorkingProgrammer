using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PasswordChecker
{
    public class SimplePasswordChecker : IPasswordChecker
    {


        public PasswordResult ValidatePassword(string username, string password)
        {
            PasswordResult results = new PasswordResult();
            results.ValidPassword = false;

            if ( String.IsNullOrEmpty(password))
            {
                results.Messages.Add("A password value must be provided");
                return results;
            }
            else if ( password.Length < 8 )
            {
                results.Messages.Add("The password must be 8 characters in length or greater");
                return results;
            }
            else if ( !Regex.IsMatch(password, "[A-Z]+", RegexOptions.IgnoreCase) )
            {
                results.Messages.Add("The password must contain at least one letter");
                return results;
            }
            else if (!Regex.IsMatch(password, "[0-9]+") )
            {
                results.Messages.Add("The password must contain at least one number");
                return results;
            }

            String usernameRegex = String.Format("({0})+", username);
            if ( Regex.IsMatch(password, usernameRegex, RegexOptions.IgnoreCase))
            {
                results.Messages.Add( $"Your username of {username} may not be used as part of the password");
                return results;
            }

            if ( this.HasPasswordBeenUsedBefore(username, password) )
            {
                results.Messages.Add($"You have entered a password that you have used before.  Please enter a new password");
                return results;
            }

            return results;
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
