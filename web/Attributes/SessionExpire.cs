using fields;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace web.Attributes
{
    public class SessionExpire : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session == null || HttpContext.Current.Session[CommonKeys.APPLICATION_CURRENT_USER] == null)
            {
            filterContext.Result = new RedirectResult("/Stock/Login?returnUrl=" + filterContext.HttpContext.Request.RawUrl);
                /*RedirectToRouteResult(new RouteValueDictionary
            {
             { "action", "Login" },
            { "controller", "Stock" },
            { "returnUrl", filterContext.HttpContext.Request.RawUrl}
             });

                return;
           */ }

        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }
    }
}