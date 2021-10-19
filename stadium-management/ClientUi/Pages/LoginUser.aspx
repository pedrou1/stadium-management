<%@ Page Title="" Language="C#" MasterPageFile="~/ClientUi/User.Master" AutoEventWireup="true" CodeBehind="LoginUser.aspx.cs" Inherits="stadium_management.ClientUi.Pages.LoginUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="container">
        <div class="row mt-5">
            <div class="col-md-6 mx-auto mt-5">
                <div class="card ">
                    <h5 class="card-header info-color white-text text-center py-4">
                        <strong>Iniciar Sesion</strong>
                    </h5>
                
                    <div class="card-body px-lg-5 pt-0 mt-2">
                        <div class="text-left" style="color: #757575">
                            <div class="md-form">
                                <asp:Label ID="lblUser" Text="Usuario" runat="server"></asp:Label>
                                <asp:TextBox class="form-control form-control-sm" ID="txtUser" MaxLength="50" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvUser" CssClass="text-danger small" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtUser"></asp:RequiredFieldValidator>                                
                            </div>
                            <div class="md-form">
                                <asp:Label ID="lblPassword" Text="Contraseña" runat="server"></asp:Label>
                                <asp:TextBox class="form-control form-control-sm" ID="txtPassword" MaxLength="50" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvPassword" CssClass="text-danger small" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                            </div>

                            <div class="md-form">
                                <div class="custom-checkbox">
                                    <asp:CheckBox id="ckbAdministrator" CssClass="mr-2" runat="server"/>
                                    <asp:Label ID="lblAdministrador" CssClass="" Text="Soy Administrador" runat="server"></asp:Label>
                                </div>
                            </div>
                        
                            <div class="form-group">
                                <asp:Label ID="lblError" Text="" CssClass="text-danger small" runat="server" Visible = "false"></asp:Label>
                            </div>
                            <div class="text-center">
                                <asp:Button class="btn btn-outline-info btn-rounded btn-block my-4 waves-effect z-depth-0 text-center" ID="btnLogin" Text="Iniciar Sesion" runat="server" OnClick="btnLogin_Click"/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
