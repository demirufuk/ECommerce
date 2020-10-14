using ECommerce.Core.Model.EntitiyBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Model.Entity
{
    public class Order:EntBase
    {
        public int UserID { get; set; }
        public User User { get; set; }
        public int UserAddressID { get; set; }
        public UserAddress UserAddress { get; set; }
        public int StatusID { get; set; }
        public Status Status { get; set; }

        [DisplayName("Toplam Ürün Tutarı")]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        public decimal TotalProductPrice { get; set; }

        [DisplayName("Toplam Vergi Tutarı")]
        public decimal TotalTaxPrice { get; set; }

        [DisplayName("Toplam İndirim Tutarı")]
        public decimal TotalDiscountPrice { get; set; }

        [DisplayName("Toplam Tutar")]
        public decimal TotalPrice { get; set; }

        public virtual List<OrderProduct> OrderProducts { get; set; }
        public virtual List<OrderPayment> OrderPayments { get; set; }

    }
}
