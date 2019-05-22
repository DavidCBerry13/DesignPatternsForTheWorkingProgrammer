using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PasswordChecker.Tests
{
    public class SimplePasswordCheckerTests
    {

        public void TestNullPasswordIsInvalid()
        {
            // Arrange
            String username = "mmouse";
            String password = null;
            SimplePasswordChecker passwordChecker = new SimplePasswordChecker();

            // Act
            PasswordResult results = passwordChecker.ValidatePassword(username, password);

            // Assert
            Assert.Equal(false, results.ValidPassword);
            Assert.NotEmpty(results.Messages);
            Assert.Contains<String>("A password value must be provided", results.Messages);
        }



        public void TestEmptyStringPasswordIsInvalid()
        {
            // Arrange
            String username = "mmouse";
            String password = String.Empty;
            SimplePasswordChecker passwordChecker = new SimplePasswordChecker();

            // Act
            PasswordResult results = passwordChecker.ValidatePassword(username, password);

            // Assert
            Assert.Equal(false, results.ValidPassword);
            Assert.NotEmpty(results.Messages);
            Assert.Contains<String>("A password value must be provided", results.Messages);
        }



        [Fact]
        public void TestPasswordShorterThanEightCharacters()
        {
            // Arrange
            String username = "mmouse";
            String password = "short1$";
            SimplePasswordChecker passwordChecker = new SimplePasswordChecker();

            // Act
            PasswordResult results = passwordChecker.ValidatePassword(username, password);

            // Assert
            Assert.Equal(false, results.ValidPassword);
            Assert.NotEmpty(results.Messages);
            Assert.Contains<String>("The password must be 8 characters in length or greater", results.Messages);            
        }

        [Fact]
        public void TestPasswordWithNoLettersIsInvalid()
        {
            // Arrange
            String username = "mmouse";
            String password = "1234567$";
            SimplePasswordChecker passwordChecker = new SimplePasswordChecker();

            // Act
            PasswordResult results = passwordChecker.ValidatePassword(username, password);

            // Assert
            Assert.Equal(false, results.ValidPassword);
            Assert.NotEmpty(results.Messages);
            Assert.Contains<String>("The password must contain at least one letter", results.Messages);
        }

        [Fact]
        public void TestPasswordWithNoNumbersIsInvalid()
        {
            // Arrange
            String username = "mmouse";
            String password = "abcdefgh";
            SimplePasswordChecker passwordChecker = new SimplePasswordChecker();

            // Act
            PasswordResult results = passwordChecker.ValidatePassword(username, password);

            // Assert
            Assert.Equal(false, results.ValidPassword);
            Assert.NotEmpty(results.Messages);
            Assert.Contains<String>("The password must contain at least one number", results.Messages);
        }


        [Fact]
        public void TestPasswordContainingUsernameIsInvalid()
        {
            // Arrange
            String username = "mmouse";
            String password = "mmouse123$";
            SimplePasswordChecker passwordChecker = new SimplePasswordChecker();

            // Act
            PasswordResult results = passwordChecker.ValidatePassword(username, password);

            // Assert
            Assert.Equal(false, results.ValidPassword);
            Assert.NotEmpty(results.Messages);
            Assert.Contains<String>("Your username of mmouse may not be used as part of the password", results.Messages);
        }


        [Fact]
        public void TestPasswordContainingUsernameInDifferentCaseIsInvalid()
        {
            // Arrange
            String username = "mmouse";
            String password = "MMouse123$";
            SimplePasswordChecker passwordChecker = new SimplePasswordChecker();

            // Act
            PasswordResult results = passwordChecker.ValidatePassword(username, password);

            // Assert
            Assert.Equal(false, results.ValidPassword);
            Assert.NotEmpty(results.Messages);
            Assert.Contains<String>("Your username of mmouse may not be used as part of the password", results.Messages);
        }


        [Fact]
        public void TestPreviouslyUsedPasswordIsInvalid()
        {
            // Arrange
            String username = "mmouse";
            String password = "IowaCodeCamp2106!";
            SimplePasswordChecker passwordChecker = new SimplePasswordChecker();

            // Act
            PasswordResult results = passwordChecker.ValidatePassword(username, password);

            // Assert
            Assert.Equal(false, results.ValidPassword);
            Assert.NotEmpty(results.Messages);
            Assert.Contains<String>("You have entered a password that you have used before.  Please enter a new password", results.Messages);
        }


    }
}
