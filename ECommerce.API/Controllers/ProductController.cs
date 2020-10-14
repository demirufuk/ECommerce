using ECommerce.Core.Model;
using ECommerce.Core.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ECommerce.API.Controllers
{
    public class ProductController : ApiController
    {
        ECommerceContext db = new ECommerceContext();
        public List<Product> Get()
        {
            var result = db.Products.Where(x => x.IsActive == true).ToList();

            return result;
        }
        public Product Get(int id)
        {
            var result = db.Products.Where(x => x.ID == id).FirstOrDefault();

            return result;
        }
    }
}
