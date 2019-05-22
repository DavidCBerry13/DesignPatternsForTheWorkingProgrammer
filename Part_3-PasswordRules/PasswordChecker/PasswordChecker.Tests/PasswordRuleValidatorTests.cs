using PasswordChecker.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PasswordChecker.Tests
{
    public class PasswordRuleValidatorTests
    {

        internal PasswordRuleValidator GetPasswordRuleValidator()
        {
            PasswordRuleValidator validator = new PasswordRuleValidator();

            validator.AddRule(new PasswordIsNotEmptyRule());
            validator.AddRule(new PasswordLengthRule());
            validator.AddRule(new PasswordContainsLettersRule());
            validator.AddRule(new PasswordContainsNumbersRule());
            validator.AddRule(new PasswordCannotContainUsername());
            validator.AddRule(new PasswordNotUsedBeforeRule());

            return validator;
        }


        [Fact]
        public void TestTooShortPasswordFails()
        {
            // Arrange 
            IPasswordChecker passwordChecker = this.GetPasswordRuleValidator();
            String username = "mickey-mouse";
            String password = "shortpw";

            // Act
            PasswordResult result = passwordChecker.ValidatePassword(username, password);

            // Assert
            Assert.False(result.ValidPassword);
        }

        [Fact]
        public void TestPasswordWithoutNumbersFails()
        {
            // Arrange 
            IPasswordChecker passwordChecker = this.GetPasswordRuleValidator();
            String username = "mickey-mouse";
            String password = "AbCdEfGhIjKlMn";

            // Act
            PasswordResult result = passwordChecker.ValidatePassword(username, password);

            // Assert
            Assert.False(result.ValidPassword);
        }


        [Fact]
        public void TestPasswordWithoutLettersFails()
        {
            // Arrange 
            IPasswordChecker passwordChecker = this.GetPasswordRuleValidator();
            String username = "mickey-mouse";
            String password = "1234567890";

            // Act
            PasswordResult result = passwordChecker.ValidatePassword(username, password);

            // Assert
            Assert.False(result.ValidPassword);
        }


        [Fact]
        public void TestPasswordUsedBeforeFails()
        {
            // Arrange 
            IPasswordChecker passwordChecker = this.GetPasswordRuleValidator();
            String username = "mickey-mouse";
            String password = "IowaCodeCamp2106!";

            // Act
            PasswordResult result = passwordChecker.ValidatePassword(username, password);

            // Assert
            Assert.False(result.ValidPassword);
        }



    }
}
