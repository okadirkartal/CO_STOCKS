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
                    return result;
                }
                var user = users.FirstOrDefault();
                user.last_logindate = DateTime.Now;
                ctx.SaveChanges();
                result.ReturnCode = user.id;
                result.ReturnMessage = user.user_guid;


            }
            catch (Exception ex)
            {
                result.ReturnMessage = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        public Result Register(registerViewModel model)
        {
            var result = new Result() { IsSuccess = true };
            try
            {
                if (!model.password.Equals(model.passwordRepeat))
                {
                    result.ReturnMessage = "Password and password repeat did not match";
                    result.IsSuccess = false;
                    return result;
                }


                var ctx = new data.co_stocksEntities();
                string userName = model.username;

                var users = ctx.s_users.Where(x => x.username == userName).ToList();
                if (!users.Any())
                {
                    string guid = Guid.NewGuid().ToString().Replace("-", "");
                    ctx.s_users.Add(new data.s_users()
                    {
                        username = model.username,
                        password = model.password,
                        name = model.name,
                        surname = model.surname,
                        user_guid = guid,
                        creation_date = DateTime.Now
                    });
                    ctx.SaveChanges();
                    result.ReturnMessage = guid;

                }
                else
                {
                    result.ReturnMessage = "This username is exists";
                    result.IsSuccess = false;
                }

            }
            catch (Exception ex)
            {
                result.ReturnMessage = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

    }
}
