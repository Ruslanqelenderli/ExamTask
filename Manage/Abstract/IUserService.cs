using LoginRegisterSystem.Entity;
using LoginRegisterSystem.Helper.ReturnResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegisterSystem.Manage.Abstract
{
    public interface IUserService
    {
        ReturnResult<User> Login(string username, string password);
        ReturnResult<User> Register(User user);
    }
}
