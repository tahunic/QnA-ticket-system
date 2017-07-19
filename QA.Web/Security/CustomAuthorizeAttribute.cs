using QA.Service;
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
            //if (string.IsNullOrEmpty(SessionPersister.Username))
            if (SessionPersister.User == null)
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    Controller = "Account",
                    Action = "Login"
                }));
            else
            {
                AccountModel am = new AccountModel();
                CustomPrincipal mp = new CustomPrincipal(am.Find(SessionPersister.User.Username));
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