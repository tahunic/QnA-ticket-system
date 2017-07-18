using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QA.Web.Controllers
{
    public class AccessDeniedController : Controller
    {
        // GET: AccessDenied
        public ActionResult Index()
        {
            return View();
        }
    }
}