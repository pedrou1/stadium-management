using stadium_management.CrossCuttingConcerns.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace stadium_management
{
    public partial class User : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (loggedClient != null)
            {
                dpdUser.Visible = true;
                linkLogin.Visible = false;
                linkSignUp.Visible = false;
                userName.Text = loggedClient.Name;
            }
            else
            {
                dpdUser.Visible = false;
                linkLogin.Visible = true;
                linkSignUp.Visible = true;
            }
            loggedAdministrator = null;
        }

        // session variable
        public Client loggedClient
        {
            get
            {
                return Session[Constants.SessionKeys.LoggedClient] as Client;
            }
            set
            {
                Session[Constants.SessionKeys.LoggedClient] = value;
            }
        }

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
            this.loggedClient = null;
            Response.Redirect("~/ClientUi/Pages/HomePublic.aspx");
        }
        public void SetUserSession()
        {
            if (loggedClient != null)
            {
                dpdUser.Visible = true;
                linkLogin.Visible = false;
                linkSignUp.Visible = false;
                userName.Text = loggedClient.Name;
            }
            else
            {
                dpdUser.Visible = false;
                linkLogin.Visible = true;
                linkSignUp.Visible = true;
            }
        }
    }
}