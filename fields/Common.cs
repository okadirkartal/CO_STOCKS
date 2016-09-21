using model.viewModel;
using System.Web;

namespace fields
{
    public class Current
    {
        /// <summary>
        /// Gets or sets the current user of the application.
        /// </summary>
        public static userSessionModel User
        {
            get
            {

                return HttpContext.Current.Session[CommonKeys.APPLICATION_CURRENT_USER]!=null?(userSessionModel)HttpContext.Current.Session[CommonKeys.APPLICATION_CURRENT_USER]:null;
            }
            set
            {
                HttpContext.Current.Session[CommonKeys.APPLICATION_CURRENT_USER] = value;
            }
        }
    }
}