using BorrowMe.Domain.Entities;
using BorrowMe.Domain.Interfaces.Repositories;
using System.Linq;

namespace BorrowMe.Infra.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {    
        public User Login(string name, string password)
        {
            var usuario = Db.Users.FirstOrDefault(x => x.UserName == name && x.Password == password);

            if (usuario != null)
                return usuario;
            else
                return null;
        }
        
        public bool UserNameValidate(string userName)
        {
            var usuario = Db.Users.FirstOrDefault(x => x.UserName == userName);

            if (usuario != null)
                return true;
            else
                return false;
        }

    }
}
