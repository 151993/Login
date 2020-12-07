using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryMS.Domain;

namespace InventoryMS.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly InventoryDBContext _dbcontext;

        public UserRepository(InventoryDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<User> AddUser(User user)
        {
            _dbcontext.Users.Add(user);
            await _dbcontext.SaveChangesAsync();
            return user;
        }

        public bool Login(string userName, string password)
        {

            var isExist = _dbcontext.Users.FirstOrDefault(x => x.UserName == userName && x.Password == password);
            if (isExist != null)
            {
                return true;
            }

            return false;
        }

        public bool IsUserExist(string userName)
        {
            bool isExist = _dbcontext.Users.Any(x => x.UserName.ToLower() == userName);
            if (isExist)
            {
                return true;
            }

            return false;
        }
    }
}
