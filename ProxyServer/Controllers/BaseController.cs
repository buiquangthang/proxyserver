using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProxyMVCv1.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["username"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Login" }));
            }

            base.OnActionExecuting(filterContext);
        }
    }
}