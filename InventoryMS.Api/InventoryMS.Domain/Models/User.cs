using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using InventoryMS.Common;

namespace InventoryMS.Domain
{
    [Table("User")]
    public class User
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailId { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }

        public User() { }

        public void Adduser(User user)
        {
            UserId = string.IsNullOrEmpty(user.UserId) ? UserId.GenerateGuid() : user.UserId;
            UserName = user.EmailId; 
            FirstName = user.FirstName;
            LastName = user.LastName;
            EmailId = user.EmailId;
            IsActive = user.IsActive;
        }
    }
}
