using ECommerce.Core.Model.EntitiyBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Model.Entity
{
    public class Product:EntBase
    {
        [DisplayName("Ürün Adı")]
        public string Name { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }

        [DisplayName("Fiyat")]
        public decimal Price { get; set; }

        [DisplayName("Vergi Tutar")]
        public decimal Tax { get; set; }

        [DisplayName("İndirim Tutarı")]
        public decimal Discount { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; }


    }
}
