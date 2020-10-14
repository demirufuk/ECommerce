using ECommerce.Core.Model;
using ECommerce.UI.WEB.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.UI.WEB.Controllers
{
    public class CartController : ECommerceControllerBase
    {
        ECommerceContext db = new ECommerceContext();

        [HttpPost]
        public JsonResult AddProduct(int productID, int quantity)
        {
            db.Carts.Add(new Core.Model.Entity.Cart
            {
                CreatedDate = DateTime.Now,
                CreateUserID = LoginUserID,
                ProductID = productID,
                Quantity = quantity,
                UserID = LoginUserID
            });
            var res = db.SaveChanges();

            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [Route("basket")]
        public ActionResult Index()
        {
            var res = db.Carts.Include("Product").Where(x => x.UserID == LoginUserID).ToList();

            return View(res);
        }

        public ActionResult Delete(int id)
        {
            var res = db.Carts.Where(x=>x.ID==id).FirstOrDefault();
            db.Carts.Remove(res);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}