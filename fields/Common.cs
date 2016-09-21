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
                return (userSessionModel)HttpContext.Current.Session[CommonKeys.APPLICATION_CURRENT_USER];
            }
            set
            {
                HttpContext.Current.Session[CommonKeys.APPLICATION_CURRENT_USER] = value;
            }
        }
    }
}