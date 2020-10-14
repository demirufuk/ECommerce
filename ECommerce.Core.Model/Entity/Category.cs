using ECommerce.Core.Model.EntitiyBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Model.Entity
{
    public class Category : EntBase
    {
        public int ParentID { get; set; } = 0;
        public string Name { get; set; }
        public bool IsActive { get; set; }

    }
}
