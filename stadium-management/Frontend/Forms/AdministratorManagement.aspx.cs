using stadium_management.CrossCuttingConcerns.Entities;
using stadium_management.CrossCuttingConcerns.InMethods;
using stadium_management.CrossCuttingConcerns.OutMethods;
using stadium_management.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace stadium_management.Frontend.Forms
{
    public partial class AdministratorManagement : BaseAdministrator
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                btnCancel.Visible = false;
                btnUpdate.Visible = false;
                dvId.Visible = false;
                loadAdministratorsData();
            }
        }

        protected virtual void loadAdministratorsData()
        {
            GetAdministratorsOut outGetAdministratorsOut = Facade.GetAdministrators(new GetAdministratorsIn { PageIndex = 0, PageSize = grdAdministrators.PageSize });
            this.grdAdministrators.DataSource = outGetAdministratorsOut.Administrators;
            this.grdAdministrators.DataBind();
            DatabindRepeater(0, grdAdministrators.PageSize, outGetAdministratorsOut.TotalRows);
        }
        protected void linkButton_Click(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            pageIndex -= 1;
            grdAdministrators.PageIndex = pageIndex;
            GetAdministratorsOut outGetAdministratorsOut = Facade.GetAdministrators(new GetAdministratorsIn { PageIndex = pageIndex, PageSize = grdAdministrators.PageSize });
            grdAdministrators.DataSource = outGetAdministratorsOut.Administrators;
            grdAdministrators.DataBind();
            DatabindRepeater(pageIndex, grdAdministrators.PageSize, outGetAdministratorsOut.TotalRows);
        }

        private void DatabindRepeater(int pageIndex, int pageSize, int totalRows)
        {
            int totalPages = totalRows / pageSize;
            if ((totalRows % pageSize) != 0)
            {
                totalPages += 1;
            }

            List<ListItem> pages = new List<ListItem>();
            if (totalPages > 1)
            {
                for (int i = 1; i <= totalPages; i++)
                {
                    pages.Add(new ListItem(i.ToString(), i.ToString(), i != (pageIndex + 1)));
                }
            }
            repeaterPaging.DataSource = pages;
            repeaterPaging.DataBind();
        }

        protected void AddAdministrator(object sender, EventArgs e)
        {
            lblMessageResult.Visible = false;
            Administrator administrator = new Administrator
            {
                Name = this.txtName.Text,
                LastName = this.txtLastname.Text,
                Username = this.txtUsername.Text,
                Password = this.txtPassword.Text,
                Telephone = this.txtTelephone.Text,
                DocumentNumber = this.txtDocumentNumber.Text
            };

            try
            {
                AddAdministratorOut outAddAdministrator = Facade.AddAdministrator(administrator);
                if (outAddAdministrator.OperationResult == OperationResult.Success)
                {
                    loadAdministratorsData();
                    ClearFields();
                    lblMessageResult.Text = "Administrador registrado con éxito.";
                    lblMessageResult.Visible = true;
                }
                else if (outAddAdministrator.OperationResult == OperationResult.UsernameAlreadyExist)
                {
                    lblMessageResult.Text = "Ya existe el usuario ingresado.";
                    lblMessageResult.Visible = true;

                }
                else
                {
                    ClearFields();
                    lblMessageResult.Text = "Ocurrió un error al procesar la solicitud, intente mas tarde.";
                    lblMessageResult.Visible = true;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ClearAdministrator(object sender, EventArgs e)
        {
            ClearFields();
        }

        protected void ClearFields()
        {
            this.txtName.Text = string.Empty;
            this.txtLastname.Text = string.Empty;
            this.txtDocumentNumber.Text = string.Empty;
            this.txtUsername.Text = string.Empty;
            this.txtPassword.Text = string.Empty;
            this.txtTelephone.Text = string.Empty;
            this.dvId.Visible = false;
            this.lblMessageResult.Text = "";
        }

        protected void grdAdministrators_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            lblMessageResult.Visible = false;
            if (e.CommandName == "DeleteAdministrator")
            {
                Administrator administrator = new Administrator();
                administrator.Id = Convert.ToInt32(e.CommandArgument);
                try
                {
                    DeleteAdministratorOut outDeleteAdministrator = Facade.DeleteAdministrator(administrator);
                    if (outDeleteAdministrator.OperationResult == OperationResult.Success)
                    {
                        loadAdministratorsData();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            if (e.CommandName == "UpdateAdministrator")
            {
                Administrator administrator = new Administrator();
                administrator.Id = Convert.ToInt32(e.CommandArgument);
                try
                {
                    GetAdministratorByIdOut outGetAdministratorById = Facade.GetAdministratorById(administrator);
                    if (outGetAdministratorById.OperationResult == OperationResult.Success)
                    {
                        loadAdministratorToUpdate(outGetAdministratorById.Administrator);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected virtual void loadAdministratorToUpdate(Administrator administrator)
        {
            txtId.Text = administrator.Id.ToString();
            txtName.Text = administrator.Name.ToString();
            txtLastname.Text = administrator.LastName.ToString();
            txtDocumentNumber.Text = administrator.DocumentNumber.ToString();
            txtTelephone.Text = administrator.Telephone.ToString();
            txtUsername.Text = administrator.Username.ToString();
            txtPassword.Text = administrator.Password.ToString();

            btnUpdate.Visible = true;
            btnCancel.Visible = true;
            btnAdd.Visible = false;
            btnClear.Visible = false;
            dvId.Visible = true;
        }

        protected void CancelAdministrator(object sender, EventArgs e)
        {
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            btnAdd.Visible = true;
            btnClear.Visible = true;
            ClearFields();
        }

        protected void UpdateAdministrator(object sender, EventArgs e)
        {
            lblMessageResult.Visible = false;

            try
            {
                Administrator administrator = new Administrator
                {
                    Id = int.Parse(txtId.Text),
                    Name = txtName.Text,
                    LastName = txtLastname.Text,
                    DocumentNumber = txtDocumentNumber.Text,
                    Telephone = txtTelephone.Text,
                    Username = txtUsername.Text,
                    Password = txtPassword.Text
                };

                UpdateAdministratorOut outUpdateAdministrator = Facade.UpdateAdministrator(administrator);

                if (outUpdateAdministrator.OperationResult == OperationResult.Success)
                {
                    loadAdministratorsData();
                    btnUpdate.Visible = false;
                    btnCancel.Visible = false;
                    btnAdd.Visible = true;
                    btnClear.Visible = true;
                    ClearFields();
                    lblMessageResult.Text = "Administrador modificado con éxito.";
                    lblMessageResult.Visible = true;
                }
                else if (outUpdateAdministrator.OperationResult == OperationResult.UsernameAlreadyExist)
                {
                    lblMessageResult.Text = "Ya existe un administrador con ese usuario.";
                    lblMessageResult.Visible = true;
                }
                else
                {
                    btnUpdate.Visible = false;
                    btnCancel.Visible = false;
                    btnAdd.Visible = true;
                    btnClear.Visible = true;
                    ClearFields();
                    lblMessageResult.Text = "Ocurrio un error al modificar el administrador.";
                    lblMessageResult.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}