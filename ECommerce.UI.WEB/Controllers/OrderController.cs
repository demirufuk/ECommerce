using ECommerce.Core.Model;
using ECommerce.Core.Model.Entity;
using ECommerce.UI.WEB.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.UI.WEB.Controllers
{
    public class OrderController : ECommerceControllerBase
    {
        ECommerceContext db = new ECommerceContext();

        [Route("Siparisver")]
        public ActionResult AddresList()
        {
            var res = db.UserAddresses.Where(x => x.UserID == LoginUserID).ToList();

            return View(res);
        }

        public ActionResult CreateUserAddress()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUserAddress(UserAddress userAddress)
        {
            userAddress.CreatedDate = DateTime.Now;
            userAddress.CreateUserID = LoginUserID;
            userAddress.IsActive = true;
            userAddress.UserID = LoginUserID;

            db.UserAddresses.Add(userAddress);
            db.SaveChanges();

            return RedirectToAction("AddresList");
        }

        public ActionResult CreateOrder(int id)
        {
            var cart = db.Carts.Include("Product").Where(x => x.UserID == LoginUserID).ToList();

            Order order = new Order();
            order.CreatedDate = DateTime.Now;
            order.CreateUserID = LoginUserID;
            order.StatusID = 2;
            order.UserID = LoginUserID;

            order.TotalProductPrice = cart.Sum(x => x.Product.Price);
            order.TotalTaxPrice = cart.Sum(x => x.Product.Tax);
            order.TotalDiscountPrice = cart.Sum(x => x.Product.Discount);
            order.TotalPrice = order.TotalProductPrice + order.TotalTaxPrice;

            order.UserAddressID = id;
            order.UserID = LoginUserID;
            order.OrderProducts = new List<OrderProduct>();

            foreach (var item in cart)
            {
                order.OrderProducts.Add(new OrderProduct
                {
                    CreatedDate = DateTime.Now,
                    CreateUserID = LoginUserID,
                    ProductID = item.ProductID,
                    Quantity = item.Quantity
                });

                db.Carts.Remove(item);
            }

            db.Orders.Add(order);
            db.SaveChanges();

            var orderid = db.Orders.Where(x => x.UserID == LoginUserID).AsEnumerable().LastOrDefault().ID;
            return RedirectToAction("Detail", new { id = orderid });

        }

        public ActionResult Detail(int id)
        {
            var res = db.Orders.Include("OrderProducts").
                Include("OrderProducts.Product").
                Include("OrderPayments").
                Include("Status").
                Include("UserAddress")
                .Where(x => x.ID == id).FirstOrDefault();

            return View(res);
        }

        [Route("siparislerim")]
        public ActionResult Index()
        {
            var res = db.Orders.Include("Status").Include("UserAddress").Where(x => x.UserID == LoginUserID).ToList();

            return View(res);
        }

        public ActionResult Pay(int id)
        {
            var res = db.Orders.Where(x => x.ID == id).FirstOrDefault();
            res.StatusID = 3;
            db.SaveChanges();


            return RedirectToAction("Detail", new { res.ID });
        }

    }
}