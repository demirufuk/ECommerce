using ECommerce.Core.Model;
using ECommerce.Core.Model.Entity;
using ECommerce.UI.WEB.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.UI.WEB.Controllers
{
    public class HomeController : ECommerceControllerBase
    {
        ECommerceContext db = new ECommerceContext();
        public ActionResult Index()
        {
            ViewBag.IsLogin = this.IsLogin;

            var res = db.Products.OrderByDescending(x => x.CreatedDate).Take(5).ToList();
            return View(res);
        }

        public PartialViewResult GetMenu()
        {
            var res = db.Categories.Where(x => x.ParentID == 0).ToList();

            return PartialView(res);
        }

        [Route("uye-giris")]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("uye-giris")]
        public ActionResult Login(string email, string password)
        {
            var res = db.Users.Where(x => x.Email == email && x.Password == password && x.IsActive == true
            && x.IsAdmin == false).ToList();

            if (res.Count == 1)
            {
                //giriş yapıldı
                Session["LoginUserID"] = res.FirstOrDefault().ID;
                Session["LoginUser"] = res.FirstOrDefault();
                return Redirect("/");
            }
            else
                ViewBag.Err = "Hatalı Kullanıcı Girişi";
            return View();
        }


        [Route("uye-kayit")]
        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        [Route("uye-kayit")]
        public ActionResult CreateUser(User user)
        {
            try
            {
                user.CreatedDate = DateTime.Now;
                user.CreateUserID = 1;
                user.IsActive = true;
                user.IsAdmin = false;

                db.Users.Add(user);
                db.SaveChanges();

                return Redirect("/");
            }
            catch (Exception)
            {
                return View();
            }

        }
    }
}