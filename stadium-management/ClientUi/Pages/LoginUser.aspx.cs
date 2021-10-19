using stadium_management.CrossCuttingConcerns.Entities;
using stadium_management.CrossCuttingConcerns.OutMethods;
using stadium_management.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace stadium_management.ClientUi.Pages
{
    public partial class LoginUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (loggedClient != null)
            {
                Response.Redirect("~/ClientUi/Pages/HomePublic.aspx");
            }

            if (!IsPostBack)
            {
                lblError.Visible = false;
            }
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

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            if (ckbAdministrator.Checked)
            {
                Administrator administrator = new Administrator
                {
                    Username = this.txtUser.Text,
                    Password = this.txtPassword.Text
                };

                try
                {
                    SignInAdministratorOut outSignInAdministrator = Facade.SignInAdministrator(administrator);
                    if (outSignInAdministrator.OperationResult == OperationResult.Success)
                    {
                        this.loggedAdministrator = outSignInAdministrator.Administrator;
                        Response.Redirect("~/ClientUi/Pages/AdministratorManagement.aspx");
                    }
                    else
                    {
                        lblError.Text = "Usuario o contraseña incorrecto";
                        lblError.Visible = true;
                        CleanFields();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            else
            {
                Client client = new Client
                {
                    Username = this.txtUser.Text,
                    Password = this.txtPassword.Text
                };

                try
                {
                    SignInClientOut outSignInClient = Facade.SignInClient(client);
                    if (outSignInClient.OperationResult == OperationResult.Success)
                    {
                        this.loggedClient = outSignInClient.Client;
                        Response.Redirect("~/ClientUi/Pages/HomePublic.aspx");
                    }
                    else
                    {
                        lblError.Text = "Usuario o contraseña incorrecto";
                        lblError.Visible = true;
                        CleanFields();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected void CleanFields()
        {
            this.txtUser.Text = "";
            this.txtPassword.Text = "";
        }
    }
}