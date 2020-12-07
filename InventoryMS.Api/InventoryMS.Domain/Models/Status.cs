using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryMS.Domain
{
    public class Status
    {
        public string SuccessMessage { get; set; }

        public string ErrorMessage { get; set; }

        public bool IsSuccess { get; set; }

        public Status()
        {
            SuccessMessage = "";
            ErrorMessage = "";
            IsSuccess = false;
        }
    }


}
