using model;
using model.viewModel;
using System;
using System.Linq;

namespace business
{
    public class userBusiness
    {

      public Result Login(loginViewModel model)
        {
            var result = new Result() { IsSuccess = true };
          try
            {
                var ctx = new data.co_stocksEntities();
                string userName = model.username;
                string password = model.password;
                var users = ctx.s_users.Where(x => x.username == userName && x.password == password).ToList();
                if (!users.Any())
                {
                    result.ReturnMessage = "User can not found";
                    result.IsSuccess = false;
                }
                var user = users.FirstOrDefault();
                result.ReturnCode = user.id;
                result.ReturnMessage = user.user_guid;
               
               
            }
            catch(Exception ex)
            {
                result.ReturnMessage = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

    }
}
