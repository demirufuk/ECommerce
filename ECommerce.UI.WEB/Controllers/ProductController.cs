using ECommerce.Core.Model;
using ECommerce.UI.WEB.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.UI.WEB.Controllers
{
    public class ProductController : ECommerceControllerBase
    {
        ECommerceContext db = new ECommerceContext();

        // GET: Product
        [Route("urun-{title}-{id}")]
        public ActionResult Detail(int id)
        {
            var res = db.Products.Where(x => x.ID == id).FirstOrDefault();

            return View(res);
        }
    }
}