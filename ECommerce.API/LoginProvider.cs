using ECommerce.Core.Model;
using ECommerce.Core.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.OAuth;
using System.Threading.Tasks;
using System.Security.Claims;

namespace ECommerce.API
{
    public partial class LoginProvider : OAuthAuthorizationServerProvider
    {
        ECommerceContext db = new ECommerceContext();
        public User Login(string email, string password)
        {
            var result = db.Users.Where(x => x.Email == email && x.Password == password && x.IsActive == true).ToList();
            if (result.Count > 0)
            {
                //login başarılı
                return result.FirstOrDefault();
            }
            else
            {
                return null;
            }

        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return base.ValidateClientAuthentication(context);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var result = Login(context.UserName, context.Password);
            if (result == null)
            {
                //false
                context.SetError("invalid_grant", "Hatalı Giriş");
            }
            else
            {
                var idendity = new ClaimsIdentity(context.Options.AuthenticationType);
                idendity.AddClaim( new Claim("UserName", context.UserName));
                idendity.AddClaim(new Claim("Password", context.Password));
                idendity.AddClaim(new Claim("UserID", result.ID.ToString()));

                context.Validated(idendity);
            }
            return base.GrantResourceOwnerCredentials(context);
        }

    }
}