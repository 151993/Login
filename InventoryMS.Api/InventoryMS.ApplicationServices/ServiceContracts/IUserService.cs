using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InventoryMS.Domain;

namespace InventoryMS.ApplicationServices
{
    public interface IUserService
    {
        Status Login(string userName, string password);

        Task<Status> AddUser(UserDto userDto);
    }
}
