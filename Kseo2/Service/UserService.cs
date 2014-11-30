using Kseo2.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kseo2.Service
{
    public class UserService :IUserService
    {

        #region Private fields
        
        private readonly KseoContext _context;
 
        #endregion

        #region Constructors

        public UserService()
        {
            _context = new KseoContext();
            
        }

        public UserService(KseoContext context)
        {
            _context = context;
        }

        #endregion

        public Model.User GetSingle(string login)
        {
            return _context.Users.SingleOrDefault(x => x.Login == login);
        }

        public Model.User GetSingle(int id)
        {
            throw new NotImplementedException();
        }

        public List<Model.User> GetAll()
        {
            throw new NotImplementedException();
        }

        public void AddUser(Model.User newUser)
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(Model.User user)
        {
            throw new NotImplementedException();
        }
    }
}
