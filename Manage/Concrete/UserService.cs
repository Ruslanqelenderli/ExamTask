using LoginRegisterSystem.Entity;
using LoginRegisterSystem.Helper.Hasher;
using LoginRegisterSystem.Helper.ReturnResult;
using LoginRegisterSystem.Manage.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegisterSystem.Manage.Concrete
{
    public class UserService : IUserService
    {
        private List<User> _users;

        public UserService()
        {
            _users = new List<User>();
        }
        public ReturnResult<User> Login(string username, string password)
        {
            if(!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                var hashedPassword = PasswordHasher.Hasher(password);
                var user = new User();
                if (hashedPassword == null) return new ReturnResult<User>(null, false, "password is incorrect");
                foreach (var _user in _users)
                {
                    if(_user.Password == hashedPassword)
                    {
                        user = _user;
                        return new ReturnResult<User>(user, true, "Login olundu");
                    }
                }
                return new ReturnResult<User>(null, false, "There is no information in database by this user");

            }
            else
            {
                return new ReturnResult<User>(null, false, "Username or password is incorrect");
            }
            
        }

        public ReturnResult<User> Register(User user)
        {
            var reEmailStatus = false;

            foreach (var _user in _users)
            {
                if(_user.Email == user.Email) reEmailStatus = true;
            }

            if (reEmailStatus) return new ReturnResult<User>(null, false, "email is incorrect"); ;

            var hashedPassword = PasswordHasher.Hasher(user.Password);

            if (hashedPassword == null) return new ReturnResult<User>(null, false, "Password is incorrect"); 
            user.Password = hashedPassword;

            _users.Add(user);
            return new ReturnResult<User>(user, true, "Register olundu");
        }
    }
}
