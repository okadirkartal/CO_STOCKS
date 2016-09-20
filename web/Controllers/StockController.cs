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

        public ActionResult Login(loginRegisterViewModel model)
        {
            return View(model);

        }
         
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult _LoginPartial(loginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var ub = new userBusiness();
                var result = ub.Login(model);
                if (result.IsSuccess)
                {
                    Session[fields.CommonKeys.userGUID] = result.ReturnMessage;
                    return Redirect("/Stock/Index");
                }
                ViewBag.Message = result.ReturnMessage;
            }
                return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult _RegisterPartial(registerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var ub = new userBusiness();
                var result = ub.Register(model);
                if (result.IsSuccess)
                {
                    Session[fields.CommonKeys.userGUID] = result.ReturnMessage;
                    return Redirect("/Stock/Index");
                }
                ViewBag.Message = result.ReturnMessage;
            }
            return View(model);
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


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult _AddStockPartial(stockViewModel model)
        {
            if (ModelState.IsValid)
            {
                //var ub = new userBusiness();
                //var result = ub.Register(model);
                //if (result.IsSuccess)
                //{
                //    Session[fields.CommonKeys.userGUID] = result.ReturnMessage;
                //    return Redirect("/Stock/Index");
                //}
                //ViewBag.Message = result.ReturnMessage;
                return null;
            }
            return View(model);
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
            return Redirect("/Stock/Index");
        }
    }
}