using business;
using fields;
using model.viewModel;
using System.Collections.Generic;
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
                    Current.User = new userSessionModel()
                    { userGUID = result.ReturnMessageList[0], userName = result.ReturnMessageList[1] };


                    string url = !string.IsNullOrEmpty(Request.QueryString["returnUrl"]) ?
                        Request.QueryString["returnUrl"] : "/Stock/Index";

                    return Redirect(url);
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
                    Current.User = new userSessionModel()
                    { userGUID = result.ReturnMessageList[0], userName = result.ReturnMessageList[1] };

                    return Redirect("/Stock/Index");
                }
                ViewBag.Message = result.ReturnMessage;
            }
            return View(model);
        }


        #region Stock Operations


        [SessionExpire]
        public ActionResult AddStock()
        {
            return View();
        }

        [SessionExpire]
        public ActionResult AddStockResult()
        {
            return View();
        }



        [SessionExpire]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _AddStockPartial(stockViewModel model)
        {
            if (ModelState.IsValid && model != null)
            {
                var sb = new stockBusiness();
                model.user_guid = Current.User.userGUID;
                var result = sb.AddStock(model);
                if (result.IsSuccess)
                {
                    return Redirect("/Stock/AddStockResult");
                }
                ViewBag.Message = result.ReturnMessage;
            }
            return View(model);
        }

        [SessionExpire]
        public ActionResult StockList()
        {

            return View();
        }


        [SessionExpire]
        public ActionResult StockListJson()
        {
            var srv = new stockService.StockExchangeSoapClient();
            srv.Open();
            var result = srv.GetStocks(Current.User.userGUID);
            srv.Close();

            List<stockViewModel> stocks = new List<stockViewModel>();
            if (result != null && result.Count > 0)
            {

                foreach (var item in result)
                    stocks.Add(new stockViewModel()
                    {
                        Id=item.Id,
                        code = item.code,
                        name = item.name,
                        price = item.price.Value,
                        quantity = item.quantity.Value
                    });
            }
            return Json(stocks, JsonRequestBehavior.AllowGet);
        }


        [SessionExpire]
        public ActionResult DeleteStock(string stockId)
        {
            int intStockId;
            int.TryParse(stockId, out intStockId);

            if (new stockBusiness().DeleteStock(intStockId, Current.User.userGUID))
                return Json(new { result = 1 }, JsonRequestBehavior.AllowGet);
            return Json(new { result = -1 }, JsonRequestBehavior.AllowGet);
        }

        [SessionExpire]
        public ActionResult StockSettings()
        {
            var stockBusiness = new stockBusiness();
            var model = stockBusiness.GetStockSettings(Current.User.userGUID);
            return View(model);
        }

        [SessionExpire]
        public ActionResult StockSettingsJson()
        {
            var stockBusiness = new stockBusiness();
            var model = stockBusiness.GetStockSettings(Current.User.userGUID);
            return Json(model,JsonRequestBehavior.AllowGet);
        }

        [SessionExpire] 
        [HttpPost]
        public ActionResult _StockSettingsPartial(stockSettingsViewModel model)
        {
           

            if (ModelState.IsValid)
            {
                var stockBusiness = new stockBusiness();
                stockBusiness.UpdateStockTickers(model.ticker_minute, Current.User.userGUID);
                return Redirect(string.Format("/Stock/Result?code={0}", MessageCodes.Stock_Ticker_Settings_Are_Saved));
            }
            return View();
        }

         

        #endregion

        // GET: Logout Member
        [SessionExpire]
        public ActionResult Logout()
        {
            Session.Abandon();
            Session.RemoveAll();
            Session.Clear();
            return RedirectToAction("Login");
        }


        [SessionExpire]
        public ActionResult Result()
        {
            return View();
        }
    }
}