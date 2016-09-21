using model;
using model.viewModel;
using System;
using System.Linq;

namespace business
{
    public class stockBusiness
    {

        public Result AddStock(stockViewModel model)
        {
            var result = new Result() { IsSuccess = true };
            try
            {
                var ctx = new data.co_stocksEntities();
                string code = model.code;
                var stocks = ctx.s_stocks.Where(x => x.code ==code).ToList();
                if (stocks.Any())
                {
                    result.ReturnMessage = "this code is exists";
                    result.IsSuccess = false;
                    return result;
                }
                ctx.s_stocks.Add(new data.s_stocks() {
                    code=model.code,name=model.name,
                    quantity=model.quantity,is_active=true,
                    user_guid = model.user_guid
                });
                ctx.SaveChanges();  
                result.ReturnMessage = "Stock added";
            }
            catch (Exception ex)
            {
                result.ReturnMessage = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        //public List<stockViewModel> StockList(int userId)
        //{
        //    try
        //    {
        //        var srv = new web.stockService();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    } 
        //}

    }
}
