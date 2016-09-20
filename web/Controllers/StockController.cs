using business;
using model.viewModel;
using System.Threading.Tasks;
using System.Web.Mvc;
using web.Attributes;

namespace web.Controllers
{
    public class StockController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
         
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(loginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var ub = new userBusiness();
                var result = ub.Login(model);
                if (result.IsSuccess)
                {
                    Session[fields.CommonKeys.userGUID] = result.ReturnMessage;
                    return Redirect("/Home/Index");
                }
                ViewBag.Message = result.ReturnMessage;
            }
                return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register()
        {
            return View();
        }


        [SessionExpire]
        public ActionResult Stocks()
        {
            return null;
        }

        [SessionExpire]
        public ActionResult AddStock()
        {
            return View();
        }

        [SessionExpire]
        public ActionResult StockList()
        {
            return View();
        }

        // GET: Logout Member
        public ActionResult Logout()
        {
            Session.Remove(fields.CommonKeys.userGUID);
            Session.Abandon();
            return Redirect("/Home");
        }
    }
}