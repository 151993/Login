using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMS.Domain
{
    public interface IUserRepository
    {
        bool Login(string userName, string password);

        bool IsUserExist(string userName);

        Task<User> AddUser(User user);
    }
}
