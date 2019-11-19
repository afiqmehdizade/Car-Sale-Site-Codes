using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspFinalProje.Controllers
{
    public class AuthoizationFilter :AuthorizeAttribute,IAuthorizationFilter
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute),true))
            {
                return;
            }

            if (HttpContext.Current.Session["lguser"] == null)
            {
                filterContext.Result = new RedirectResult("/Account/Login");
            }
        }
    }
}