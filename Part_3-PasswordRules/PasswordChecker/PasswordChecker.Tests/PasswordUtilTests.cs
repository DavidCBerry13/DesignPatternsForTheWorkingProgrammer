using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PasswordChecker.Tests
{
    public class PasswordUtilTests
    {
        [Fact]
        public void TestHashingPassword()
        {
            // Arrange
            String salt = "IJKLMNOP";
            String clearTextPassword = "IowaCodeCamp2106!";
            String expectedHash = "040942AA8AF939B60A4156FEC8620C7EDDA287BBF1AEC7E6DD06270D81837B9D";

            // Act
            var hashedPassword = PasswordUtil.HashPassword(salt, clearTextPassword);

            // Assert
            Assert.Equal(expectedHash, hashedPassword);

        }


    }
}
