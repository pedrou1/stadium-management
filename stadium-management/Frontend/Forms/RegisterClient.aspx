<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend/User.Master" AutoEventWireup="true" CodeBehind="RegisterClient.aspx.cs" Inherits="stadium_management.Frontend.Forms.RegisterClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
      <div class="container">
        <div class="row mt-5">
            <div class="col-md-6 mx-auto mt-5">
                <div class="card">
                    <h5 class="card-header info-color white-text text-center py-4">
                        <strong>Registrarse</strong>
                    </h5>
                    <div class="card-body px-lg-5 pt-0">
                        <div class="text-left" style="color: #757575">
                            <div class="form-row">
                                <div class="col">
                                    <div class="md-form">
                                        <asp:Label ID="lblName" Text="Nombre" runat="server"></asp:Label>
                                        <asp:TextBox class="form-control form-control-sm" ID="txtName" MaxLength="50" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator Display = "Dynamic" CssClass="text-danger small" ID="rfvName" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtName"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator Display = "Dynamic" ID="revName" CssClass="text-danger small" ControlToValidate="txtName" runat="server" ErrorMessage="Caracteres inválidos" ValidationExpression="^[a-zA-Z]*$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="col">
                                    <div class="md-form">
                                        <asp:Label ID="lblLastname" Text="Apellido" runat="server"></asp:Label>
                                        <asp:TextBox class="form-control form-control-sm" ID="txtLastname" MaxLength="50" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator Display = "Dynamic" CssClass="text-danger small form-group" ID="rfvLastname" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtLastname"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator Display = "Dynamic" ID="revLastName" CssClass="text-danger small form-group" ControlToValidate="txtLastname" runat="server" ErrorMessage="Caracteres inválidos" ValidationExpression="^[a-zA-Z]*$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="md-form mt-0">
                                <asp:Label ID="lblUsername" Text="Usuario" runat="server"></asp:Label>
                                <asp:TextBox class="form-control form-control-sm" ID="txtUsername" MaxLength="50" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator Display = "Dynamic" ID="rfvUsername" CssClass="text-danger small" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtUsername"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator Display = "Dynamic" ID="revUsername" CssClass="text-danger small" ControlToValidate="txtUsername" runat="server" ErrorMessage="Caracteres inválidos" ValidationExpression="^[a-zA-Z0-9]*$"></asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator Display = "Dynamic" ID="rev2Username" CssClass="text-danger small" ControlToValidate="txtUsername" runat="server" ErrorMessage="El largo mínimo es de 6 caracteres" ValidationExpression="^.{6,50}$"></asp:RegularExpressionValidator>
                                
                            </div>
                            <div class="md-form">
                                <asp:Label ID="lblPassword" Text="Contraseña" runat="server"></asp:Label>
                                <asp:TextBox class="form-control form-control-sm" ID="txtPassword" MaxLength="100" runat="server" TextMode="Password" ></asp:TextBox>
                                <asp:RequiredFieldValidator Display = "Dynamic" ID="rfvPassword" runat="server" CssClass="text-danger small " ErrorMessage="Campo obligatorio" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator Display = "Dynamic" ID="RegularExpressionValidator2" CssClass="text-danger small" ControlToValidate="txtPassword" runat="server" ErrorMessage="Caracteres inválidos" ValidationExpression="^[a-zA-Z0-9]*$"></asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator Display = "Dynamic" ID="RegularExpressionValidator1" CssClass="text-danger small" ControlToValidate="txtPassword" runat="server" ErrorMessage="Contraseña insegura, debe tener al menos 8 caracteres" ValidationExpression="^.{8,50}$"></asp:RegularExpressionValidator>
                            </div>
                            <div class="md-form">
                                <asp:Label ID="Label1" Text="Confirmar Contraseña" runat="server"></asp:Label>
                                <asp:TextBox class="form-control form-control-sm" ID="txtPasswordConfirm" MaxLength="100" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator Display = "Dynamic" ID="RequiredFieldValidator1" runat="server" CssClass="text-danger small" ErrorMessage="Campo obligatorio" ControlToValidate="txtPasswordConfirm"></asp:RequiredFieldValidator>
                                <asp:CompareValidator id="comparePasswords" CssClass="text-danger small" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtPasswordConfirm" ErrorMessage="Las contraseñas no coinciden" Display="Dynamic"></asp:CompareValidator>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblError" Text="" CssClass="text-danger" runat="server" Visible = "false"></asp:Label>
                            </div>
                            <div class="text-center">
                                <asp:Button class="btn btn-outline-info btn-rounded btn-block my-4 waves-effect z-depth-0" ID="btnRegister" Text="Registrarse" runat="server" OnClick="btnRegister_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
