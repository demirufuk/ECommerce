using ECommerce.Core.Model.EntitiyBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Model.Entity
{
    public class OrderPayment:EntBase
    {
        public int OrderID { get; set; }
        public _OrderType OrderType { get; set; }
        public decimal Price { get; set; }
        public string Bank { get; set; }
    }

    public enum _OrderType
    {
        Havale = 0,
        EFT = 1,
        KrediKartı=2
    }
}
