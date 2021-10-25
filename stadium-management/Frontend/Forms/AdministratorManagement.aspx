<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend/Admin.Master" AutoEventWireup="true" CodeBehind="AdministratorManagement.aspx.cs" Inherits="stadium_management.Frontend.Forms.AdministratorManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentAdmin" runat="server">

    <div style="color: #757575;">
        <div class="row mt-3">
            <div class="col-md-6 mx-auto">
                <h2>Administración de Empleados
                </h2>
                <div class="card">
                    <div class="card-body">
                        <div class="form-row">
                            <div id="dvId" runat="server" class="col-md-1 mb-3">
                                <asp:Label ID="lblId" Text="Codigo" runat="server"></asp:Label>
                                <asp:TextBox CssClass="form-control form-control-sm" ID="txtId" runat="server" Enabled="false"></asp:TextBox>
                            </div>
                            <div class="col-md-3 mb-3">
                                <asp:Label ID="lblName" Text="Nombre" runat="server"></asp:Label>
                                <asp:TextBox CssClass="form-control form-control-sm" ID="txtName" MaxLength="50" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator Display="Dynamic" ID="rfvName" CssClass="text-danger small" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtName"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator Display="Dynamic" ID="revName" CssClass="text-danger small" ControlToValidate="txtName" runat="server" ErrorMessage="Caracteres inválidos" ValidationExpression="^[a-zA-Z]*$"></asp:RegularExpressionValidator>
                            </div>
                            <div class="col-md-3 mb-3">
                                <asp:Label ID="lblLastname" Text="Apellido" runat="server"></asp:Label>
                                <asp:TextBox CssClass="form-control form-control-sm" ID="txtLastname" MaxLength="50" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator Display="Dynamic" ID="rfvLastname" CssClass="text-danger small" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtLastname"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator Display="Dynamic" ID="revLastName" CssClass="text-danger small form-group" ControlToValidate="txtLastname" runat="server" ErrorMessage="Caracteres inválidos" ValidationExpression="^[a-zA-Z]*$"></asp:RegularExpressionValidator>
                            </div>
                            <div class="col-md-3 mb-3">
                                <asp:Label ID="lblDocumentNumber" Text="Documento" runat="server"></asp:Label>
                                <asp:TextBox CssClass="form-control form-control-sm" ID="txtDocumentNumber" MaxLength="50" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator Display="Dynamic" ID="rfvDocumentNumber" CssClass="text-danger small" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtDocumentNumber"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-2 mb-3">
                                <asp:Label ID="lblTelephone" Text="Telefono" runat="server"></asp:Label>
                                <asp:TextBox CssClass="form-control form-control-sm" ID="txtTelephone" MaxLength="15" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator Display="Dynamic" ID="rfvTelephone" CssClass="text-danger small" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtTelephone"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator Display="Dynamic" ID="revTelephone" ControlToValidate="txtTelephone" CssClass="text-danger small" runat="server" ErrorMessage="Solo números" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col-md-3 mb-3">
                                <asp:Label ID="lblUsername" Text="Usuario" runat="server"></asp:Label>
                                <asp:TextBox CssClass="form-control form-control-sm" ID="txtUsername" MaxLength="50" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator Display="Dynamic" ID="rfvUsername" CssClass="text-danger small" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtUsername"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator Display="Dynamic" ID="revUsername" CssClass="text-danger small" ControlToValidate="txtUsername" runat="server" ErrorMessage="Caracteres inválidos" ValidationExpression="^[a-zA-Z0-9]*$"></asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator Display="Dynamic" ID="rev2Username" CssClass="text-danger small" ControlToValidate="txtUsername" runat="server" ErrorMessage="Debe tener al menos 6 caracteres" ValidationExpression="^.{6,50}$"></asp:RegularExpressionValidator>
                            </div>
                            <div class="col-md-3 mb-3">
                                <asp:Label ID="lblPassword" Text="Contraseña" runat="server"></asp:Label>
                                <asp:TextBox CssClass="form-control form-control-sm" ID="txtPassword" MaxLength="50" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator Display="Dynamic" ID="rfvPassword" runat="server" CssClass="text-danger small " ErrorMessage="Campo obligatorio" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator Display="Dynamic" ID="RegularExpressionValidator2" CssClass="text-danger small" ControlToValidate="txtPassword" runat="server" ErrorMessage="Caracteres inválidos" ValidationExpression="^[a-zA-Z0-9]*$"></asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator Display="Dynamic" ID="RegularExpressionValidator1" CssClass="text-danger small" ControlToValidate="txtPassword" runat="server" ErrorMessage="Contraseña insegura, debe tener al menos 8 caracteres" ValidationExpression="^.{8,50}$"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col-md-3 mb-3">
                                <asp:Label ID="lblMessageResult" Text="" CssClass="text-danger" runat="server" Visible="false"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="card-footer text-center">
                        <asp:Button class="btn btn-primary btn-md btn-rounded" ID="btnAdd" Text="Agregar" runat="server" OnClick="AddAdministrator" />
                        <asp:Button class="btn btn-primary btn-md btn-rounded" ID="btnUpdate" Text="Modificar" runat="server" OnClick="UpdateAdministrator" />
                        <asp:Button class="btn btn-primary btn-md btn-rounded" ID="btnCancel" Text="Cancelar" runat="server" OnClick="CancelAdministrator" CausesValidation="false" />
                        <asp:Button class="btn btn-primary btn-md btn-rounded" ID="btnClear" Text="Limpiar" runat="server" OnClick="ClearAdministrator" CausesValidation="false" />
                    </div>
                </div>
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-md-12 mx-auto">
                <div class="card">
                    <div class="table-responsive">
                        <div class="card-body">
                            <asp:GridView ID="grdAdministrators" CssClass="table table-bordered" runat="server"
                                ShowHeaderWhenEmpty="true"
                                AutoGenerateColumns="False"
                                PageSize="5"
                                AllowPaging="True"
                                AllowCustomPaging="True"
                                OnRowCommand="grdAdministrators_RowCommand"
                                EmptyDataText="No hay datos ingresados">
                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="CÓDIGO" />
                                    <asp:BoundField DataField="Name" HeaderText="NOMBRE" />
                                    <asp:BoundField DataField="LastName" HeaderText="APELLIDO" />
                                    <asp:BoundField DataField="DocumentNumber" HeaderText="DOCUMENTO" />
                                    <asp:BoundField DataField="Telephone" HeaderText="TELEFONO" />
                                    <asp:BoundField DataField="Username" HeaderText="USUARIO" />
                                    <asp:BoundField DataField="Password" HeaderText="CONTRASEÑA" />
                                    <asp:TemplateField HeaderText="Editar">
                                        <ItemTemplate>
                                            <asp:ImageButton CssClass="iconAdmManage" ID="btnGetAdministrator" ImageUrl="~/Frontend/Images/EditIcon.png"
                                                Text="Editar" ImageAlign="left" CausesValidation="false" CommandName="UpdateAdministrator" runat="server" CommandArgument='<%# Eval("Id") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Eliminar">
                                        <ItemTemplate>
                                            <asp:ImageButton CssClass="iconAdmManage" ID="btnDelete" ImageUrl="~/Frontend/Images/DeleteIcon.png" OnClientClick="javascript:return confirm('Esta seguro que desea eliminarlo?');"
                                                Text="Eliminar" ImageAlign="left" CausesValidation="false" CommandName="DeleteAdministrator" runat="server" CommandArgument='<%# Eval("Id") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div class="card-footer" style="text-align: center">
                            <nav class="align-self-center navbar-text">
                                <ul class="pagination pagination-circle pg-blue ">
                                    <asp:Repeater ID="repeaterPaging" runat="server">
                                        <ItemTemplate>
                                            <li class="page-item active">
                                                <asp:LinkButton ID="pagingLinkButton" runat="server"
                                                    Text='<%#Eval("Text") %>'
                                                    CommandArgument='<%# Eval("Value") %>'
                                                    Enabled='<%# Eval("Enabled") %>' CssClass="page-link"
                                                    OnClick="linkButton_Click" CausesValidation="false">
                                                </asp:LinkButton>
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </nav>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
