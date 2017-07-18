using QA.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QA.Web.Security
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (string.IsNullOrEmpty(SessionPersister.username))
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    Controller = "Account",
                    Action = "Login"
                }));
            else
            {
                AccountModel am = new AccountModel();
                CustomPrincipal mp = new CustomPrincipal(am.Find(SessionPersister.username));
                if (!mp.IsInRole(Roles))
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                    {
                        Controller = "AccessDenied",
                        Action = "Index"
                    }));
            }
        }
    }
}