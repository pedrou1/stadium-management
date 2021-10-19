using stadium_management.CrossCuttingConcerns.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace stadium_management.ClientUi.Pages
{
    public class BaseAdministrator : System.Web.UI.Page
    {
        public Administrator loggedAdministrator
        {
            get
            {
                return Session[Constants.SessionKeys.LoggedAdministrator] as Administrator;
            }
            set
            {
                Session[Constants.SessionKeys.LoggedAdministrator] = value;
            }
        }

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (loggedAdministrator == null)
            {
                Response.Redirect("~/ClientUi/Pages/HomePublic.aspx");
            }
        }
    }
}