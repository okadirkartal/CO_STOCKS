using System;
using System.Data;
using System.Web.Services;
using data;
using System.Linq;
namespace CO_STOCK_SERVICE
{
    /// <summary>
    /// Holding Ordino Web Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class StockExchange : System.Web.Services.WebService
    {
        /// <summary>
        /// This service returns all Medyanet Ordino information with money, portal, customer, etc.
        /// </summary>
        /// <param name="clientID">Medyanet gives this id to check security.</param>
        /// <param name="startDate">Start date of ordinos.</param>
        /// <param name="endDate">End date of ordinos.</param>
        /// <param name="portalID">Portal id of all rows. Can be used as a filter option. 0 means all rows.</param>
        /// <param name="ordinoID">ID of ordino.</param>
        /// <param name="ordinoItemID">ID of ordino item.</param>
        /// <param name="pagingStartRowNumber">Paging start row number.</param>
        /// <param name="pagingEndRowNumber">Paging end row number.</param>
        /// <returns>Returns a dataset object with filled with all rows.</returns>
        [WebMethod]
        public DataSet GetData(string userGuid)
        {
            #region Check Dirty Fields
            // 8893BAD4-7DEA-4B07-95DF-1693BAA1CE0D: Hurriyet Ordino Web Service
            var context = new  co_stocksEntities();
            var user=context.s_users.

            //if (!clientID.Equals("8893BAD4-7DEA-4B07-95DF-1693BAA1CE0D"))
            //{
            //    throw new Exception("You client id is not valid. Please contact to Medyanet IT.");
            //}


            #endregion
           
            /*  var db = new DataContext();
              var result = db.WS_HoldingOrdino(startDate, endDate, portalID, ordinoID, ordinoItemID, pagingStartRowNumber, pagingEndRowNumber).ConvertToDataSet();

              return result;*/
            return null;
        }
    }
}
