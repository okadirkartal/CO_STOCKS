using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using web.Controllers;
using model.viewModel;

namespace web.Tests.Controllers
{
    [TestClass]
    public class StockControllerTest
    {
        [TestMethod]
        public void Index()
        {
            StockController controller = new StockController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void Login()
        {
            StockController controller = new StockController();
            ViewResult result = controller.Login(new loginRegisterViewModel()) as ViewResult;
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void _LoginPartial()
        {
            StockController controller = new StockController();
            ViewResult result = controller._LoginPartial(new loginViewModel()) as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void _RegisterPartial()
        {
            StockController controller = new StockController();
            ViewResult result = controller._RegisterPartial(new registerViewModel()) as ViewResult;
            Assert.IsNotNull(result);
        }


        #region Stock Operations
         
        [TestMethod]
        public void AddStock()
        {
            StockController controller = new StockController();
            ViewResult result = controller.AddStock() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AddStockResult()
        {
            StockController controller = new StockController();
            ViewResult result = controller.AddStockResult() as ViewResult;
            Assert.IsNotNull(result);
        }



        [TestMethod]
        public void _AddStockPartial()
        {
            StockController controller = new StockController();
            ViewResult result = controller._AddStockPartial(new stockViewModel()) as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void StockList()
        {
            StockController controller = new StockController();
            ViewResult result = controller.StockList() as ViewResult;
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void StockListJson()
        {
            StockController controller = new StockController();
            ViewResult result = controller.StockListJson() as ViewResult;
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void DeleteStock()
        {
            StockController controller = new StockController();
            ViewResult result = controller.DeleteStock("mouse") as ViewResult;
            Assert.IsNotNull(result);
        }

        #endregion

        [TestMethod]
        public void Logout()
        {
            StockController controller = new StockController();
            ActionResult result = controller.Logout() as  ActionResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Result()
        {
            StockController controller = new StockController();
            ActionResult result = controller.Result() as ActionResult;
            Assert.IsNotNull(result);
        }
    }

}
