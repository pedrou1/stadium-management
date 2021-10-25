<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend/Admin.Master" AutoEventWireup="true" CodeBehind="EventManagement.aspx.cs" Inherits="stadium_management.Frontend.Forms.EventManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentAdmin" runat="server">
      <script type="text/javascript">
        function ImagePreview(input) {
            $('#<%=lblImageMessage.ClientID%>').hide();
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=imgprw.ClientID%>').prop('src', e.target.result)
                        .width(200)
                        .height(200);
                };
                reader.readAsDataURL(input.files[0]);
            } else {
                $('#<%=imgprw.ClientID%>').attr('src', '/Images/preview.png');
            }
          }

          let loadpicker = () => {
              new Pikaday({
                  field: document.getElementById('<%=txtDateTimePicker.ClientID%>'),
                  format: 'DD/MM/YYYY',
                  i18n: {
                      previousMonth: 'Mes anterior',
                      nextMonth: 'Proximo mes',
                      midnight: 'Medianoche',
                      noon: 'Mediodia',
                      months: ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"],
                      weekdays: ["Domingo", "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado"],
                      weekdaysShort: ['Dom', 'Lun', 'Mar', 'Mie', 'Jue', 'Vie', 'Sab']
                  },
                  showMinutes: true,
                  showSeconds: false,
                  
              });
          }
          window.onload = loadpicker;
      </script>
    <h2>
        Administración de Eventos
    </h2>
    <div style="color: #757575;">
        <div class="row mt-3">
            <div class="col-md-10 mx-auto mt-4">
                <div class="card">
                    <div class="card-body">
                        <div class="form-row">
                            <div id="divId" runat="server" class="col-md-1 mb-3">
                                <asp:Label ID="lblId" Text="Codigo" runat="server"></asp:Label>
                                <asp:TextBox CssClass="form-control form-control-sm" ID="txtId" MaxLength="50" runat="server" Enabled="false"></asp:TextBox>
                            </div>
                            <div class="col-md-4 mb-3">
                                <asp:Label ID="lblName" Text="Nombre" runat="server"></asp:Label>
                                <asp:TextBox CssClass="form-control form-control-sm" ID="txtName" MaxLength="50" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator Display = "Dynamic" ID="rfvName" CssClass="text-danger small" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtName"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-2 mb-3">
                                <asp:Label ID="lblPrice" Text="Precio" runat="server"></asp:Label>
                                <asp:TextBox ID="txtPrice" runat="server" class="form-control form-control-sm" MaxLength="9" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);"></asp:TextBox>
                                <asp:RequiredFieldValidator Display = "Dynamic" ID="rfvPrice" CssClass="text-danger small" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtPrice"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator Display = "Dynamic" ID="revPrice" CssClass="text-danger small" ControlToValidate="txtPrice" runat="server" ErrorMessage="Solo números" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                            </div>
                            <div class="col-md-3 mb-3">
                                <asp:Label ID="lblEventType" Text="Categoría" runat="server"></asp:Label>
                                <asp:DropDownList ID="ddlEventTypes" class="form-control form-control-sm" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-md-3 mb-3">
                                <asp:Label ID="lblDate" Text="Fecha y hora de inicio" runat="server"></asp:Label>
                                <asp:TextBox ID="txtDateTimePicker" runat="server"  CssClass="form-control form-control-sm" MaxLength="40" ></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col-md-4 mb-3">
                                <asp:Label ID="lblRequirements" Text="Requerimientos" runat="server"></asp:Label>
                                <asp:TextBox class="form-control form-control-sm" ID="txtRequirements" MaxLength="100" runat="server" TextMode="multiline" Rows="4"></asp:TextBox>
                                <asp:RequiredFieldValidator Display = "Dynamic" ID="rfvRequirements" CssClass="text-danger small" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtRequirements"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator Display = "Dynamic" ID="revTxtRequirements" CssClass="text-danger small" ControlToValidate="txtRequirements" runat="server" ErrorMessage="El largo máximo son 300 caracteres." ValidationExpression="^.{0,300}$"></asp:RegularExpressionValidator>
                            </div>
                            <div class="col-md-4 mb-3">
                                <asp:Label ID="lblDescription" Text="Descripción" runat="server"></asp:Label>
                                <asp:TextBox class="form-control form-control-sm" ID="txtDescription" MaxLength="100" TextMode="multiline" Rows="4" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator Display = "Dynamic" ID="rfvDescription" CssClass="text-danger small" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtDescription"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator Display = "Dynamic" ID="revTxtDescription" CssClass="text-danger small" ControlToValidate="txtDescription" runat="server" ErrorMessage="El largo máximo son 300 caracteres." ValidationExpression="^.{0,300}$"></asp:RegularExpressionValidator>
                            </div>

                            <div class="col-md-4 mb-3">
                                <asp:Label ID="lblImage" Text="Imagen" runat="server"></asp:Label> 
                                <div class="info-box text-center">
                                    <asp:Image ID="imgprw" runat="server" class="info-box-icon" Width="20%" ImageUrl="~/Images/previewImage.png" />
                                </div>
                                <div class="info-box text-center">
                                    <asp:FileUpload ID="fuImage" accept=".jpg" CssClass="small mt-1" runat="server" onchange="ImagePreview(this);"/>
                                </div>
                                <div class="info-box text-center">
                                    <asp:Label ID="lblImageMessage" CssClass="text-danger small" runat="server" Visible="false"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="form-row">
                            <asp:Label ID="lblMessageResult" Text="" CssClass="text-danger" runat="server" Visible ="false"></asp:Label>
                        </div>
                    </div>
                    <div class="card-footer text-center">
                        <asp:Button class="btn btn-primary btn-md btn-rounded" ID="btnAdd" Text="Agregar" runat="server" onclick="AddEvent"/>
                        <asp:Button class="btn btn-primary btn-md btn-rounded" ID="btnUpdate" Text="Modificar" runat="server" onclick="UpdateEvent"/>
                        <asp:Button class="btn btn-primary btn-md btn-rounded" ID="btnCancel" Text="Cancelar" runat="server" onclick="CancelEvent" CausesValidation="false"/>
                        <asp:Button class="btn btn-primary btn-md btn-rounded" ID="btnClear" Text="Limpiar" runat="server" onclick="ClearEvent" CausesValidation="false"/>
                    </div>
                </div>
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-md-12 mx-auto">
                <div class="card">
                    <div class="table-responsive">
                        <div class="card-body">
                            <asp:GridView ID="grdEvents" CssClass="table table-bordered" runat="server"
                                ShowHeaderWhenEmpty ="true"
                                AutoGenerateColumns="False"
                                PageSize="5"
                                AllowCustomPaging="True"
                                EmptyDataText="No hay datos ingresados"
                                OnRowCommand="grdEvents_RowCommand"
                                AllowPaging="true">
                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="CÓDIGO" />
                                    <asp:imagefield ControlStyle-Width="50" ControlStyle-Height="50" dataimageurlfield="image" dataimageurlformatstring = "~/ImagesUpload/{0}" nulldisplaytext="Sin Imagen" headertext="Image" readonly="true"/>
                                    <asp:BoundField DataField="Name" HeaderText="NOMBRE" />
                                    <asp:BoundField DataField="Requirements" HeaderText="REQUERIMIENTOS" />
                                    <asp:BoundField DataField="Description" HeaderText="DESCRIPCION" />
                                    <asp:BoundField DataField="BasePrice" HeaderText="PRECIO" />
                                    <asp:BoundField DataField="EventType.Name" HeaderText="CATEGORIA" />
                                    <asp:TemplateField HeaderText="Editar">
                                        <ItemTemplate>
                                            <asp:ImageButton CssClass="iconAdmManage" ID="btnGetEvent" ImageUrl="~/Frontend/Images/EditIcon.png"
                                                Text="Editar" ImageAlign="left" CausesValidation = "false" CommandName="UpdateEvent" runat="server" CommandArgument='<%# Eval("Id") %>' />    
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Eliminar">
                                        <ItemTemplate>
                                            <asp:ImageButton CssClass="iconAdmManage" ID="btnDelete" ImageUrl="~/Frontend/Images/DeleteIcon.png" OnClientClick="javascript:return confirm('Esta seguro que desea eliminarlo?');"
                                                Text="Eliminar" ImageAlign="left" CausesValidation="false" CommandName="DeleteEvent" runat="server" CommandArgument='<%# Eval("Id") %>' />    
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div class="card-footer" style="text-align:center">
                            <nav class = "align-self-center navbar-text">
                                <ul class="pagination pagination-circle pg-blue ">
                                    <asp:Repeater ID="repeaterPaging" runat="server">
                                        <ItemTemplate>
                                            <li class="page-item active">
                                                <asp:LinkButton ID="pagingLinkButton" runat="server" 
                                                    Text='<%#Eval("Text") %>' 
                                                    CommandArgument='<%# Eval("Value") %>'
                                                    Enabled='<%# Eval("Enabled") %>'  CssClass="page-link"
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
