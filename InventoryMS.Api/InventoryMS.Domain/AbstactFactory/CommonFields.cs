using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryMS.Domain
{
    public abstract class CommonFields
    {
        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }
    }
}
