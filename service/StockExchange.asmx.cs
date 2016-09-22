using data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Services;

namespace service
{
    /// <summary>
    /// Stock Service
    /// </summary>
    [WebService(Namespace = "http://localhost:50496/StockExchange.asmx")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class StockExchange : System.Web.Services.WebService
    {
        /// <summary>
        /// This service returns all stocks by given user_guid
        /// </summary>
        /// <param name="userGuid">User unique id.</param>
        /// <returns>Returns a list of stocks.</returns>
        [WebMethod]
        public List<s_stocks> GetStocks(string userGuid)
        {
            var context = new co_stocksEntities();

            #region User Authenticate by given user_guid
            var user = context.s_users.Where(x => x.user_guid == userGuid).FirstOrDefault();
            if (user == null)
                throw new Exception("Invalid user!!!");
            #endregion


            List<s_stocks> stocks = new List<s_stocks>();
      
      
            stocks = context.s_stocks.Where(x => x.user_guid == userGuid).ToList();
            if (stocks == null || stocks.Count == 0)
                return stocks;
            Random rnd = new Random();
            for (int i = 0; i < stocks.Count; i++)
                stocks[i].price = rnd.Next(1, 1000);
            return stocks;
        }
    }
}
