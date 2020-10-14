using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerce.Core.Model;
namespace ECommerce.UI.WEB.Areas.Admin.Controllers
{
    public class AdminLoginController : Controller
    {
        ECommerceContext db = new ECommerceContext();
        // GET: Admin/AdminLogin
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string email,string password)
        {
            var res= db.Users.Where(x => x.Email == email
            && x.Password == password
            && x.IsActive == true
            && x.IsAdmin == true).ToList();

            if (res.Count == 1)
            {
                Session["AdminLoginUser"] = res.FirstOrDefault();
                return Redirect("/admin");
            }
            else
            return View();

        }
    }
}