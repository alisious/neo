using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kseo2.Model;

namespace Kseo2.Service
{
    public interface IUserService
    {
        
        User GetSingle(string login);
        User GetSingle(int id);
        List<User> GetAll();
        void AddUser(User newUser);
        void RemoveUser(User user);

    }
}
