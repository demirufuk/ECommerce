﻿using ECommerce.Core.Model.EntitiyBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Model.Entity
{
    public class User: EntBase
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Password { get; set; }
        public string Tckno { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }

        public virtual IEnumerable<UserAddress> UserAddresses { get; set; }
    }
}
