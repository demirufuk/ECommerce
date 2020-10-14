﻿using ECommerce.Core.Model.EntitiyBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Model.Entity
{
    public class OrderProduct:EntBase
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

    }
}
