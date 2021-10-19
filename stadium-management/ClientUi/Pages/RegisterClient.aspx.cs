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
    public partial class RegisterClient : System.Web.UI.Page
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

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            Client client = new Client();
            client.Name = this.txtName.Text;
            client.LastName = this.txtLastname.Text;
            client.Username = this.txtUsername.Text;
            client.Password = this.txtPassword.Text;

            try
            {
                SignUpClientOut outSignUpClient = Facade.SignUpClient(client);
                if (outSignUpClient.OperationResult == OperationResult.Success)
                {
                    this.loggedClient = outSignUpClient.Client;
                    Response.Redirect("~/ClientUi/Pages/HomePublic.aspx");
                }
                else if (outSignUpClient.OperationResult == OperationResult.UsernameAlreadyExist)
                {
                    lblError.Text = "Ese usuario ya existe, elija otro.";
                    lblError.Visible = true;
                }
                else
                {
                    lblError.Text = "Ocurrió un error al procesar la solicitud, intente mas tarde";
                    lblError.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}