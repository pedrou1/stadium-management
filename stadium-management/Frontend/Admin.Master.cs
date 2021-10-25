using stadium_management.CrossCuttingConcerns.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace stadium_management.Frontend
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (loggedAdministrator != null)
            {
                lblName.Text = loggedAdministrator.Name;
            }
        }

        // session variable
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

        protected void btnEndSession_Click(object sender, EventArgs e)
        {
            this.loggedAdministrator = null;
            Response.Redirect("~/Frontend/Forms/HomePublic.aspx");
        }
    }
}