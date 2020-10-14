using ECommerce.Core.Model;
using ECommerce.UI.WEB.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.UI.WEB.Controllers
{
    public class CategoryController : ECommerceControllerBase
    {
        ECommerceContext db = new ECommerceContext();

        [Route("kategori-{name}-{id}")]
        public ActionResult Index(string name,int id)
        {
            var res = db.Products.Where(x => x.IsActive==true && x.CategoryID == id).ToList();
            return View(res);
        }
    }
}