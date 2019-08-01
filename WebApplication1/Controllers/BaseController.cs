using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebApplication1.Common;

namespace WebApplication1.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public object SessionHelper { get; private set; }

        // GET: Admin/Base
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var session = (LoginAdmin)Session[CommonContants.ADMIN_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Admin", action = "Index"}));
            }
            base.OnActionExecuted(filterContext);
        }
    }
}
