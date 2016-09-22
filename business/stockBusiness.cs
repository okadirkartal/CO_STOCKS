using fields;
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
            var result = new Result() { IsSuccess = false };
            try
            {
                if (!string.IsNullOrEmpty(model.user_guid))
                {
                    var ctx = new data.co_stocksEntities();
                    string code = model.code;
                    var stocks = ctx.s_stocks.Where(x => x.code == code).ToList();
                    if (stocks.Any())
                    {
                        result.ReturnMessage = "this code is exists";
                        return result;
                    }
                    ctx.s_stocks.Add(new data.s_stocks()
                    {
                        code = model.code,
                        name = model.name,
                        quantity = model.quantity,
                        is_active = true,
                        user_guid = model.user_guid
                    });
                    ctx.SaveChanges();
                    result.ReturnMessage = "Stock added";
                }
            }
            catch (Exception ex)
            {
                result.ReturnMessage = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        public bool DeleteStock(int stockId,string userGUID)
        {
            try
            {
                if (!string.IsNullOrEmpty(userGUID))
                {
                    var ctx = new data.co_stocksEntities();
                    var stock = ctx.s_stocks.Where(x => x.Id == stockId && x.user_guid == userGUID).FirstOrDefault();
                    if (stock != null)
                    {
                        ctx.s_stocks.Remove(stock);
                        ctx.SaveChanges();
                        return true;
                    }
                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }


        public stockSettingsViewModel GetStockSettings(string userGUID)
        {
            try
            {if (!string.IsNullOrEmpty(userGUID))
                {
                    var ctx = new data.co_stocksEntities();
                    var item = ctx.stock_settings.Where(x => x.user_guid == userGUID).FirstOrDefault();
                    int minute = (item != null) ? item.stock_ticker_min : CommonKeys.DEFAULT_STOCK_TICKER_MINUTE;
                    return new stockSettingsViewModel() { ticker_minute = minute, user_guid = userGUID };
                }
                return new stockSettingsViewModel();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateStockTickers(int tickerMinute,string userGUID)
        {
            try
            {
                if (!string.IsNullOrEmpty(userGUID))
                {
                    var ctx = new data.co_stocksEntities();
                    var stock_ticker = ctx.stock_settings.Where(x => x.user_guid == userGUID).FirstOrDefault();
                    if (stock_ticker != null)
                        stock_ticker.stock_ticker_min = tickerMinute;
                    else
                    {
                        ctx.stock_settings.Add(new data.stock_settings()
                        {
                            stock_ticker_min = tickerMinute,
                            user_guid = userGUID
                        });
                    }
                    ctx.SaveChanges();
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
