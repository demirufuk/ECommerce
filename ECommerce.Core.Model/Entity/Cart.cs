using ECommerce.Core.Model.EntitiyBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Model.Entity
{
    public class Cart:EntBase
    {
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }

        [DisplayName("Adet")]
        public int Quantity { get; set; }
    }
}
