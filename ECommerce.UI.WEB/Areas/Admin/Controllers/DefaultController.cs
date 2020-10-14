using ECommerce.UI.WEB.Areas.Admin.AdminBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.UI.WEB.Areas.Admin.Controllers
{
    public class DefaultController : AdminControllerBase
    {
        // GET: Admin/Default
        public ActionResult Index()
        {
            return View();
        }
    }
}