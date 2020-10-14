using ECommerce.Core.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.UI.WEB.Models
{
    public class BaseClass
    {
        public bool IsLogin { get; private set; }
        public int LoginUserID { get; private set; }
        public User LoginUserEntity { get; private set; }
    }
}