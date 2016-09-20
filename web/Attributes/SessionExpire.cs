using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace web.Attributes
{
    public class SessionExpire : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session[fields.CommonKeys.userGUID] == null)
            {
                new RedirectToRouteResult(new RouteValueDictionary
            {
             { "action", "Login" },
            { "controller", "Member" },
            { "returnUrl", filterContext.HttpContext.Request.RawUrl}
             });

                return;
            }

        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }
    }
}