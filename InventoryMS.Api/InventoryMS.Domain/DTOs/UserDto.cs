using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryMS.Domain
{
    public class UserDto
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailId { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }
    }
}
