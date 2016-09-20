﻿using System;
using System.Data;
using System.Web.Services;
using data;
using System.Linq;
using System.Collections.Generic;

namespace service
{
    /// <summary>
    /// Stock Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
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
            List<s_stocks> stocks = new List<s_stocks>();
            #region Check User
            var context = new co_stocksEntities();
            var user = context.s_users.Where(x => x.user_guid == userGuid).FirstOrDefault();
            if (user == null)
                throw new Exception("Invalid User");
            #endregion
            stocks = context.s_stocks.Where(x => x.user_id == user.id).ToList();
            if (stocks == null || stocks.Count == 0)
                return stocks;
            Random rnd = new Random();
            for (int i = 0; i < stocks.Count; i++)
                stocks[i].price = rnd.Next(1, 1000);
            return stocks;
        }
    }
}