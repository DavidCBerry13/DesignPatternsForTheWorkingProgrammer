using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordChecker
{
    public interface IPasswordChecker
    {


        PasswordResult ValidatePassword(String username, String password);


    }
}
