using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ECommerce.UI.WEB.Areas.Admin.AdminBase
{
    public class AdminControllerBase:Controller
    {
        protected override void Initialize(RequestContext requestContext)
        {
            var IsLogin = false;

            if (requestContext.HttpContext.Session["AdminLoginUser"] == null)
            {
                //Admin Girişi yok
                requestContext.HttpContext.Response.Redirect("Admin/AdminLogin");
            }
            else
                //admin
                base.Initialize(requestContext);

        }
    }
}